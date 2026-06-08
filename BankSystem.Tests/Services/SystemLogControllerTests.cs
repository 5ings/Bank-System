using BankSystem.Controller;
using BankSystem.Data;
using BankSystem.Data.Entities;
using BankSystem.Tests.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace BankSystem.Tests.Services;

public class SystemLogControllerTests
{

    [Test]
    public async Task LogAction_SuccessfullySavesLogToDatabase()
    {
        var context = TestDbBank.CreateContext();
        SystemLogController logController = new SystemLogController(context);

        int testUserId = 5;
        string testAction = "Потребителят влезе в системата.";

        await logController.LogAction(testUserId, testAction);

        var savedLog = await context.SystemLogs.FirstOrDefaultAsync(l => l.UserID == testUserId);

        Assert.IsNotNull(savedLog);
        Assert.AreEqual(testAction, savedLog.Action);
        Assert.IsNotNull(savedLog.LogDate);
    }

    [Test]
    public void LogAction_ThrowsArgumentException_WhenUserIdIsZeroOrNegative()
    {
        var context = TestDbBank.CreateContext();
        SystemLogController logController = new SystemLogController(context);

        var ex = Assert.ThrowsAsync<ArgumentException>(async () => await logController.LogAction(0, "Някакво действие"));
        Assert.AreEqual("Невалидно потребителско ID за запис в системния лог.", ex?.Message);
    }

    [Test]
    public void LogAction_ThrowsArgumentException_WhenActionDescriptionIsEmpty()
    {
        var context = TestDbBank.CreateContext();
        SystemLogController logController = new SystemLogController(context);

        var ex = Assert.ThrowsAsync<ArgumentException>(async () => await logController.LogAction(1, "   "));
        Assert.AreEqual("Описанието на системното действие не може да бъде празно.", ex?.Message);
    }

    [Test]
    public async Task LogAction_TrimsAndTruncatesDescription_WhenLengthIsOver500()
    {
        var context = TestDbBank.CreateContext();
        SystemLogController logController = new SystemLogController(context);

        string longAction = new string('A', 510);

        await logController.LogAction(1, longAction);

        var savedLog = await context.SystemLogs.FirstOrDefaultAsync(l => l.UserID == 1);

        Assert.IsNotNull(savedLog);
        Assert.AreEqual(500, savedLog.Action.Length);
        Assert.IsTrue(savedLog.Action.EndsWith("..."));
    }

    [Test]
    public async Task GetAllLogs_ReturnsLogsOrderedByDateDescending()
    {
        var context = TestDbBank.CreateContext();

        var user = new User { UserID = 1, Username = "admin", PasswordHash = "123", Role = Data.Enums.UserRole.Admin };
        context.Users.Add(user);
        await context.SaveChangesAsync();

        context.SystemLogs.Add(new SystemLog { UserID = 1, Action = "Старо действие", LogDate = DateTime.Now.AddMinutes(-10), User = user });
        context.SystemLogs.Add(new SystemLog { UserID = 1, Action = "Ново действие", LogDate = DateTime.Now, User = user });
        await context.SaveChangesAsync();

        context.ChangeTracker.Clear();

        SystemLogController logController = new SystemLogController(context);

        List<SystemLog> logs = await logController.GetAllLogs();

        Assert.IsNotNull(logs);
        Assert.AreEqual(2, logs.Count);
        Assert.AreEqual("Ново действие", logs[0].Action);
        Assert.AreEqual("Старо действие", logs[1].Action);
        Assert.IsNotNull(logs[0].User);
    }

}
