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
        public async Task TransferMoney(int sourceAccountId, string targetIban, decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумата на превода трябва да бъде положително число!");

            if (string.IsNullOrWhiteSpace(targetIban))
                throw new ArgumentException("IBAN-ът на получателя не може да бъде празен!");

            using (BankDbContext context = new BankDbContext())
            {
                using (var dbTransaction = await context.Database.BeginTransactionAsync())
                {
                    var sourceAcc = await context.Accounts.FirstOrDefaultAsync(a => a.AccountID == sourceAccountId);
                    if (sourceAcc == null)
                        throw new Exception("Сметката на изпращача не съществува!");
                    if (sourceAcc.Balance < amount)
                        throw new Exception("Нямате достатъчна наличност по сметката!");

                    var targetAcc = await context.Accounts.FirstOrDefaultAsync(a => a.IBAN == targetIban.Trim());
                    if (targetAcc == null)
                        throw new Exception("Сметката на получателя с този IBAN не е намерена!");

                    if (sourceAcc.AccountID == targetAcc.AccountID)
                        throw new InvalidOperationException("Не можете да правите превод към същата сметка!");

                    sourceAcc.Balance -= amount;
                    targetAcc.Balance += amount;

                    var txSource = new BankSystem.Data.Entities.Transaction
                    {
                        AccountID = sourceAcc.AccountID,
                        Amount = -amount,
                        TransactionType = $"Превод към {targetIban}",
                        TransactionDate = DateTime.Now
                    };

                    var txTarget = new BankSystem.Data.Entities.Transaction
                    {
                        AccountID = targetAcc.AccountID,
                        Amount = amount,
                        TransactionType = $"Превод от {sourceAcc.IBAN}",
                        TransactionDate = DateTime.Now
                    };

                    await context.Transactions.AddAsync(txSource);
                    await context.Transactions.AddAsync(txTarget);

                    await context.SaveChangesAsync();
                    await dbTransaction.CommitAsync();
                }
            }
        }

        public async Task DepositMoney(int accountId, decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Внесената сума трябва да е по-голяма от 0 лв.");

            using (BankDbContext context = new BankDbContext())
            {
                var account = await context.Accounts.FirstOrDefaultAsync(a => a.AccountID == accountId);
                if (account == null) throw new Exception("Сметката не е намерена.");

                account.Balance += amount;

                var depositTx = new BankSystem.Data.Entities.Transaction
                {
                    AccountID = accountId,
                    Amount = amount,
                    TransactionType = "Депозит",
                    TransactionDate = DateTime.Now
                };

                await context.Transactions.AddAsync(depositTx);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<BankSystem.Data.Entities.Transaction>> GetHistoryByAccount(int accountId)
        {
            using (BankDbContext context = new BankDbContext())
            {
                return await context.Transactions
                    .Where(t => t.AccountID == accountId)
                    .OrderByDescending(t => t.TransactionDate)
                    .ToListAsync();
            }
        }

        public async Task<Account> GetAccountByIban(string iban)
        {
            if (string.IsNullOrWhiteSpace(iban))
            {
                throw new ArgumentException("IBAN-ът не може да бъде празен!");
            }

            using (var context = new BankDbContext())
            {
                var account = await context.Accounts
                                            .FirstOrDefaultAsync(a => a.IBAN == iban.Trim());

                if (account == null)
                {
                    throw new Exception($"Не съществува банкова сметка с IBAN: {iban}");
                }

                return account;
            }
        }
        public async Task WithdrawMoney(int accountId, decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сумата за теглене трябва да бъде положително число!");

            using (var context = new BankDbContext())
            {
                var account = await context.Accounts.FirstOrDefaultAsync(a => a.AccountID == accountId);
                if (account == null)
                    throw new Exception("Сметката не е намерена!");

                if (account.Balance < amount)
                    throw new Exception($"Недостатъчна наличност! Текущ баланс: {account.Balance:F2} лв.");

                account.Balance -= amount;

                var withdrawTx = new BankSystem.Data.Entities.Transaction
                {
                    AccountID = accountId,
                    Amount = -amount, 
                    TransactionType = "Теглене в брой",
                    TransactionDate = DateTime.Now
                };

                await context.Transactions.AddAsync(withdrawTx);
                await context.SaveChangesAsync();
            }
        }

    }
}

