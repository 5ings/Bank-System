using BankSystem.Data;
using BankSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Controller
{
    public class ClientController
    {
        public async Task CreateClient(Client client)
        {
            using (BankDbContext context = new BankDbContext())
            {
                await context.Clients.AddAsync(client);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Client>> GetAllClients()
        {
            using (BankDbContext context = new BankDbContext())
            {
                return await context.Clients.ToListAsync();
            }
        }

        public async Task<Client> GetClientByEgn(string egn)
        {
            using (BankDbContext context = new BankDbContext())
            {
                return await context.Clients
                    .Include(c => c.Accounts)
                    .FirstOrDefaultAsync(c => c.EGN == egn);
            }
        }

        public async Task<List<Client>> SearchClientByName(string searchTerm)
        {
            using (BankDbContext context = new BankDbContext())
            {
                return await context.Clients
                    .Where(c => c.FirstName.Contains(searchTerm) || c.LastName.Contains(searchTerm))
                    .ToListAsync();
            }
        }
        public async Task UpdateClient(Client updatedClient)
        {
            using (BankDbContext context = new BankDbContext())
            {
                var existing = await context.Clients.FirstOrDefaultAsync(c => c.ClientID == updatedClient.ClientID);
                if (existing != null)
                {
                    existing.FirstName = updatedClient.FirstName;
                    existing.LastName = updatedClient.LastName;
                    existing.Phone = updatedClient.Phone;
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteClient(int clientId)
        {
            using (BankDbContext context = new BankDbContext())
            {
                var client = await context.Clients.FirstOrDefaultAsync(c => c.ClientID == clientId);
                if (client != null)
                {
                    context.Clients.Remove(client);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
