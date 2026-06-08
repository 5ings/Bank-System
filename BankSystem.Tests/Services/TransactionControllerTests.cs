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

            var source = new Account { AccountID = 1, IBAN = "BG98BNKB00000000000001", Balance = 500.0m, Currency = "EUR" };
            var target = new Account { AccountID = 2, IBAN = "BG98BNKB00000000000002", Balance = 100.0m, Currency = "EUR" };
            context.Accounts.AddRange(source, target);
            await context.SaveChangesAsync();

            TransactionController txController = new TransactionController(context);

            await txController.TransferMoney(1, "BG98BNKB00000000000002", 200.0m);

            var updatedSource = await context.Accounts.FindAsync(1);
            var updatedTarget = await context.Accounts.FindAsync(2);

            Assert.IsNotNull(updatedSource);
            Assert.IsNotNull(updatedTarget);
            Assert.AreEqual(300.0m, updatedSource.Balance);
            Assert.AreEqual(300.0m, updatedTarget.Balance);

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

            var source = new Account { AccountID = 1, IBAN = "BG98BNKB11111111111111", Balance = 100.0m, Currency = "USD" };
            var target = new Account { AccountID = 2, IBAN = "BG98BNKB22222222222222", Balance = 100.0m, Currency = "EUR" };
            context.Accounts.AddRange(source, target);
            await context.SaveChangesAsync();

            TransactionController txController = new TransactionController(context);

            await txController.TransferMoney(1, "BG98BNKB22222222222222", 50.0m);

            var updatedSource = await context.Accounts.FindAsync(1);
            var updatedTarget = await context.Accounts.FindAsync(2);

            Assert.IsNotNull(updatedSource);
            Assert.IsNotNull(updatedTarget);
            Assert.AreEqual(50.0m, updatedSource.Balance);
            Assert.AreEqual(146.0m, updatedTarget.Balance);
        }

        [Test]
        public async Task TransferMoney_InsufficientBalance_ThrowsException()
        {
            var context = TestDbBank.CreateContext();

            var source = new Account { AccountID = 1, IBAN = "BG98BNKB11111111111111", Balance = 10.0m, Currency = "EUR" };
            var target = new Account { AccountID = 2, IBAN = "BG98BNKB22222222222222", Balance = 100.0m, Currency = "EUR" };
            context.Accounts.AddRange(source, target);
            await context.SaveChangesAsync();

            TransactionController txController = new TransactionController(context);

            var ex = Assert.ThrowsAsync<Exception>(async () =>
            {
                await txController.TransferMoney(1, "BG98BNKB22222222222222", 50.0m);
            });

            Assert.IsTrue(ex?.Message?.Contains("Недостатъчна наличност"));
        }

        [Test]
        public void TransferMoney_InvalidIbanFormat_ThrowsArgumentException()
        {
            var context = TestDbBank.CreateContext();
            TransactionController txController = new TransactionController(context);

            var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await txController.TransferMoney(1, "INVALID-IBAN", 50.0m);
            });

            Assert.AreEqual("Невалиден формат на IBAN! Българският IBAN трябва да започва с BG и да съдържа общо 22 символа.", ex?.Message);
        }

        [Test]
        public async Task TransferMoney_SourceAccountNotFound_ThrowsException()
        {
            var context = TestDbBank.CreateContext();
            var target = new Account { AccountID = 2, IBAN = "BG98BNKB22222222222222", Balance = 100.0m, Currency = "EUR" };
            context.Accounts.Add(target);
            await context.SaveChangesAsync();

            TransactionController txController = new TransactionController(context);

            var ex = Assert.ThrowsAsync<Exception>(async () =>
            {
                await txController.TransferMoney(999, "BG98BNKB22222222222222", 50.0m);
            });

            Assert.AreEqual("Сметката на подателя не е намерена!", ex?.Message);
        }

        [Test]
        public async Task TransferMoney_TargetAccountNotFound_ThrowsException()
        {
            var context = TestDbBank.CreateContext();
            var source = new Account { AccountID = 1, IBAN = "BG98BNKB11111111111111", Balance = 100.0m, Currency = "EUR" };
            context.Accounts.Add(source);
            await context.SaveChangesAsync();

            TransactionController txController = new TransactionController(context);

            var ex = Assert.ThrowsAsync<Exception>(async () =>
            {
                await txController.TransferMoney(1, "BG98BNKB22222222222222", 50.0m);
            });

            Assert.AreEqual("Сметка с такъв IBAN не съществува в системата!", ex?.Message);
        }

        [Test]
        public async Task TransferMoney_SameSourceAndTarget_ThrowsInvalidOperationException()
        {
            var context = TestDbBank.CreateContext();
            var source = new Account { AccountID = 1, IBAN = "BG98BNKB11111111111111", Balance = 100.0m, Currency = "EUR" };
            context.Accounts.Add(source);
            await context.SaveChangesAsync();

            TransactionController txController = new TransactionController(context);

            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            {
                await txController.TransferMoney(1, "BG98BNKB11111111111111", 50.0m);
            });

            Assert.AreEqual("Не може да извършите превод към същата сметка!", ex?.Message);
        }

        [Test]
        public async Task DepositMoney_ValidAmount_IncreasesBalance()
        {
            var context = TestDbBank.CreateContext();

            var acc = new Account { AccountID = 10, IBAN = "BG98BNKB10101010101010", Balance = 50.0m, Currency = "EUR" };
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
        public void DepositMoney_ZeroOrNegativeAmount_ThrowsArgumentException()
        {
            var context = TestDbBank.CreateContext();
            TransactionController txController = new TransactionController(context);

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await txController.DepositMoney(10, -50.0m));
            Assert.AreEqual("Сумата за депозит трябва да бъде по-голяма от 0!", ex?.Message);
        }

        [Test]
        public async Task WithdrawMoney_ValidAmount_DecreasesBalance()
        {
            var context = TestDbBank.CreateContext();

            var acc = new Account { AccountID = 20, IBAN = "BG98BNKB20202020202020", Balance = 300.0m, Currency = "EUR" };
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
        public async Task WithdrawMoney_InsufficientBalance_ThrowsException()
        {
            var context = TestDbBank.CreateContext();

            var acc = new Account { AccountID = 20, IBAN = "BG98BNKB20202020202020", Balance = 50.0m, Currency = "EUR" };
            context.Accounts.Add(acc);
            await context.SaveChangesAsync();

            TransactionController txController = new TransactionController(context);

            var ex = Assert.ThrowsAsync<Exception>(async () => await txController.WithdrawMoney(20, 100.0m));
            Assert.IsTrue(ex?.Message?.Contains("Недостатъчна наличност"));
        }

        [Test]
        public async Task GetAccountByIban_ExistingIban_ReturnsAccount()
        {
            var context = TestDbBank.CreateContext();

            var acc = new Account { AccountID = 5, IBAN = "BG98BNKB55555555555555", Balance = 0.0m, Currency = "EUR" };
            context.Accounts.Add(acc);
            await context.SaveChangesAsync();

            TransactionController txController = new TransactionController(context);

            Account result = await txController.GetAccountByIban("  BG98BNKB55555555555555  ");

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.AccountID);
        }

        [Test]
        public async Task GetHistoryByAccount_ReturnsTransactionsInCorrectOrder()
        {
            var context = TestDbBank.CreateContext();

            var acc = new Account { AccountID = 99, IBAN = "BG98BNKB99999999999999", Balance = 100.0m, Currency = "EUR" };
            context.Accounts.Add(acc);
            await context.SaveChangesAsync();

            context.Transactions.Add(new BankSystem.Data.Entities.Transaction { FromAccountID = 99, ToAccountID = 1, Amount = 10, TransactionDate = DateTime.Now.AddDays(-1) });
            context.Transactions.Add(new BankSystem.Data.Entities.Transaction { FromAccountID = 2, ToAccountID = 99, Amount = 20, TransactionDate = DateTime.Now });
            await context.SaveChangesAsync();

            TransactionController txController = new TransactionController(context);

            var history = await txController.GetHistoryByAccount(99);

            Assert.IsNotNull(history);
            Assert.AreEqual(2, history.Count);
            Assert.AreEqual(20, history[0].Amount);
        }

        [Test]
        public void GetHistoryByAccount_NonExistingAccount_ThrowsException()
        {
            var context = TestDbBank.CreateContext();
            TransactionController txController = new TransactionController(context);

            var ex = Assert.ThrowsAsync<Exception>(async () => await txController.GetHistoryByAccount(999));
            Assert.AreEqual("Търсената сметка не съществува.", ex?.Message);
        }
    }
}
