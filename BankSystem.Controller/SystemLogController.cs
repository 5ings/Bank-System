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
            SystemLog log = new SystemLog
            {
                UserID = userId,
                Action = actionDescription,
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
