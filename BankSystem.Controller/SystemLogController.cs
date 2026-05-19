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
    public class SystemLogController
    {
        public async Task LogAction(int userId, string actionDescription)
        {
            using (BankDbContext context = new BankDbContext())
            {
                SystemLog log = new SystemLog
                {
                    UserID = userId,
                    Action = actionDescription,
                    LogDate = DateTime.Now
                };
                await context.SystemLogs.AddAsync(log);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<SystemLog>> GetAllLogs()
        {
            using (BankDbContext context = new BankDbContext())
            {
                return await context.SystemLogs
                    .Include(sl => sl.User)
                    .OrderByDescending(sl => sl.LogDate)
                    .ToListAsync();
            }
        }
    }
}
