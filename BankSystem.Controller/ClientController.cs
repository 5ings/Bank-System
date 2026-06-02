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
        public BankDbContext Context { get; set; }

        public ClientController()
        {
            Context = new BankDbContext();
        }

        public ClientController(BankDbContext context)
        {
            Context = context;
        }

        public async Task CreateClient(Client client)
        {
            await Context.Clients.AddAsync(client);
            await Context.SaveChangesAsync();
        }

        public async Task<List<Client>> GetAllClients()
        {
            return await Context.Clients.ToListAsync();
        }

        public async Task<Client> GetClientByEgn(string egn)
        {
            return await Context.Clients
                .AsNoTracking()
                .Include(c => c.Accounts)
                .FirstOrDefaultAsync(c => c.EGN == egn);
        }

        public async Task<List<Client>> SearchClientByName(string searchTerm)
        {
            return await Context.Clients
                .Where(c => c.FirstName.Contains(searchTerm) || c.LastName.Contains(searchTerm))
                .ToListAsync();
        }

        public async Task UpdateClient(Client updatedClient)
        {
            var existing = await Context.Clients.FirstOrDefaultAsync(c => c.ClientID == updatedClient.ClientID);
            if (existing != null)
            {
                existing.FirstName = updatedClient.FirstName;
                existing.LastName = updatedClient.LastName;
                existing.Phone = updatedClient.Phone;
                await Context.SaveChangesAsync();
            }
        }

        public async Task DeleteClient(int clientId)
        {
            var client = await Context.Clients.FirstOrDefaultAsync(c => c.ClientID == clientId);
            if (client != null)
            {
                Context.Clients.Remove(client);
                await Context.SaveChangesAsync();
            }
        }
    }
}
