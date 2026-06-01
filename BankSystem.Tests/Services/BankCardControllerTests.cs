using BankSystem.Controller;
using BankSystem.Data.Entities;
using BankSystem.Data.Enums;
using BankSystem.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Tests.Services
{
    public class BankCardControllerTests
    {
        [Test]
        public async Task CreateBankCard_SuccessfullyAddsCardToDb()
        {
            var context = TestDbBank.CreateContext();
            BankCardController cardController = new BankCardController(context);

            var newCard = new BankCard
            {
                CardNumber = "1234567890123456",
                CardType = CardType.DebitVisa,
                ExpiryDate = "12/28",
                CVV = "123",
                AccountID = 1
            };

            await cardController.CreateBankCard(newCard);

            var dbCard = await context.BankCards.FirstOrDefaultAsync(bc => bc.CardNumber == "1234567890123456");
            Assert.IsNotNull(dbCard);
            Assert.AreEqual(CardType.DebitVisa, dbCard.CardType);
            Assert.AreEqual("123", dbCard.CVV);
            Assert.AreEqual(1, dbCard.AccountID);
        }

        [Test]
        public async Task GetCardsByAccount_ReturnsOnlyCardsForSpecificAccount()
        {
            var context = TestDbBank.CreateContext();

            context.BankCards.Add(new BankCard { CardNumber = "1111", CardType = CardType.DebitVisa, ExpiryDate = "12/27", CVV = "111", AccountID = 5 });
            context.BankCards.Add(new BankCard { CardNumber = "2222", CardType = CardType.CreditMasterCard, ExpiryDate = "05/26", CVV = "222", AccountID = 5 });
            context.BankCards.Add(new BankCard { CardNumber = "3333", CardType = CardType.DebitMasterCard, ExpiryDate = "01/29", CVV = "333", AccountID = 9 });
            await context.SaveChangesAsync();

            BankCardController cardController = new BankCardController(context);

            List<BankCard> cards = await cardController.GetCardsByAccount(5);

            Assert.IsNotNull(cards);
            Assert.AreEqual(2, cards.Count);
            Assert.IsTrue(cards.TrueForAll(c => c.AccountID == 5));
        }

        [Test]
        public async Task DeleteBankCard_RemovesCardCorrectly()
        {
            var context = TestDbBank.CreateContext();

            var cardToDelete = new BankCard
            {
                CardNumber = "9999999999999999",
                CardType = CardType.CreditVisa,
                ExpiryDate = "09/27",
                CVV = "999",
                AccountID = 2
            };
            context.BankCards.Add(cardToDelete);
            await context.SaveChangesAsync();

            int targetId = cardToDelete.CardID;

            BankCardController cardController = new BankCardController(context);

            await cardController.DeleteBankCard(targetId);

            var dbCard = await context.BankCards.FindAsync(targetId);
            Assert.IsNull(dbCard);
        }
    }
}
