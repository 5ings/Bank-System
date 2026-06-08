using BankSystem.Controller;
using BankSystem.Data;
using BankSystem.Data.Entities;
using BankSystem.Data.Enums;
using BankSystem.Tests.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Tests.Services
{
    public class UserControllerTests
    {
        [Test]
        public async Task LoginUser_ValidCredentials_ReturnsUser()
        {
            var context = TestDbBank.CreateContext();

            context.Users.Add(new User
            {
                Username = "TestLogUser",
                PasswordHash = "hashed_password_123",
                Role = UserRole.Admin,
                IsActive = true
            });
            await context.SaveChangesAsync();

            UserController userController = new UserController(context);

            User? user = await userController.LoginUser("TestLogUser", "hashed_password_123");

            Assert.IsNotNull(user);
            Assert.AreEqual("TestLogUser", user.Username);
        }

        [Test]
        public async Task LoginUser_WrongPassword_ReturnsNull()
        {
            var context = TestDbBank.CreateContext();

            context.Users.Add(new User
            {
                Username = "ExistingUser",
                PasswordHash = "correct_password_123",
                Role = UserRole.Client,
                IsActive = true
            });
            await context.SaveChangesAsync();

            UserController userController = new UserController(context);

            User? user = await userController.LoginUser("ExistingUser", "wrong_password_999");

            Assert.IsNull(user);
        }

        [Test]
        public async Task LoginUser_NonExistingUser_ReturnsNull()
        {
            var context = TestDbBank.CreateContext();
            UserController userController = new UserController(context);

            User? user = await userController.LoginUser("NonExisting", "somePass");

            Assert.IsNull(user);
        }

        [Test]
        public async Task LoginUser_InactiveUser_ThrowsException()
        {
            var context = TestDbBank.CreateContext();

            context.Users.Add(new User
            {
                Username = "InactiveUser",
                PasswordHash = "password123",
                Role = UserRole.Client,
                IsActive = false
            });
            await context.SaveChangesAsync();

            UserController userController = new UserController(context);

            var exception = Assert.ThrowsAsync<Exception>(async () =>
            {
                await userController.LoginUser("InactiveUser", "password123");
            });

            Assert.AreEqual("Вашият профил е деактивиран и нямате достъп до системата.", exception?.Message);
        }

        [Test]
        public async Task CreateUser_SuccessfullyAddsUserToDb_WithValidClientInfo()
        {
            var context = TestDbBank.CreateContext();
            UserController userController = new UserController(context);

            var newUser = new User
            {
                Username = "NewCreatedUser",
                PasswordHash = "secretPassword",
                Role = UserRole.Teller,
                IsActive = true,
                Client = new Client
                {
                    FirstName = "Георги",
                    LastName = "Георгиев",
                    EGN = "1111111111",
                    Phone = "0888123456",
                    Email = "g@test.com"
                }
            };

            await userController.CreateUser(newUser);

            var dbUser = await context.Users.Include(u => u.Client).FirstOrDefaultAsync(u => u.Username == "NewCreatedUser");
            Assert.IsNotNull(dbUser);
            Assert.AreEqual("secretPassword", dbUser.PasswordHash);
            Assert.AreEqual(UserRole.Teller, dbUser.Role);
            Assert.IsNotNull(dbUser.Client);
            Assert.AreEqual("Георги", dbUser.Client.FirstName);
        }

        [Test]
        public void CreateUser_ThrowsArgumentException_WhenUsernameIsTooShort()
        {
            var context = TestDbBank.CreateContext();
            UserController userController = new UserController(context);

            var newUser = new User
            {
                Username = "ab",
                PasswordHash = "secretPassword",
                Role = UserRole.Client,
                IsActive = true
            };

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await userController.CreateUser(newUser));
            Assert.AreEqual("Потребителското име трябва да бъде поне 3 символа.", ex?.Message);
        }

        [Test]
        public void CreateUser_ThrowsArgumentException_WhenPasswordIsTooShort()
        {
            var context = TestDbBank.CreateContext();
            UserController userController = new UserController(context);

            var newUser = new User
            {
                Username = "ValidUser",
                PasswordHash = "12345",
                Role = UserRole.Client,
                IsActive = true
            };

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await userController.CreateUser(newUser));
            Assert.AreEqual("Паролата трябва да бъде поне 6 символа.", ex?.Message);
        }

        [Test]
        public async Task CreateUser_ThrowsInvalidOperationException_WhenUsernameAlreadyExists()
        {
            var context = TestDbBank.CreateContext();
            context.Users.Add(new User { Username = "ExistingUser", PasswordHash = "123456", Role = UserRole.Client });
            await context.SaveChangesAsync();

            UserController userController = new UserController(context);

            var newUser = new User
            {
                Username = "ExistingUser",
                PasswordHash = "secretPassword",
                Role = UserRole.Client,
                IsActive = true
            };

            var ex = Assert.ThrowsAsync<InvalidOperationException>(async () => await userController.CreateUser(newUser));
            Assert.AreEqual("Потребителското име вече е заето.", ex?.Message);
        }

        [Test]
        public void CreateUser_ThrowsArgumentException_WhenClientInformationIsMissing()
        {
            var context = TestDbBank.CreateContext();
            UserController userController = new UserController(context);

            var newUser = new User
            {
                Username = "ValidUser",
                PasswordHash = "secretPassword",
                Role = UserRole.Client,
                IsActive = true,
                Client = null
            };

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await userController.CreateUser(newUser));
            Assert.AreEqual("Потребителят трябва да има асоциирана клиентска информация.", ex?.Message);
        }

        [Test]
        public void CreateUser_ThrowsArgumentException_WhenClientFirstNameIsInvalid()
        {
            var context = TestDbBank.CreateContext();
            UserController userController = new UserController(context);

            var newUser = new User
            {
                Username = "ValidUser",
                PasswordHash = "secretPassword",
                Role = UserRole.Client,
                IsActive = true,
                Client = new Client { FirstName = "Иван123", LastName = "Иванов", Phone = "0888123456", EGN = "1111111111", Email = "i@t.com" }
            };

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await userController.CreateUser(newUser));
            Assert.AreEqual("Първото име не може да бъде празно и не трябва да съдържа цифри или специални символи.", ex?.Message);
        }

        public async Task GetAllUsers_ReturnsAllUsersFromDatabaseWithClients()
        {
            var context = TestDbBank.CreateContext();

            var client1 = new Client { FirstName = "A", LastName = "B", EGN = "1111111111", Phone = "0888111111", Email = "a@b.com" };
            var client2 = new Client { FirstName = "C", LastName = "D", EGN = "2222222222", Phone = "0888222222", Email = "c@d.com" };

            context.Users.Add(new User { Username = "User1", PasswordHash = "p111111", Role = UserRole.Client, IsActive = true, Client = client1 });
            context.Users.Add(new User { Username = "User2", PasswordHash = "p222222", Role = UserRole.Teller, IsActive = true, Client = client2 });
            await context.SaveChangesAsync();

            context.ChangeTracker.Clear();

            UserController userController = new UserController(context);

            List<User> users = await userController.GetAllUsers();

            Assert.IsNotNull(users);
            Assert.AreEqual(2, users.Count);

            Assert.IsNotNull(users.FirstOrDefault(u => u.Username == "User1")?.Client);
            Assert.IsNotNull(users.FirstOrDefault(u => u.Username == "User2")?.Client);
        }

        [Test]
        public async Task UpdateUser_UpdatesPasswordAndRoleCorrectly()
        {
            var context = TestDbBank.CreateContext();

            var existingUser = new User
            {
                Username = "PromotionUser",
                PasswordHash = "oldPassword",
                Role = UserRole.Client,
                IsActive = true
            };
            context.Users.Add(existingUser);
            await context.SaveChangesAsync();

            UserController userController = new UserController(context);

            existingUser.PasswordHash = "newTellerPass";
            existingUser.Role = UserRole.Teller;

            await userController.UpdateUser(existingUser);

            var updatedDbUser = await context.Users.FindAsync(existingUser.UserID);
            Assert.IsNotNull(updatedDbUser);
            Assert.AreEqual("newTellerPass", updatedDbUser.PasswordHash);
            Assert.AreEqual(UserRole.Teller, updatedDbUser.Role);
        }

        [Test]
        public async Task UpdateUser_ThrowsArgumentException_WhenNewPasswordIsTooShort()
        {
            var context = TestDbBank.CreateContext();

            var existingUser = new User { Username = "TestUser", PasswordHash = "oldPassword", Role = UserRole.Client, IsActive = true };
            context.Users.Add(existingUser);
            await context.SaveChangesAsync();

            UserController userController = new UserController(context);
            existingUser.PasswordHash = "123";

            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await userController.UpdateUser(existingUser));
            Assert.AreEqual("Новата парола трябва да бъде поне 6 символа.", ex?.Message);
        }

        [Test]
        public async Task DeleteUser_RemovesUserCorrectly()
        {
            var context = TestDbBank.CreateContext();

            var userToDelete = new User
            {
                Username = "UserForDeletion",
                PasswordHash = "123456",
                Role = UserRole.Client,
                IsActive = true
            };
            context.Users.Add(userToDelete);
            await context.SaveChangesAsync();

            int targetId = userToDelete.UserID;

            UserController userController = new UserController(context);

            await userController.DeleteUser(targetId);

            var dbUser = await context.Users.FindAsync(targetId);
            Assert.IsNull(dbUser);
        }

        [Test]
        public async Task DeactivateUser_SetsIsActiveToFalseAndCreatesLog()
        {
            var context = TestDbBank.CreateContext();

            var userToDeactivate = new User
            {
                Username = "UserToDeactivate",
                PasswordHash = "pass123",
                Role = UserRole.Client,
                IsActive = true
            };
            context.Users.Add(userToDeactivate);
            await context.SaveChangesAsync();

            int targetUserId = userToDeactivate.UserID;

            SystemLogController logController = new SystemLogController(context);
            UserController userController = new UserController(context, logController);

            await userController.DeactivateUser(targetUserId, adminId: 1);

            var updatedUser = await context.Users.FindAsync(targetUserId);
            Assert.IsNotNull(updatedUser);
            Assert.IsFalse(updatedUser.IsActive);

            var log = await context.SystemLogs.FirstOrDefaultAsync(l => l.UserID == 1);
            Assert.IsNotNull(log);
            Assert.AreEqual("Администратор деактивира профила на потребител: UserToDeactivate.", log.Action);
        }
    }
}
