using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Data.Entities
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int AccountID { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }

        public Account Account { get; set; }
    }
}
