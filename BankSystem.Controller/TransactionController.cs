using BankSystem.Data;
using BankSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        //IBAN (Формат: BGxx AAAA cccc cccc cccc cc)
        private void ValidateIbanFormat(string iban)
        {
            if (string.IsNullOrWhiteSpace(iban))
            {
                throw new ArgumentException("IBAN не може да бъде празен!");
            }

            //български IBAN (общо 22 символа: BG, 2 цифри, 4 букви за код на банка, 14 символа за сметка)
            var ibanRegex = new Regex(@"^BG[0-9]{2}[A-Z]{4}[0-9]{14}$", RegexOptions.IgnoreCase);

            string cleanIban = iban.Replace(" ", "").Trim();

            if (!ibanRegex.IsMatch(cleanIban))
            {
                throw new ArgumentException("Невалиден формат на IBAN! Българският IBAN трябва да започва с BG и да съдържа общо 22 символа.");
            }
        }

        public async Task TransferMoney(int sourceAccountId, string targetIban, decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Сумата за превод трябва да е по-голяма от 0!");

            ValidateIbanFormat(targetIban);
            string cleanTargetIban = targetIban.Replace(" ", "").Trim();

            using (var dbTransaction = await Context.Database.BeginTransactionAsync())
            {
                var sourceAcc = await Context.Accounts.FirstOrDefaultAsync(a => a.AccountID == sourceAccountId);
                var targetAcc = await Context.Accounts.FirstOrDefaultAsync(a => a.IBAN == cleanTargetIban);

                if (sourceAcc == null) throw new Exception("Сметката на подателя не е намерена!");
                if (targetAcc == null) throw new Exception("Сметка с такъв IBAN не съществува в системата!");
                if (sourceAcc.AccountID == targetAcc.AccountID) throw new InvalidOperationException("Не може да извършите превод към същата сметка!");
                if (sourceAcc.Balance < amount) throw new Exception($"Недостатъчна наличност! Текущ баланс: {sourceAcc.Balance:F2} {sourceAcc.Currency}");

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

                await Context.Transactions.AddAsync(tx);
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
            if (amount <= 0)
            {
                throw new ArgumentException("Сумата за депозит трябва да бъде по-голяма от 0!");
            }

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

            await Context.Transactions.AddAsync(tx);
            await Context.SaveChangesAsync();
        }

        public async Task<List<BankSystem.Data.Entities.Transaction>> GetHistoryByAccount(int accountId)
        {
            var accountExists = await Context.Accounts.AnyAsync(a => a.AccountID == accountId);
            if (!accountExists)
            {
                throw new Exception("Търсената сметка не съществува.");
            }

            return await Context.Transactions
                .Where(t => t.FromAccountID == accountId || t.ToAccountID == accountId)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }

        public async Task<Account> GetAccountByIban(string iban)
        {
            ValidateIbanFormat(iban);
            string cleanIban = iban.Replace(" ", "").Trim();

            var account = await Context.Accounts.FirstOrDefaultAsync(a => a.IBAN == cleanIban);
            if (account == null)
            {
                throw new Exception($"Не съществува банкова сметка с IBAN: {iban}");
            }

            return account;
        }

        public async Task WithdrawMoney(int accountId, decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумата за теглене трябва да бъде по-голяма от 0!");

            var account = await Context.Accounts.FindAsync(accountId);
            if (account == null)
                throw new Exception("Сметката не е намерена!");

            if (account.Balance < amount)
                throw new Exception($"Недостатъчна наличност! Текущ баланс: {account.Balance:F2} {account.Currency}.");

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

