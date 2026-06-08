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
            var clientExists = await Context.Clients.AnyAsync(c => c.ClientID == account.ClientID);
            if (!clientExists)
            {
                throw new Exception("Не може да се открие сметка на несъществуващ клиент.");
            }

            if (account.Balance < 0)
            {
                throw new ArgumentException("Първоначалният баланс на сметката не може да бъде отрицателно число.");
            }

            if (string.IsNullOrWhiteSpace(account.Currency))
            {
                throw new ArgumentException("Трябва да посочите валута (напр. BGN, EUR, USD).");
            }

            account.Currency = account.Currency.Trim().ToUpper();
            var allowedCurrencies = new[] { "BGN", "EUR", "USD" };
            if (!allowedCurrencies.Contains(account.Currency))
            {
                throw new ArgumentException($"Валутата {account.Currency} не се поддържа от системата. Изберете BGN, EUR или USD.");
            }

            Random random = new Random();
            string generatedIban;
            bool isUnique = false;
            int attempts = 0;

            do
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("BG98BNKB");

                for (int i = 0; i < 14; i++)
                {
                    sb.Append(random.Next(0, 10));
                }
                generatedIban = sb.ToString();

                var ibanExists = await Context.Accounts.AnyAsync(a => a.IBAN == generatedIban);
                if (!ibanExists)
                {
                    isUnique = true;
                }

                attempts++;
                if (attempts > 10) throw new Exception("Грешка при генериране на уникален IBAN. Моля, опитайте отново.");

            } while (!isUnique);

            account.IBAN = generatedIban;

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
            var account = await Context.Accounts
                .Include(a => a.BankCards)
                .FirstOrDefaultAsync(a => a.AccountID == accountId);

            if (account != null)
            {
                if (account.Balance > 0)
                {
                    throw new InvalidOperationException($"Сметката не може да бъде закрита, тъй като в нея има наличност от {account.Balance:F2} {account.Currency}. Първо изтеглете или прехвърлете сумата.");
                }

                if (account.BankCards != null && account.BankCards.Any())
                {
                    throw new InvalidOperationException("Сметката има активни банкови карти. Първо изтрийте/анулирайте картите, свързани с нея.");
                }

                Context.Accounts.Remove(account);
                await Context.SaveChangesAsync();
            }
        }
    }
}

