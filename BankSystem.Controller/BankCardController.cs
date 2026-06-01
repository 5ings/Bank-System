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
