using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Data.Entities
{
    public class Account
    {
        public int AccountID { get; set; }
        public int ClientID { get; set; }
        public string IBAN { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }

        public Client Client { get; set; }
        public ICollection<BankCard> BankCards { get; set; } = new List<BankCard>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
