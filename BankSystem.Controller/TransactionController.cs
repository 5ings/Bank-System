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
            if (amount <= 0) throw new ArgumentException("Сумата на превода трябва да бъде положително число!");

            using (BankDbContext context = new BankDbContext())
            {
                using (var dbTransaction = await context.Database.BeginTransactionAsync())
                {
                    var sourceAcc = await context.Accounts.FirstOrDefaultAsync(a => a.AccountID == sourceAccountId);
                    if (sourceAcc == null) throw new Exception("Сметката на изпращача не съществува!");
                    if (sourceAcc.Balance < amount) throw new Exception("Нямате достатъчна наличност по сметката!");

                    var targetAcc = await context.Accounts.FirstOrDefaultAsync(a => a.IBAN == targetIban);
                    if (targetAcc == null) throw new Exception("Сметката на получателя с този IBAN не е намерена!");

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
    }
}

