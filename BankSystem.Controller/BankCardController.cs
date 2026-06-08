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
    public class BankCardController
    {
        public BankDbContext Context { get; set; }

        public BankCardController()
        {
            Context = new BankDbContext();
        }

        public BankCardController(BankDbContext context)
        {
            Context = context;
        }

        public async Task CreateBankCard(BankCard card)
        {
            var accountExists = await Context.Accounts.AnyAsync(a => a.AccountID == card.AccountID);
            if (!accountExists)
            {
                throw new Exception("Не може да се издаде карта на несъществуваща банкова сметка.");
            }

            Random random = new Random();

            string generatedCardNumber;
            bool isUnique = false;
            int attempts = 0;

            do
            {
                StringBuilder sb = new StringBuilder();

                if (card.CardType.ToString().ToLower().Contains("visa"))
                {
                    sb.Append("4");
                }
                else
                {
                    sb.Append("5");
                }

                for (int i = 0; i < 15; i++)
                {
                    sb.Append(random.Next(0, 10));
                }
                generatedCardNumber = sb.ToString();

                var cardExists = await Context.BankCards.AnyAsync(bc => bc.CardNumber == generatedCardNumber);
                if (!cardExists)
                {
                    isUnique = true;
                }

                attempts++;
                if (attempts > 10) throw new Exception("Грешка при генериране на уникален номер на карта. Моля, опитайте отново.");

            } while (!isUnique);

            card.CardNumber = generatedCardNumber;

            card.CVV = random.Next(100, 1000).ToString();

            card.ExpiryDate = DateTime.Now.AddYears(3).ToString("MM/yy");

            await Context.BankCards.AddAsync(card);
            await Context.SaveChangesAsync();
        }

        public async Task<List<BankCard>> GetCardsByAccount(int accountId)
        {
            return await Context.BankCards
                .Where(bc => bc.AccountID == accountId)
                .ToListAsync();
        }

        public async Task DeleteBankCard(int cardId)
        {
            var card = await Context.BankCards.FirstOrDefaultAsync(bc => bc.CardID == cardId);
            if (card != null)
            {
                Context.BankCards.Remove(card);
                await Context.SaveChangesAsync();
            }
        }
    }
}
