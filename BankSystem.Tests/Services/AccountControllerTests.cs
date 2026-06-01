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
        public async Task CreateAccount_SuccessfullyAddsAccountToDb()
        {
            var context = TestDbBank.CreateContext();
            AccountController accountController = new AccountController(context);

            var newAccount = new Account
            {
                IBAN = "BG00BANK00001234567890",
                Balance = 1000.0m,
                Currency = "BGN",
                ClientID = 1
            };

            await accountController.CreateAccount(newAccount);

            var dbAccount = await context.Accounts.FirstOrDefaultAsync(a => a.IBAN == "BG00BANK00001234567890");
            Assert.IsNotNull(dbAccount);
            Assert.AreEqual(1000.0m, dbAccount.Balance);
            Assert.AreEqual("BGN", dbAccount.Currency);
        }

        [Test]
        public async Task GetAllAccounts_ReturnsAllAccountsWithClientIncluded()
        {
            var context = TestDbBank.CreateContext();

            var client1 = new Client { FirstName = "Иван", LastName = "Иванов", EGN = "111", Phone = "111", Email = "i@test.com", Accounts = new List<Account>() };
            var client2 = new Client { FirstName = "Петър", LastName = "Петров", EGN = "222", Phone = "222", Email = "p@test.com", Accounts = new List<Account>() };

            context.Accounts.Add(new Account { IBAN = "BG111", Balance = 50.0m, Currency = "BGN", Client = client1 });
            context.Accounts.Add(new Account { IBAN = "BG222", Balance = 150.0m, Currency = "EUR", Client = client2 });
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

            context.Accounts.Add(new Account { IBAN = "BG1", Balance = 10.0m, Currency = "BGN", ClientID = 10 });
            context.Accounts.Add(new Account { IBAN = "BG2", Balance = 20.0m, Currency = "BGN", ClientID = 10 });
            context.Accounts.Add(new Account { IBAN = "BG3", Balance = 30.0m, Currency = "BGN", ClientID = 20 });
            await context.SaveChangesAsync();

            AccountController accountController = new AccountController(context);

            List<Account> accounts = await accountController.GetAccountsByClient(10);

            Assert.IsNotNull(accounts);
            Assert.AreEqual(2, accounts.Count);
            Assert.IsTrue(accounts.TrueForAll(a => a.ClientID == 10));
        }

        [Test]
        public async Task DeleteAccount_RemovesAccountCorrectly()
        {
            var context = TestDbBank.CreateContext();

            var accountToDelete = new Account
            {
                IBAN = "BGDELETE",
                Balance = 0.0m,
                Currency = "BGN",
                ClientID = 1
            };
            context.Accounts.Add(accountToDelete);
            await context.SaveChangesAsync();

            int targetId = accountToDelete.AccountID;

            AccountController accountController = new AccountController(context);

            await accountController.DeleteAccount(targetId);

            var dbAccount = await context.Accounts.FindAsync(targetId);
            Assert.IsNull(dbAccount);
        }
    }
}
