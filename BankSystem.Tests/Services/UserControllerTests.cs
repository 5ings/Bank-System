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

        [SetUp]
        public void Setup()
        {
            
        }

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

            Assert.AreEqual("Вашият профил е деактивиран и нямате достъп до системата.", exception.Message);
        }

        [Test]
        public async Task CreateUser_SuccessfullyAddsUserToDb()
        {
            var context = TestDbBank.CreateContext();
            UserController userController = new UserController(context);

            var newUser = new User
            {
                Username = "NewCreatedUser",
                PasswordHash = "secretPassword",
                Role = UserRole.Teller,
                IsActive = true
            };

            await userController.CreateUser(newUser);

            var dbUser = await context.Users.FirstOrDefaultAsync(u => u.Username == "NewCreatedUser");
            Assert.IsNotNull(dbUser);
            Assert.AreEqual("secretPassword", dbUser.PasswordHash);
            Assert.AreEqual(UserRole.Teller, dbUser.Role);
        }


        [Test]
        public async Task GetAllUsers_ReturnsAllUsersFromDatabase()
        {
            var context = TestDbBank.CreateContext();

            context.Users.Add(new User { Username = "User1", PasswordHash = "p1", Role = UserRole.Client, IsActive = true });
            context.Users.Add(new User { Username = "User2", PasswordHash = "p2", Role = UserRole.Teller, IsActive = true });
            await context.SaveChangesAsync();

            UserController userController = new UserController(context);

            List<User> users = await userController.GetAllUsers();

            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count >= 2);
        }


        [Test]
        public async Task UpdateUser_UpdatesPasswordAndRoleCorrectly()
        {
            var context = TestDbBank.CreateContext();

            var existingUser = new User
            {
                Username = "PromotionUser",
                PasswordHash = "oldPass",
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
        public async Task DeactivateUser_SetsIsActiveToFalse()
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

            Assert.IsNull(user, "Методът трябва да върне null, когато паролата е грешна.");
        }
    }
}
