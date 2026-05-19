using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Data.Entities
{
    public class SystemLog
    {
        public int LogID { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public string Action { get; set; }
        public DateTime LogDate { get; set; }
    }
}
