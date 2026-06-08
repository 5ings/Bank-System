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
        public BankDbContext Context { get; set; }

        public SystemLogController()
        {
            Context = new BankDbContext();
        }

        public SystemLogController(BankDbContext context)
        {
            Context = context;
        }

        public async Task LogAction(int userId, string actionDescription)
        {
            if (userId <= 0)
            {
                throw new ArgumentException("Невалидно потребителско ID за запис в системния лог.");
            }

            if (string.IsNullOrWhiteSpace(actionDescription))
            {
                throw new ArgumentException("Описанието на системното действие не може да бъде празно.");
            }

            if (actionDescription.Length > 500)
            {
                actionDescription = actionDescription.Substring(0, 497) + "...";
            }

            SystemLog log = new SystemLog
            {
                UserID = userId,
                Action = actionDescription.Trim(),
                LogDate = DateTime.Now
            };

            await Context.SystemLogs.AddAsync(log);
            await Context.SaveChangesAsync();
        }

        public async Task<List<SystemLog>> GetAllLogs()
        {
            return await Context.SystemLogs
                         .Include(sl => sl.User)
                         .OrderByDescending(sl => sl.LogDate)
                         .ToListAsync();
        }
    }
}
