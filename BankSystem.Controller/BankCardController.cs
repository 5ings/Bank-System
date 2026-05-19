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
        public async Task CreateBankCard(BankCard card)
        {
            using (BankDbContext context = new BankDbContext())
            {
                await context.BankCards.AddAsync(card);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<BankCard>> GetCardsByAccount(int accountId)
        {
            using (BankDbContext context = new BankDbContext())
            {
                return await context.BankCards
                    .Where(bc => bc.AccountID == accountId)
                    .ToListAsync();
            }
        }

        public async Task DeleteBankCard(int cardId)
        {
            using (BankDbContext context = new BankDbContext())
            {
                var card = await context.BankCards.FirstOrDefaultAsync(bc => bc.CardID == cardId);
                if (card != null)
                {
                    context.BankCards.Remove(card);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
