using BankSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Tests.Helpers
{
    public class TestDbBank
    {
        public static BankDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<BankDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            BankDbContext context = new BankDbContext();

            context.Database.EnsureCreated();

            return context;
        }
    }
}
