using BankSystem.Data;
using BankSystem.Data.Entities;
using BankSystem.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankSystem.Controller
{
    public class UserController
    {
        private readonly BankDbContext _context;
        private readonly SystemLogController _logController;

        public UserController()
        {
            _context = new BankDbContext();
            _logController = new SystemLogController(_context);
        }

        public UserController(BankDbContext context)
        {
            _context = context;
            _logController = new SystemLogController(context);
        }

        public UserController(BankDbContext context, SystemLogController logController)
        {
            _context = context;
            _logController = logController;
        }

        public async Task<User> LoginUser(string username, string password)
        {
            var user = await _context.Users
                        .Include(u => u.Client)
                        .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null) return null;

            if (user.IsActive == false)
            {
                throw new Exception("Вашият профил е деактивиран и нямате достъп до системата.");
            }

            if (user.PasswordHash == password)
            {
                return user;
            }

            return null;
        }

        public async Task CreateUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            if (user.Role == UserRole.Client)
            {
                if (user.ClientID == null || user.ClientID == 0)
                {
                    throw new InvalidOperationException("Потребителят с роля 'Клиент' трябва да има асоциирана клиентска информация.");
                }
            }

            var usernameExists = await _context.Users.AnyAsync(u => u.Username == user.Username);
            if (usernameExists)
            {
                throw new InvalidOperationException("Потребителското име вече е заето.");
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.Include(u => u.Client).ToListAsync();
        }

        public async Task UpdateUser(User updatedUser)
        {
            var existing = await _context.Users.FirstOrDefaultAsync(u => u.UserID == updatedUser.UserID);
            if (existing != null)
            {
                if (string.IsNullOrWhiteSpace(updatedUser.PasswordHash) || updatedUser.PasswordHash.Length < 6)
                {
                    throw new ArgumentException("Новата парола трябва да бъде поне 6 символа.");
                }

                existing.PasswordHash = updatedUser.PasswordHash;
                existing.Role = updatedUser.Role;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserID == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeactivateUser(int userId, int adminId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                user.IsActive = false;
                await _context.SaveChangesAsync();

                await _logController.LogAction(adminId, $"Администратор деактивира профила на потребител: {user.Username}.");
            }
        }
    }
}

