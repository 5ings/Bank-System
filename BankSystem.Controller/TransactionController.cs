using BankSystem.Data;
using BankSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankSystem.Controller
{
    public class TransactionController
    {
        public BankDbContext Context { get; set; }

        public TransactionController()
        {
            Context = new BankDbContext();
        }

        public TransactionController(BankDbContext context)
        {
            Context = context;
        }

        public async Task TransferMoney(int sourceAccountId, string targetIban, decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Сумата трябва да е положителна!");
            if (string.IsNullOrWhiteSpace(targetIban)) throw new ArgumentException("IBAN не може да е празен!");

            using (var dbTransaction = await Context.Database.BeginTransactionAsync())
            {
                var sourceAcc = await Context.Accounts.FirstOrDefaultAsync(a => a.AccountID == sourceAccountId);
                var targetAcc = await Context.Accounts.FirstOrDefaultAsync(a => a.IBAN == targetIban.Trim());

                if (sourceAcc == null) throw new Exception("Подателят не е намерен!");
                if (targetAcc == null) throw new Exception("Сметка с такъв IBAN не съществува!");
                if (sourceAcc.AccountID == targetAcc.AccountID) throw new InvalidOperationException("Не може превод към същата сметка!");
                if (sourceAcc.Balance < amount) throw new Exception("Недостатъчна наличност!");

                decimal amountToCredit = amount;
                if (sourceAcc.Currency != targetAcc.Currency)
                {
                    decimal rate = GetExchangeRate(sourceAcc.Currency, targetAcc.Currency);
                    amountToCredit = amount * rate;
                }

                sourceAcc.Balance -= amount;
                targetAcc.Balance += amountToCredit;

                var tx = new BankSystem.Data.Entities.Transaction
                {
                    FromAccountID = sourceAcc.AccountID,
                    ToAccountID = targetAcc.AccountID,
                    Amount = amount,
                    TransactionDate = DateTime.Now
                };

                Context.Transactions.Add(tx);
                await Context.SaveChangesAsync();
                await dbTransaction.CommitAsync();
            }
        }

        private decimal GetExchangeRate(string fromCurrency, string toCurrency)
        {
            if (fromCurrency == toCurrency) return 1.0m;
            if (fromCurrency == "USD" && toCurrency == "EUR") return 0.92m;
            if (fromCurrency == "EUR" && toCurrency == "USD") return 1.08m;

            throw new Exception($"Няма дефиниран валутен курс за {fromCurrency} към {toCurrency}");
        }

        public async Task DepositMoney(int accountId, decimal amount)
        {
            var account = await Context.Accounts.FindAsync(accountId);
            if (account == null) throw new Exception("Сметката не е намерена!");

            account.Balance += amount;

            var tx = new BankSystem.Data.Entities.Transaction
            {
                FromAccountID = null,
                ToAccountID = accountId,
                Amount = amount,
                TransactionDate = DateTime.Now
            };

            Context.Transactions.Add(tx);
            await Context.SaveChangesAsync();
        }

        public async Task<List<BankSystem.Data.Entities.Transaction>> GetHistoryByAccount(int accountId)
        {
            return await Context.Transactions
                .Where(t => t.FromAccountID == accountId || t.ToAccountID == accountId)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }

        public async Task<Account> GetAccountByIban(string iban)
        {
            if (string.IsNullOrWhiteSpace(iban))
            {
                throw new ArgumentException("IBAN-ът не може да бъде празен!");
            }

            var account = await Context.Accounts.FirstOrDefaultAsync(a => a.IBAN == iban.Trim());
            if (account == null)
            {
                throw new Exception($"Не съществува банкова сметка с IBAN: {iban}");
            }

            return account;
        }

        public async Task WithdrawMoney(int accountId, decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумата за теглене трябва да бъде положително число!");

            var account = await Context.Accounts.FindAsync(accountId);
            if (account == null)
                throw new Exception("Сметката не е намерена!");

            if (account.Balance < amount)
                throw new Exception($"Недостатъчна наличност! Текущ баланс: {account.Balance:F2} лв.");

            account.Balance -= amount;

            var withdrawTx = new BankSystem.Data.Entities.Transaction
            {
                FromAccountID = accountId,
                ToAccountID = null,
                Amount = amount,
                TransactionDate = DateTime.Now
            };

            await Context.Transactions.AddAsync(withdrawTx);
            await Context.SaveChangesAsync();
        }

    }
}

