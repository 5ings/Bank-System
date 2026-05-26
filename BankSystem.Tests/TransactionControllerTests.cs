using BankSystem.Controller;
using BankSystem.Data;
using BankSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Tests;

public class TransactionControllerTests
{
    private TransactionController _transactionController;
    private int _tempClientId;
    private int _sourceAccountId;
    private int _targetAccountId;
    private string _sourceIban = "BG11TX";
    private string _targetIban = "BG22TX";

    [SetUp]
    public async Task Setup()
    {
        _transactionController = new TransactionController();

        using (var context = new BankDbContext())
        {
            var tempClient = new Client
            {
                FirstName = "Тест",
                LastName = "Потребител",
                EGN = "0000000000", 
                Phone = "0888888888",
                Email = "test_mail_" + Guid.NewGuid().ToString().Substring(0, 5) + "@test.com"
            };

            context.Clients.Add(tempClient);
            await context.SaveChangesAsync();
            _tempClientId = tempClient.ClientID;

            var sourceAcc = new Account { IBAN = _sourceIban, Balance = 500.00m, Currency = "BGN", ClientID = _tempClientId };
            var targetAcc = new Account { IBAN = _targetIban, Balance = 100.00m, Currency = "BGN", ClientID = _tempClientId };

            context.Accounts.Add(sourceAcc);
            context.Accounts.Add(targetAcc);
            await context.SaveChangesAsync();

            _sourceAccountId = sourceAcc.AccountID;
            _targetAccountId = targetAcc.AccountID;
        }
    }

    [TearDown]
    public async Task TearDown()
    {
        using (var context = new BankDbContext())
        {
            var transactions = await context.Transactions
                .Where(t => t.AccountID == _sourceAccountId || t.AccountID == _targetAccountId)
                .ToListAsync();
            context.Transactions.RemoveRange(transactions);

            var source = await context.Accounts.FindAsync(_sourceAccountId);
            var target = await context.Accounts.FindAsync(_targetAccountId);
            if (source != null) context.Accounts.Remove(source);
            if (target != null) context.Accounts.Remove(target);

            var client = await context.Clients.FindAsync(_tempClientId);
            if (client != null) context.Clients.Remove(client);

            await context.SaveChangesAsync();
        }
    }


    [Test]
    public async Task DepositMoney_ValidAmount_ShouldIncreaseBalanceAndAddTransaction()
    {
        await _transactionController.DepositMoney(_sourceAccountId, 150.00m);

        using (var context = new BankDbContext())
        {
            var account = await context.Accounts.FindAsync(_sourceAccountId);
            Assert.AreEqual(650.00m, account.Balance, "Депозираната сума не се добави към баланса!");

            var tx = await context.Transactions.FirstOrDefaultAsync(t => t.AccountID == _sourceAccountId && t.TransactionType == "Депозит");
            Assert.IsNotNull(tx, "Не беше генериран запис за транзакцията в таблицата!");
            Assert.AreEqual(150.00m, tx.Amount);
        }
    }

    [Test]
    public void DepositMoney_NegativeAmount_ShouldThrowArgumentException()
    {
        var ex = Assert.ThrowsAsync<ArgumentException>(async () =>
            await _transactionController.DepositMoney(_sourceAccountId, -50.00m));

        Assert.AreEqual("Внесената сума трябва да е по-голяма от 0 лв.", ex.Message);
    }


    [Test]
    public async Task WithdrawMoney_WithSufficientBalance_ShouldDecreaseBalance()
    {
        await _transactionController.WithdrawMoney(_sourceAccountId, 200.00m);

        using (var context = new BankDbContext())
        {
            var account = await context.Accounts.FindAsync(_sourceAccountId);
            Assert.AreEqual(300.00m, account.Balance, "Сумата не беше изтеглена правилно!");
        }
    }

    [Test]
    public void WithdrawMoney_InsufficientBalance_ShouldThrowException()
    {
        var ex = Assert.ThrowsAsync<Exception>(async () =>
            await _transactionController.WithdrawMoney(_sourceAccountId, 9999.00m));

        Assert.IsTrue(ex.Message.Contains("Недостатъчна наличност!"));
    }


    [Test]
    public async Task TransferMoney_ValidExecution_ShouldModifyBothBalances()
    {
        await _transactionController.TransferMoney(_sourceAccountId, _targetIban, 200.00m);

        using (var context = new BankDbContext())
        {
            var source = await context.Accounts.FindAsync(_sourceAccountId);
            var target = await context.Accounts.FindAsync(_targetAccountId);

            Assert.AreEqual(300.00m, source.Balance, "Балансът на изпращача не беше намален!");
            Assert.AreEqual(300.00m, target.Balance, "Балансът на получателя не беше увеличен!");

            var sourceTx = await context.Transactions.FirstOrDefaultAsync(t => t.AccountID == _sourceAccountId && t.Amount == -200.00m);
            var targetTx = await context.Transactions.FirstOrDefaultAsync(t => t.AccountID == _targetAccountId && t.Amount == 200.00m);

            Assert.IsNotNull(sourceTx);
            Assert.IsNotNull(targetTx);
        }
    }

    [Test]
    public void TransferMoney_ToSameAccount_ShouldThrowInvalidOperationException()
    {
        var ex = Assert.ThrowsAsync<InvalidOperationException>(async () =>
            await _transactionController.TransferMoney(_sourceAccountId, _sourceIban, 50.00m));

        Assert.AreEqual("Не можете да правите превод към същата сметка!", ex.Message);
    }

    [Test]
    public async Task GetAccountByIban_ExistingIban_ShouldReturnCorrectAccount()
    {
        Account acc = await _transactionController.GetAccountByIban(_sourceIban);

        Assert.IsNotNull(acc);
        Assert.AreEqual(_sourceAccountId, acc.AccountID);
    }

    [Test]
    public async Task GetHistoryByAccount_ShouldReturnTransactionsOrdered()
    {
        await _transactionController.DepositMoney(_sourceAccountId, 10.00m);
        await _transactionController.DepositMoney(_sourceAccountId, 20.00m);

        List<BankSystem.Data.Entities.Transaction> history = await _transactionController.GetHistoryByAccount(_sourceAccountId);

        Assert.IsNotNull(history);
        Assert.IsTrue(history.Count >= 2);
    }
}
