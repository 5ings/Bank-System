using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Data.Entities
{
    public class Client
    {
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EGN { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<Account> Accounts { get; set; } = new List<Account>();
        public User User { get; set; }
    }
}
