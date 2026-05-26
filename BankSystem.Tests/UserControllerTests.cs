using BankSystem.Controller;
using BankSystem.Data;
using BankSystem.Data.Entities;
using BankSystem.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Tests
{
    public class UserControllerTests
    {
        private UserController _userController;

        [SetUp]
        public void Setup()
        {
            _userController = new UserController();
        }

        [Test]
        public async Task Test_1_CreateUser_ShouldAddNewUserToDatabase()
        { 
            string uniqueUsername = "test_create_" + Guid.NewGuid().ToString().Substring(0, 8);
            var newUser = new User
            {
                Username = uniqueUsername,
                PasswordHash = "CreatePass123",
                Role = UserRole.Client,
                IsActive = true
            };

            await _userController.CreateUser(newUser);

            using (var context = new BankDbContext())
            {
                var savedUser = await context.Users.FirstOrDefaultAsync(u => u.Username == uniqueUsername);
                Assert.IsNotNull(savedUser, "Методът CreateUser не записа потребителя в базата данни!");

                context.Users.Remove(savedUser);
                await context.SaveChangesAsync();
            }
        }

        [Test]
        public async Task Test_2_LoginUser_WithCorrectCredentials_ShouldReturnUser()
        {
            string uniqueUsername = "test_login_" + Guid.NewGuid().ToString().Substring(0, 8);
            var tempUser = new User { Username = uniqueUsername, PasswordHash = "LoginPass123", Role = UserRole.Client, IsActive = true };

            using (var context = new BankDbContext())
            {
                context.Users.Add(tempUser);
                await context.SaveChangesAsync();
            }

            try
            {
                User result = await _userController.LoginUser(uniqueUsername, "LoginPass123");

                Assert.IsNotNull(result, "Методът LoginUser върна null при правилни потребителско име и парола!");
                Assert.AreEqual(uniqueUsername, result.Username);
            }
            finally
            {
                using (var context = new BankDbContext())
                {
                    var userToRemove = await context.Users.FirstOrDefaultAsync(u => u.Username == uniqueUsername);
                    if (userToRemove != null) { context.Users.Remove(userToRemove); await context.SaveChangesAsync(); }
                }
            }
        }

        [Test]
        public async Task Test_3_GetAllUsers_ShouldReturnListOfUsers()
        {
            List<User> usersList = await _userController.GetAllUsers();

            Assert.IsNotNull(usersList, "Методът GetAllUsers връща null вместо списък!");
            Assert.IsTrue(usersList.Count > 0, "Списъкът с потребители е празен, а трябва да съдържа поне администратора!");
        }

        [Test]
        public async Task Test_4_UpdateUser_ShouldChangePasswordAndRole()
        {
            string uniqueUsername = "test_update_" + Guid.NewGuid().ToString().Substring(0, 8);
            var user = new User { Username = uniqueUsername, PasswordHash = "OldPassword", Role = UserRole.Client, IsActive = true };

            using (var context = new BankDbContext())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }

            try
            {
                user.PasswordHash = "NewPassword123";
                user.Role = UserRole.Teller;

                await _userController.UpdateUser(user);

                using (var context = new BankDbContext())
                {
                    var updatedUser = await context.Users.FirstOrDefaultAsync(u => u.UserID == user.UserID);
                    Assert.AreEqual("NewPassword123", updatedUser.PasswordHash, "Паролата не беше актуализирана в базата данни!");
                    Assert.AreEqual(UserRole.Teller, updatedUser.Role, "Ролята не беше актуализирана в базата данни!");
                }
            }
            finally
            {
                using (var context = new BankDbContext())
                {
                    var userToRemove = await context.Users.FirstOrDefaultAsync(u => u.Username == uniqueUsername);
                    if (userToRemove != null) { context.Users.Remove(userToRemove); await context.SaveChangesAsync(); }
                }
            }
        }

        [Test]
        public async Task Test_5_DeactivateUser_ShouldSetIsActiveToFalse()
        {
            string uniqueUsername = "test_deactivate_" + Guid.NewGuid().ToString().Substring(0, 8);
            var user = new User { Username = uniqueUsername, PasswordHash = "Pass123", Role = UserRole.Client, IsActive = true };

            using (var context = new BankDbContext())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }

            try
            {
                await _userController.DeactivateUser(user.UserID);

                using (var context = new BankDbContext())
                {
                    var deactivatedUser = await context.Users.FirstOrDefaultAsync(u => u.UserID == user.UserID);
                    Assert.IsFalse(deactivatedUser.IsActive, "Методът DeactivateUser не промени флага IsActive на false!");
                }
            }
            finally
            {
                using (var context = new BankDbContext())
                {
                    var userToRemove = await context.Users.FirstOrDefaultAsync(u => u.Username == uniqueUsername);
                    if (userToRemove != null) { context.Users.Remove(userToRemove); await context.SaveChangesAsync(); }
                }
            }
        }

        [Test]
        public async Task Test_6_DeleteUser_ShouldRemoveUserFromDatabase()
        {
            string uniqueUsername = "test_delete_" + Guid.NewGuid().ToString().Substring(0, 8);
            var user = new User { Username = uniqueUsername, PasswordHash = "Pass123", Role = UserRole.Client, IsActive = true };

            using (var context = new BankDbContext())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
            }

            await _userController.DeleteUser(user.UserID);

            using (var context = new BankDbContext())
            {
                var deletedUser = await context.Users.FirstOrDefaultAsync(u => u.UserID == user.UserID);
                Assert.IsNull(deletedUser, "Методът DeleteUser не премахна физически потребителя от базата данни!");
            }
        }

        [Test]
        public async Task LoginUser_WithWrongPassword_ShouldReturnNull()
        {
            var controller = new UserController();

            using (var context = new BankDbContext())
            {
                var existing = await context.Users.FirstOrDefaultAsync(u => u.Username == "LoginTestUser");
                if (existing == null)
                {
                    context.Users.Add(new User { Username = "LoginTestUser", PasswordHash = "correct_pass", Role = 0 });
                    await context.SaveChangesAsync();
                }
            }

            var result = await controller.LoginUser("LoginTestUser", "greshna_parola_123");

            Assert.IsNull(result, "Методът трябваше да върне null за грешна парола!");
        }

        [Test]
        public async Task CreateUser_WithDuplicateUsername_ShouldThrowDbUpdateException()
        {
            var controller = new UserController();
            string duplicateName = "DuplicateUserToTest";

            using (var context = new BankDbContext())
            {
                var existing = await context.Users.FirstOrDefaultAsync(u => u.Username == duplicateName);
                if (existing == null)
                {
                    context.Users.Add(new User { Username = duplicateName, PasswordHash = "pass1", Role = 0 });
                    await context.SaveChangesAsync();
                }
            }

            var duplicateUser = new User
            {
                Username = duplicateName,
                PasswordHash = "pass2",
                Role = 0
            };

            Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                await controller.CreateUser(duplicateUser);
            }, "Базата трябваше да блокира дублиращия се Username!");
        }
    }
}
