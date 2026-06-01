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
    public class AccountController
    {
        public BankDbContext Context { get; set; }

        public AccountController()
        {
            Context = new BankDbContext();
        }

        public AccountController(BankDbContext context)
        {
            Context = context;
        }

        public async Task CreateAccount(Account account)
        {
            await Context.Accounts.AddAsync(account);
            await Context.SaveChangesAsync();
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            return await Context.Accounts.Include(a => a.Client).ToListAsync();
        }

        public async Task<List<Account>> GetAccountsByClient(int clientId)
        {
            return await Context.Accounts
                .Where(a => a.ClientID == clientId)
                .ToListAsync();
        }

        public async Task DeleteAccount(int accountId)
        {
            var account = await Context.Accounts.FirstOrDefaultAsync(a => a.AccountID == accountId);
            if (account != null)
            {
                Context.Accounts.Remove(account);
                await Context.SaveChangesAsync();
            }
        }
    }
}

