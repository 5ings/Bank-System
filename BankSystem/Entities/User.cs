using BankSystem.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Data.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; } 
        public int? ClientID { get; set; }
        public bool IsActive { get; set; } = true;

        public Client Client { get; set; }
        public ICollection<SystemLog> SystemLogs { get; set; } = new List<SystemLog>();

        public override string ToString()
        {
            return this.Username;
        }
    }
}
