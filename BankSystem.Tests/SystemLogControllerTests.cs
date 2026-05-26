using BankSystem.Controller;
using BankSystem.Data;
using BankSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

namespace BankSystem.Tests;

public class SystemLogControllerTests
{
    private int _testUserId;

    [SetUp]
    public async Task Setup()
    {
        using (var context = new BankDbContext())
        {
            // 1. Изчистваме старите тестови логове, за да няма застъпване
            var logs = await context.SystemLogs.ToListAsync();
            context.SystemLogs.RemoveRange(logs);
            await context.SaveChangesAsync();

            // 2. Създаваме тестов потребител, отговарящ точно на твоя модел
            var testUser = await context.Users.FirstOrDefaultAsync(u => u.Username == "TestLogUser");
            if (testUser == null)
            {
                testUser = new User
                {
                    Username = "TestLogUser",
                    PasswordHash = "hashed_password_123",
                    Role = 0, // Подаваме 0 (или конкретно UserRole.Admin / UserRole.User, ако ти го допълва автоматично)
                    IsActive = true
                };
                await context.Users.AddAsync(testUser);
                await context.SaveChangesAsync();
            }

            _testUserId = testUser.UserID;
        }
    }

    [TearDown]
    public async Task Teardown()
    {
        // Изчистваме базата след края на теста
        using (var context = new BankDbContext())
        {
            var logs = await context.SystemLogs.Where(l => l.UserID == _testUserId).ToListAsync();
            context.SystemLogs.RemoveRange(logs);

            var testUser = await context.Users.FirstOrDefaultAsync(u => u.Username == "TestLogUser");
            if (testUser != null)
            {
                context.Users.Remove(testUser);
            }

            await context.SaveChangesAsync();
        }
    }

    [Test]
    public async Task LogAction_ShouldSuccessfullySaveLogToDatabase()
    {
        // Arrange
        var controller = new SystemLogController();
        string testDescription = "Потребителят направи успешно тестване";

        // Act
        await controller.LogAction(_testUserId, testDescription);

        // Assert
        using (var context = new BankDbContext())
        {
            var savedLog = await context.SystemLogs
                .FirstOrDefaultAsync(l => l.Action == testDescription && l.UserID == _testUserId);

            Assert.IsNotNull(savedLog, "Логът не беше записан успешно в базата!");
            Assert.AreEqual(_testUserId, savedLog.UserID);
            Assert.AreEqual(testDescription, savedLog.Action);
        }
    }

    [Test]
    public async Task GetAllLogs_ShouldReturnAllLogsOrderedByDateDescending()
    {
        // Arrange
        using (var context = new BankDbContext())
        {
            var log1 = new SystemLog { UserID = _testUserId, Action = "По-старо действие", LogDate = DateTime.Now.AddMinutes(-5) };
            var log2 = new SystemLog { UserID = _testUserId, Action = "Най-ново действие", LogDate = DateTime.Now };

            await context.SystemLogs.AddRangeAsync(log1, log2);
            await context.SaveChangesAsync();
        }

        var controller = new SystemLogController();

        // Act
        var result = await controller.GetAllLogs();

        // Assert
        Assert.IsNotNull(result);
        var currentTestLogs = result.Where(l => l.UserID == _testUserId).ToList();

        Assert.AreEqual(2, currentTestLogs.Count, "Броят на логовете не съвпада.");
        Assert.AreEqual("Най-ново действие", currentTestLogs.First().Action, "Сортировката по дата не работи правилно.");
    }

    [Test]
    public void LogAction_WithInvalidUserId_ShouldThrowDbUpdateException()
    {
        // Arrange
        var controller = new SystemLogController();
        int nonExistingUserId = -9999;
        string description = "Тест за грешен потребител";

        // Act & Assert
        Assert.ThrowsAsync<DbUpdateException>(async () =>
        {
            await controller.LogAction(nonExistingUserId, description);
        }, "Трябваше да хвърли DbUpdateException за несъществуващ потребител.");
    }

    [Test]
    public void LogAction_WithTooLongDescription_ShouldThrowDbUpdateException()
    {
        // Arrange
        var controller = new SystemLogController();
        string superLongDescription = new string('A', 10000);

        // Act & Assert
        Assert.ThrowsAsync<DbUpdateException>(async () =>
        {
            await controller.LogAction(_testUserId, superLongDescription);
        }, "Трябваше да хвърли DbUpdateException за прекалено дълго описание.");
    }

}
