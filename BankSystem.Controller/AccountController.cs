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
        public async Task CreateAccount(Account account)
        {
            using (BankDbContext context = new BankDbContext())
            {
                await context.Accounts.AddAsync(account);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            using (BankDbContext context = new BankDbContext())
            {
                return await context.Accounts.Include(a => a.Client).ToListAsync();
            }
        }

        public async Task<List<Account>> GetAccountsByClient(int clientId)
        {
            using (BankDbContext context = new BankDbContext())
            {
                return await context.Accounts
                    .Where(a => a.ClientID == clientId)
                    .ToListAsync();
            }
        }

        public async Task DeleteAccount(int accountId)
        {
            using (BankDbContext context = new BankDbContext())
            {
                var account = await context.Accounts.FirstOrDefaultAsync(a => a.AccountID == accountId);
                if (account != null)
                {
                    context.Accounts.Remove(account);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}

