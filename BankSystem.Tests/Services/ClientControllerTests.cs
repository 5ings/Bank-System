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
            existingClient.LastName = "Колев - Обновен";
            existingClient.Phone = "0877777777";

            await clientController.UpdateClient(existingClient);

            var updatedDbClient = await context.Clients.FindAsync(existingClient.ClientID);
            Assert.IsNotNull(updatedDbClient);
            Assert.AreEqual("Ники", updatedDbClient.FirstName);
            Assert.AreEqual("Колев - Обновен", updatedDbClient.LastName);
            Assert.AreEqual("0877777777", updatedDbClient.Phone);
        }

        [Test]
        public async Task DeleteClient_RemovesClientCorrectly()
        {
            var context = TestDbBank.CreateContext();

            var clientToDelete = new Client
            {
                FirstName = "Излишен",
                LastName = "Клиент",
                EGN = "0000000000",
                Phone = "0000",
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
    }
}

