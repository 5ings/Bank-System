using BankSystem.Controller;
using BankSystem.Data.Entities;
using BankSystem.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Tests.Services
{
    public class TransactionControllerTests
    {
        [Test]
        public async Task TransferMoney_SameCurrency_UpdatesBalancesAndCreatesTransaction()
        {
            var context = TestDbBank.CreateContext();

            var source = new Account { AccountID = 1, IBAN = "BG00BANK1", Balance = 500.0m, Currency = "EUR" };
            var target = new Account { AccountID = 2, IBAN = "BG00BANK2", Balance = 100.0m, Currency = "EUR" };
            context.Accounts.AddRange(source, target);
            await context.SaveChangesAsync();

            TransactionController txController = new TransactionController(context);

            await txController.TransferMoney(1, "BG00BANK2", 200.0m);

            Assert.AreEqual(300.0m, source.Balance);
            Assert.AreEqual(300.0m, target.Balance); 

            var tx = await context.Transactions.FirstOrDefaultAsync();
            Assert.IsNotNull(tx);
            Assert.AreEqual(1, tx.FromAccountID);
            Assert.AreEqual(2, tx.ToAccountID);
            Assert.AreEqual(200.0m, tx.Amount);
        }

        [Test]
        public async Task TransferMoney_DifferentCurrency_AppliesExchangeRate()
        {
            var context = TestDbBank.CreateContext();

            var source = new Account { AccountID = 1, IBAN = "BGUSD", Balance = 100.0m, Currency = "USD" };
            var target = new Account { AccountID = 2, IBAN = "BGEUR", Balance = 100.0m, Currency = "EUR" };
            context.Accounts.AddRange(source, target);
            await context.SaveChangesAsync();

            TransactionController txController = new TransactionController(context);

            await txController.TransferMoney(1, "BGEUR", 50.0m);

            Assert.AreEqual(50.0m, source.Balance);
            Assert.AreEqual(146.0m, target.Balance); 
        }

        [Test]
        public async Task TransferMoney_InsufficientBalance_ThrowsException()
        {
            var context = TestDbBank.CreateContext();

            var source = new Account { AccountID = 1, IBAN = "BG1", Balance = 10.0m, Currency = "EUR" };
            var target = new Account { AccountID = 2, IBAN = "BG2", Balance = 100.0m, Currency = "EUR" };
            context.Accounts.AddRange(source, target);
            await context.SaveChangesAsync();

            TransactionController txController = new TransactionController(context);

            var ex = Assert.ThrowsAsync<Exception>(async () =>
            {
                await txController.TransferMoney(1, "BG2", 50.0m);
            });

            Assert.AreEqual("Недостатъчна наличност!", ex.Message);
        }


        [Test]
        public async Task DepositMoney_ValidAmount_IncreasesBalance()
        {
            var context = TestDbBank.CreateContext();

            var acc = new Account { AccountID = 10, IBAN = "BGDEPOSIT", Balance = 50.0m, Currency = "EUR" };
            context.Accounts.Add(acc);
            await context.SaveChangesAsync();

            TransactionController txController = new TransactionController(context);

            await txController.DepositMoney(10, 150.0m);

            var updatedAcc = await context.Accounts.FindAsync(10);
            Assert.IsNotNull(updatedAcc);
            Assert.AreEqual(200.0m, updatedAcc.Balance);

            var tx = await context.Transactions.FirstOrDefaultAsync(t => t.ToAccountID == 10);
            Assert.IsNotNull(tx);
            Assert.IsNull(tx.FromAccountID);
            Assert.AreEqual(150.0m, tx.Amount);
        }


        [Test]
        public async Task WithdrawMoney_ValidAmount_DecreasesBalance()
        {
            var context = TestDbBank.CreateContext();

            var acc = new Account { AccountID = 20, IBAN = "BGWITHDRAW", Balance = 300.0m, Currency = "EUR" };
            context.Accounts.Add(acc);
            await context.SaveChangesAsync();

            TransactionController txController = new TransactionController(context);

            await txController.WithdrawMoney(20, 100.0m);

            var updatedAcc = await context.Accounts.FindAsync(20);
            Assert.IsNotNull(updatedAcc);
            Assert.AreEqual(200.0m, updatedAcc.Balance);

            var tx = await context.Transactions.FirstOrDefaultAsync(t => t.FromAccountID == 20);
            Assert.IsNotNull(tx);
            Assert.IsNull(tx.ToAccountID); 
        }


        [Test]
        public async Task GetAccountByIban_ExistingIban_ReturnsAccount()
        {

            var context = TestDbBank.CreateContext();

            var acc = new Account { AccountID = 5, IBAN = "BGFINDME", Balance = 0.0m, Currency = "EUR" };
            context.Accounts.Add(acc);
            await context.SaveChangesAsync();

            TransactionController txController = new TransactionController(context);

            Account result = await txController.GetAccountByIban("  BGFINDME  ");

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.AccountID);
        }


        [Test]
        public async Task GetHistoryByAccount_ReturnsTransactionsInCorrectOrder()
        {
            var context = TestDbBank.CreateContext();

            context.Transactions.Add(new BankSystem.Data.Entities.Transaction { FromAccountID = 99, ToAccountID = 1, Amount = 10, TransactionDate = DateTime.Now.AddDays(-1) });
            context.Transactions.Add(new BankSystem.Data.Entities.Transaction { FromAccountID = 2, ToAccountID = 99, Amount = 20, TransactionDate = DateTime.Now });
            await context.SaveChangesAsync();

            TransactionController txController = new TransactionController(context);

            var history = await txController.GetHistoryByAccount(99);

            Assert.AreEqual(2, history.Count);
            Assert.AreEqual(20, history[0].Amount);
        }
    }
}
