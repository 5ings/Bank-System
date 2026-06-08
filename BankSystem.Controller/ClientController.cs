using BankSystem.Data;
using BankSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankSystem.Controller
{
    public class ClientController
    {
        public BankDbContext Context { get; set; }

        public ClientController()
        {
            Context = new BankDbContext();
        }

        public ClientController(BankDbContext context)
        {
            Context = context;
        }

        private void ValidateClientData(Client client)
        {
            if (client == null) throw new ArgumentNullException(nameof(client), "Данните за клиента липсват.");

            var nameRegex = new Regex(@"^[a-zA-Zа-яА-ЯабвгдежзийклмнопрстуфхцчшщъьюяАБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЬЮЯ\s-]+$");

            if (string.IsNullOrWhiteSpace(client.FirstName) || !nameRegex.IsMatch(client.FirstName))
            {
                throw new ArgumentException("Първото име не може да бъде празно и не трябва да съдържа цифри или специални символи.");
            }

            if (string.IsNullOrWhiteSpace(client.LastName) || !nameRegex.IsMatch(client.LastName))
            {
                throw new ArgumentException("Фамилното име не може да бъде празно и не трябва да съдържа цифри или специални символи.");
            }

            var phoneRegex = new Regex(@"^\+?[0-9]{9,14}$");
            if (string.IsNullOrWhiteSpace(client.Phone) || !phoneRegex.IsMatch(client.Phone))
            {
                throw new ArgumentException("Телефонният номер е невалиден. Трябва да съдържа между 9 и 14 цифри (може да започва с +).");
            }
        }

        private void ValidateEgn(string egn)
        {
            if (string.IsNullOrWhiteSpace(egn))
            {
                throw new ArgumentException("ЕГН не може да бъде празно.");
            }

            var egnRegex = new Regex(@"^[0-9]{10}$");
            if (!egnRegex.IsMatch(egn))
            {
                throw new ArgumentException("ЕГН-то трябва да се състои от точно 10 цифри.");
            }
        }

        public async Task CreateClient(Client client)
        {
            ValidateClientData(client);

            ValidateEgn(client.EGN);

            var egnExists = await Context.Clients.AnyAsync(c => c.EGN == client.EGN);
            if (egnExists)
            {
                throw new InvalidOperationException("Клиент с това ЕГН вече е регистриран в системата.");
            }

            await Context.Clients.AddAsync(client);
            await Context.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await Context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientByEgn(string egn)
        {
            ValidateEgn(egn);
            return await Context.Clients
                .AsNoTracking()
                .Include(c => c.Accounts)
                .FirstOrDefaultAsync(c => c.EGN == egn);
        }

        public async Task<List<Client>> SearchClientByName(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await GetAllClients();
            }

            string cleanSearch = searchTerm.Trim();

            return await Context.Clients
                .Where(c => c.FirstName.Contains(cleanSearch) || c.LastName.Contains(cleanSearch))
                .ToListAsync();
        }

        public async Task UpdateClient(Client updatedClient)
        {
            ValidateClientData(updatedClient);

            var existing = await Context.Clients.FirstOrDefaultAsync(c => c.ClientID == updatedClient.ClientID);
            if (existing == null)
            {
                throw new Exception("Клиентът не е намерен в базата данни.");
            }

            existing.FirstName = updatedClient.FirstName.Trim();
            existing.LastName = updatedClient.LastName.Trim();
            existing.Phone = updatedClient.Phone.Trim();


            await Context.SaveChangesAsync();
        }

        public async Task DeleteClient(int clientId)
        {
            var client = await Context.Clients
                .Include(c => c.Accounts)
                .FirstOrDefaultAsync(c => c.ClientID == clientId);

            if (client != null)
            {
                if (client.Accounts != null && client.Accounts.Any())
                {
                    throw new InvalidOperationException("Не може да изтриете клиент, който има активни банкови сметки. Първо закрийте сметките му.");
                }

                Context.Clients.Remove(client);
                await Context.SaveChangesAsync();
            }
        }
    }
}
