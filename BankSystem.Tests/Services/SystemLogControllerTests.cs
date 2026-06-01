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
    public async Task GetAllLogs_ReturnsLogsOrderedByDateDescending()
    {
        var context = TestDbBank.CreateContext();

        context.SystemLogs.Add(new SystemLog { UserID = 1, Action = "Старо действие", LogDate = DateTime.Now.AddMinutes(-10) });
        context.SystemLogs.Add(new SystemLog { UserID = 1, Action = "Ново действие", LogDate = DateTime.Now });
        await context.SaveChangesAsync();

        SystemLogController logController = new SystemLogController(context);

        List<SystemLog> logs = await logController.GetAllLogs();

        Assert.IsNotNull(logs);
        Assert.IsTrue(logs.Count >= 2);

        Assert.AreEqual("Ново действие", logs[0].Action);
    }

}
