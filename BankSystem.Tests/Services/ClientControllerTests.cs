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
    public class ClientControllerTests
    {
        [Test]
        public async Task CreateClient_SuccessfullyAddsClientToDb()
        {
            var context = TestDbBank.CreateContext();
            ClientController clientController = new ClientController(context);

            var newClient = new Client
            {
                FirstName = "Иван",
                LastName = "Иванов",
                EGN = "9001011234",
                Phone = "0888123456",
                Email = "ivan@test.com",
                Accounts = new List<Account>()
            };

            await clientController.CreateClient(newClient);

            var dbClient = await context.Clients.FirstOrDefaultAsync(c => c.EGN == "9001011234");
            Assert.IsNotNull(dbClient);
            Assert.AreEqual("Иван", dbClient.FirstName);
            Assert.AreEqual("ivan@test.com", dbClient.Email);
        }

        [Test]
        public void CreateClient_ThrowsArgumentException_WhenFirstNameIsInvalid()
        {
            var context = TestDbBank.CreateContext();
            ClientController clientController = new ClientController(context);

            var newClient = new Client
            {
                FirstName = "Иван123",
                LastName = "Иванов",
                EGN = "9001011234",
                Phone = "0888123456",
                Email = "ivan@test.com"
            };

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await clientController.CreateClient(newClient));
            Assert.AreEqual("Първото име не може да бъде празно и не трябва да съдържа цифри или специални символи.", ex?.Message);
        }

        [Test]
        public void CreateClient_ThrowsArgumentException_WhenPhoneIsInvalid()
        {
            var context = TestDbBank.CreateContext();
            ClientController clientController = new ClientController(context);

            var newClient = new Client
            {
                FirstName = "Иван",
                LastName = "Иванов",
                EGN = "9001011234",
                Phone = "123",
                Email = "ivan@test.com"
            };

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await clientController.CreateClient(newClient));
            Assert.AreEqual("Телефонният номер е невалиден. Трябва да съдържа между 9 и 14 цифри (може да започва с +).", ex?.Message);
        }

        [Test]
        public void CreateClient_ThrowsArgumentException_WhenEgnIsShort()
        {
            var context = TestDbBank.CreateContext();
            ClientController clientController = new ClientController(context);

            var newClient = new Client
            {
                FirstName = "Иван",
                LastName = "Иванов",
                EGN = "12345",
                Phone = "0888123456",
                Email = "ivan@test.com"
            };

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await clientController.CreateClient(newClient));
            Assert.AreEqual("ЕГН-то трябва да се състои от точно 10 цифри.", ex?.Message);
        }

        [Test]
        public async Task CreateClient_ThrowsInvalidOperationException_WhenEgnAlreadyExists()
        {
            var context = TestDbBank.CreateContext();
            context.Clients.Add(new Client { FirstName = "Петър", LastName = "Петров", EGN = "9001011234", Phone = "0888111222", Email = "p@test.com" });
            await context.SaveChangesAsync();

            ClientController clientController = new ClientController(context);

            var newClient = new Client
            {
                FirstName = "Иван",
                LastName = "Иванов",
                EGN = "9001011234",
                Phone = "0888123456",
                Email = "ivan@test.com"
            };

            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await clientController.CreateClient(newClient));
            Assert.AreEqual("Клиент с това ЕГН вече е регистриран в системата.", ex?.Message);
        }

        [Test]
        public async Task GetAllClients_ReturnsAllClientsInDatabase()
        {
            var context = TestDbBank.CreateContext();

            context.Clients.Add(new Client { FirstName = "Петър", LastName = "Петров", EGN = "8802021111", Phone = "0888111222", Email = "p@test.com", Accounts = new List<Account>() });
            context.Clients.Add(new Client { FirstName = "Георги", LastName = "Георгиев", EGN = "8503032222", Phone = "0888333444", Email = "g@test.com", Accounts = new List<Account>() });
            await context.SaveChangesAsync();

            ClientController clientController = new ClientController(context);

            List<Client> clients = await clientController.GetAllClients();

            Assert.IsNotNull(clients);
            Assert.IsTrue(clients.Count >= 2);
        }

        [Test]
        public async Task GetClientByEgn_ExistingEgn_ReturnsCorrectClient()
        {
            var context = TestDbBank.CreateContext();

            string targetEgn = "9505055555";
            context.Clients.Add(new Client
            {
                FirstName = "Мария",
                LastName = "Тонева",
                EGN = targetEgn,
                Phone = "0877123123",
                Email = "m@test.com",
                Accounts = new List<Account>()
            });
            await context.SaveChangesAsync();

            ClientController clientController = new ClientController(context);

            Client result = await clientController.GetClientByEgn(targetEgn);

            Assert.IsNotNull(result);
            Assert.AreEqual("Мария", result.FirstName);
            Assert.AreEqual(targetEgn, result.EGN);
            Assert.IsNotNull(result.Accounts);
        }

        [Test]
        public async Task SearchClientByName_MatchingSearchTerm_ReturnsFilteredList()
        {
            var context = TestDbBank.CreateContext();

            context.Clients.Add(new Client { FirstName = "Александър", LastName = "Димитров", EGN = "9101010000", Phone = "0899111111", Email = "al@test.com", Accounts = new List<Account>() });
            context.Clients.Add(new Client { FirstName = "Елена", LastName = "Александрова", EGN = "9202020000", Phone = "0899222222", Email = "el@test.com", Accounts = new List<Account>() });
            context.Clients.Add(new Client { FirstName = "Стефан", LastName = "Попов", EGN = "9303030000", Phone = "0899333333", Email = "st@test.com", Accounts = new List<Account>() });
            await context.SaveChangesAsync();

            ClientController clientController = new ClientController(context);

            List<Client> results = await clientController.SearchClientByName("Алекс");

            Assert.IsNotNull(results);
            Assert.AreEqual(2, results.Count);
        }

        [Test]
        public async Task UpdateClient_UpdatesFieldsCorrectly()
        {
            var context = TestDbBank.CreateContext();

            var existingClient = new Client
            {
                FirstName = "Николай",
                LastName = "Колев",
                EGN = "7908087777",
                Phone = "0888999999",
                Email = "nik@test.com",
                Accounts = new List<Account>()
            };
            context.Clients.Add(existingClient);
            await context.SaveChangesAsync();

            ClientController clientController = new ClientController(context);

            existingClient.FirstName = "Ники";
            existingClient.LastName = "Колев";
            existingClient.Phone = "0877777777";

            await clientController.UpdateClient(existingClient);

            var updatedDbClient = await context.Clients.FindAsync(existingClient.ClientID);
            Assert.IsNotNull(updatedDbClient);
            Assert.AreEqual("Ники", updatedDbClient.FirstName);
            Assert.AreEqual("Колев", updatedDbClient.LastName);
            Assert.AreEqual("0877777777", updatedDbClient.Phone);
        }

        [Test]
        public void UpdateClient_ThrowsException_WhenClientDoesNotExist()
        {
            var context = TestDbBank.CreateContext();
            ClientController clientController = new ClientController(context);

            var nonExistingClient = new Client
            {
                ClientID = 999,
                FirstName = "Ники",
                LastName = "Колев",
                EGN = "7908087777",
                Phone = "0877777777",
                Email = "nik@test.com"
            };

            var ex = Assert.ThrowsAsync<Exception>(async () => await clientController.UpdateClient(nonExistingClient));
            Assert.AreEqual("Клиентът не е намерен в базата данни.", ex?.Message);
        }

        [Test]
        public async Task DeleteClient_RemovesClientCorrectly_WhenHasNoAccounts()
        {
            var context = TestDbBank.CreateContext();

            var clientToDelete = new Client
            {
                FirstName = "Излишен",
                LastName = "Клиент",
                EGN = "0000000000",
                Phone = "0888111222",
                Email = "del@test.com",
                Accounts = new List<Account>()
            };
            context.Clients.Add(clientToDelete);
            await context.SaveChangesAsync();

            int targetId = clientToDelete.ClientID;

            ClientController clientController = new ClientController(context);

            await clientController.DeleteClient(targetId);

            var dbClient = await context.Clients.FindAsync(targetId);
            Assert.IsNull(dbClient);
        }

        [Test]
        public async Task DeleteClient_ThrowsInvalidOperationException_WhenClientHasAccounts()
        {
            var context = TestDbBank.CreateContext();

            var client = new Client
            {
                FirstName = "Активен",
                LastName = "Клиент",
                EGN = "1111111111",
                Phone = "0888111222",
                Email = "active@test.com"
            };
            context.Clients.Add(client);
            await context.SaveChangesAsync();

            context.Accounts.Add(new Account { IBAN = "BG98BNKB1111", Balance = 0.0m, Currency = "EUR", ClientID = client.ClientID });
            await context.SaveChangesAsync();

            ClientController clientController = new ClientController(context);

            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await clientController.DeleteClient(client.ClientID));
            Assert.AreEqual("Не може да изтриете клиент, който има активни банкови сметки. Първо закрийте сметките му.", ex?.Message);
        }
    }
}

