using BankSystem.Data;
using BankSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Controller
{
    public class UserController
    {
        //public BankDbContext Context { get; set; }
        //public UserController()
        //{
        //    Context = new BankDbContext();
        //}

        //public UserController(BankDbContext context)
        //{
        //    Context = context;
        //}
        public async Task<User> LoginUser(string username, string password)
        {

            using (BankDbContext context = new BankDbContext())
            {
                return await context.Users
                    .Include(u => u.Client)
                    .FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password);
            }
        }

        public async Task CreateUser(User user)
        {
            using (BankDbContext context = new BankDbContext())
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            using (BankDbContext context = new BankDbContext())
            {
                return await context.Users.Include(u => u.Client).ToListAsync();
            }
        }

        public async Task UpdateUser(User updatedUser)
        {
            using (BankDbContext context = new BankDbContext())
            {
                var existing = await context.Users.FirstOrDefaultAsync(u => u.UserID == updatedUser.UserID);
                if (existing != null)
                {
                    existing.PasswordHash = updatedUser.PasswordHash;
                    existing.Role = updatedUser.Role;
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteUser(int userId)
        {
            using (BankDbContext context = new BankDbContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.UserID == userId);
                if (user != null)
                {
                    context.Users.Remove(user);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task DeactivateUser(int userId)
        {
            using (BankDbContext context = new BankDbContext())
            {
                var user = await context.Users.FindAsync(userId);
                if (user != null)
                {
                    user.IsActive = false;
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}

