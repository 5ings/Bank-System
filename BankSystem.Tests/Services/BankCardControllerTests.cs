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
        public async Task CreateBankCard_SuccessfullyAddsVisaCardToDb_WithGeneratedFields()
        {
            var context = TestDbBank.CreateContext();
            var account = new Account { AccountID = 1, IBAN = "BG98BNKB11111111111111", Balance = 100.0m, Currency = "EUR", ClientID = 1 };
            context.Accounts.Add(account);
            await context.SaveChangesAsync();

            BankCardController cardController = new BankCardController(context);

            var newCard = new BankCard
            {
                CardType = CardType.DebitVisa,
                AccountID = 1
            };

            await cardController.CreateBankCard(newCard);

            var dbCard = await context.BankCards.FirstOrDefaultAsync(bc => bc.AccountID == 1);

            Assert.IsNotNull(dbCard);
            Assert.IsFalse(string.IsNullOrEmpty(dbCard.CardNumber));
            Assert.IsTrue(dbCard.CardNumber.StartsWith("4"));
            Assert.AreEqual(16, dbCard.CardNumber.Length);
            Assert.IsFalse(string.IsNullOrEmpty(dbCard.CVV));
            Assert.AreEqual(3, dbCard.CVV.Length);
            Assert.IsFalse(string.IsNullOrEmpty(dbCard.ExpiryDate));
            Assert.AreEqual(CardType.DebitVisa, dbCard.CardType);
            Assert.AreEqual(1, dbCard.AccountID);
        }

        [Test]
        public async Task CreateBankCard_SuccessfullyAddsMasterCardToDb_WithGeneratedFields()
        {
            var context = TestDbBank.CreateContext();
            var account = new Account { AccountID = 2, IBAN = "BG98BNKB22222222222222", Balance = 200.0m, Currency = "USD", ClientID = 1 };
            context.Accounts.Add(account);
            await context.SaveChangesAsync();

            BankCardController cardController = new BankCardController(context);

            var newCard = new BankCard
            {
                CardType = CardType.DebitMasterCard,
                AccountID = 2
            };

            await cardController.CreateBankCard(newCard);

            var dbCard = await context.BankCards.FirstOrDefaultAsync(bc => bc.AccountID == 2);

            Assert.IsNotNull(dbCard);
            Assert.IsTrue(dbCard.CardNumber.StartsWith("5"));
            Assert.AreEqual(16, dbCard.CardNumber.Length);
            Assert.AreEqual(CardType.DebitMasterCard, dbCard.CardType);
        }

        [Test]
        public void CreateBankCard_ThrowsException_WhenAccountDoesNotExist()
        {
            var context = TestDbBank.CreateContext();
            BankCardController cardController = new BankCardController(context);

            var newCard = new BankCard
            {
                CardType = CardType.DebitVisa,
                AccountID = 999
            };

            var ex = Assert.ThrowsAsync<Exception>(async () => await cardController.CreateBankCard(newCard));
            Assert.AreEqual("Не може да се издаде карта на несъществуваща банкова сметка.", ex?.Message);
        }

        [Test]
        public async Task GetCardsByAccount_ReturnsOnlyCardsForSpecificAccount()
        {
            var context = TestDbBank.CreateContext();

            context.BankCards.Add(new BankCard { CardNumber = "4111111111111111", CardType = CardType.DebitVisa, ExpiryDate = "12/27", CVV = "111", AccountID = 5 });
            context.BankCards.Add(new BankCard { CardNumber = "5222222222222222", CardType = CardType.CreditMasterCard, ExpiryDate = "05/26", CVV = "222", AccountID = 5 });
            context.BankCards.Add(new BankCard { CardNumber = "5333333333333333", CardType = CardType.DebitMasterCard, ExpiryDate = "01/29", CVV = "333", AccountID = 9 });
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
                CardNumber = "4999999999999999",
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
