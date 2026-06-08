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
    public class AccountControllerTests
    {
        [Test]
        public async Task CreateAccount_SuccessfullyAddsAccountToDb_InEuro()
        {
            var context = TestDbBank.CreateContext();
            var client = new Client { ClientID = 1, FirstName = "Test", LastName = "Client", EGN = "1234567890", Phone = "088", Email = "t@test.com" };
            context.Clients.Add(client);
            await context.SaveChangesAsync();

            AccountController accountController = new AccountController(context);

            var newAccount = new Account
            {
                Balance = 500.0m,
                Currency = "eur",
                ClientID = 1
            };

            await accountController.CreateAccount(newAccount);

            var dbAccount = await context.Accounts.FirstOrDefaultAsync(a => a.ClientID == 1);

            Assert.IsNotNull(dbAccount);
            Assert.IsFalse(string.IsNullOrEmpty(dbAccount.IBAN));
            Assert.IsTrue(dbAccount.IBAN.StartsWith("BG98BNKB"));
            Assert.AreEqual(22, dbAccount.IBAN.Length);
            Assert.AreEqual(500.0m, dbAccount.Balance);
            Assert.AreEqual("EUR", dbAccount.Currency);
        }

        [Test]
        public async Task CreateAccount_SuccessfullyAddsAccountToDb_InUsd()
        {
            var context = TestDbBank.CreateContext();
            var client = new Client { ClientID = 2, FirstName = "John", LastName = "Doe", EGN = "0987654321", Phone = "089", Email = "j@test.com" };
            context.Clients.Add(client);
            await context.SaveChangesAsync();

            AccountController accountController = new AccountController(context);

            var newAccount = new Account
            {
                Balance = 1500.50m,
                Currency = "USD",
                ClientID = 2
            };

            await accountController.CreateAccount(newAccount);

            var dbAccount = await context.Accounts.FirstOrDefaultAsync(a => a.ClientID == 2);

            Assert.IsNotNull(dbAccount);
            Assert.AreEqual(1500.50m, dbAccount.Balance);
            Assert.AreEqual("USD", dbAccount.Currency);
        }

        [Test]
        public void CreateAccount_ThrowsException_WhenClientDoesNotExist()
        {
            var context = TestDbBank.CreateContext();
            AccountController accountController = new AccountController(context);

            var account = new Account { Balance = 100.0m, Currency = "EUR", ClientID = 999 };

            var ex = Assert.ThrowsAsync<Exception>(async () => await accountController.CreateAccount(account));
            Assert.AreEqual("Не може да се открие сметка на несъществуващ клиент.", ex?.Message);
        }

        [Test]
        public async Task CreateAccount_ThrowsArgumentException_WhenBalanceIsNegative()
        {
            var context = TestDbBank.CreateContext();
            var client = new Client { ClientID = 1, FirstName = "A", LastName = "B", EGN = "1", Phone = "1", Email = "a@b.com" };
            context.Clients.Add(client);
            await context.SaveChangesAsync();

            AccountController accountController = new AccountController(context);
            var account = new Account { Balance = -50.0m, Currency = "USD", ClientID = 1 };

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await accountController.CreateAccount(account));
            Assert.AreEqual("Първоначалният баланс на сметката не може да бъде отрицателно число.", ex?.Message);
        }

        [Test]
        public async Task CreateAccount_ThrowsArgumentException_WhenCurrencyIsEmpty()
        {
            var context = TestDbBank.CreateContext();
            var client = new Client { ClientID = 1, FirstName = "A", LastName = "B", EGN = "1", Phone = "1", Email = "a@b.com" };
            context.Clients.Add(client);
            await context.SaveChangesAsync();

            AccountController accountController = new AccountController(context);
            var account = new Account { Balance = 10.0m, Currency = "", ClientID = 1 };

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await accountController.CreateAccount(account));
            Assert.AreEqual("Трябва да посочите валута (напр. BGN, EUR, USD).", ex?.Message);
        }

        [Test]
        public async Task CreateAccount_ThrowsArgumentException_WhenCurrencyIsUnsupported()
        {
            var context = TestDbBank.CreateContext();
            var client = new Client { ClientID = 1, FirstName = "A", LastName = "B", EGN = "1", Phone = "1", Email = "a@b.com" };
            context.Clients.Add(client);
            await context.SaveChangesAsync();

            AccountController accountController = new AccountController(context);
            var account = new Account { Balance = 10.0m, Currency = "GBP", ClientID = 1 };

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await accountController.CreateAccount(account));
            Assert.IsTrue(ex?.Message?.Contains("не се поддържа от системата"));
        }

        [Test]
        public async Task GetAllAccounts_ReturnsAllAccountsWithClientIncluded()
        {
            var context = TestDbBank.CreateContext();

            var client1 = new Client { FirstName = "Ivan", LastName = "Ivanov", EGN = "111", Phone = "111", Email = "i@test.com" };
            var client2 = new Client { FirstName = "Petar", LastName = "Petrov", EGN = "222", Phone = "222", Email = "p@test.com" };

            context.Accounts.Add(new Account { IBAN = "BG111", Balance = 50.0m, Currency = "EUR", Client = client1 });
            context.Accounts.Add(new Account { IBAN = "BG222", Balance = 150.0m, Currency = "USD", Client = client2 });
            await context.SaveChangesAsync();

            AccountController accountController = new AccountController(context);
            List<Account> accounts = await accountController.GetAllAccounts();

            Assert.IsNotNull(accounts);
            Assert.AreEqual(2, accounts.Count);
            Assert.IsNotNull(accounts[0].Client);
            Assert.IsNotNull(accounts[1].Client);
        }

        [Test]
        public async Task GetAccountsByClient_ReturnsOnlyAccountsForSpecificClient()
        {
            var context = TestDbBank.CreateContext();

            context.Accounts.Add(new Account { IBAN = "BG1", Balance = 10.0m, Currency = "EUR", ClientID = 10 });
            context.Accounts.Add(new Account { IBAN = "BG2", Balance = 20.0m, Currency = "USD", ClientID = 10 });
            context.Accounts.Add(new Account { IBAN = "BG3", Balance = 30.0m, Currency = "EUR", ClientID = 20 });
            await context.SaveChangesAsync();

            AccountController accountController = new AccountController(context);
            List<Account> accounts = await accountController.GetAccountsByClient(10);

            Assert.IsNotNull(accounts);
            Assert.AreEqual(2, accounts.Count);
            Assert.IsTrue(accounts.TrueForAll(a => a.ClientID == 10));
        }

        [Test]
        public async Task DeleteAccount_RemovesAccountCorrectly_WhenConditionsAreMet()
        {
            var context = TestDbBank.CreateContext();

            var accountToDelete = new Account
            {
                IBAN = "BGDELETE",
                Balance = 0.0m,
                Currency = "EUR",
                ClientID = 1,
                BankCards = new List<BankCard>()
            };
            context.Accounts.Add(accountToDelete);
            await context.SaveChangesAsync();

            int targetId = accountToDelete.AccountID;
            AccountController accountController = new AccountController(context);

            await accountController.DeleteAccount(targetId);

            var dbAccount = await context.Accounts.FindAsync(targetId);
            Assert.IsNull(dbAccount);
        }

        [Test]
        public async Task DeleteAccount_ThrowsException_WhenAccountHasRemainingBalance()
        {
            var context = TestDbBank.CreateContext();

            var account = new Account { IBAN = "BG_WITH_MONEY", Balance = 10.50m, Currency = "USD", ClientID = 1 };
            context.Accounts.Add(account);
            await context.SaveChangesAsync();

            AccountController accountController = new AccountController(context);

            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await accountController.DeleteAccount(account.AccountID));
            Assert.IsTrue(ex?.Message?.Contains("не може да бъде закрита, тъй като в нея има наличност"));
        }

        [Test]
        public async Task DeleteAccount_ThrowsException_WhenAccountHasActiveCards()
        {
            var context = TestDbBank.CreateContext();

            var account = new Account
            {
                IBAN = "BG_WITH_CARDS",
                Balance = 0.0m,
                Currency = "EUR",
                ClientID = 1,
                BankCards = new List<BankCard> { new BankCard { CardNumber = "1234", CVV = "123", ExpiryDate = "12/29" } }
            };
            context.Accounts.Add(account);
            await context.SaveChangesAsync();

            AccountController accountController = new AccountController(context);

            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await accountController.DeleteAccount(account.AccountID));
            Assert.AreEqual("Сметката има активни банкови карти. Първо изтрийте/анулирайте картите, свързани с нея.", ex?.Message);
        }
    }
}
