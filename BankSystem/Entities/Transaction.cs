using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankSystem.Data.Entities
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int? FromAccountID { get; set; }
        public Account FromAccount { get; set; }
        public int? ToAccountID { get; set; }
        public Account ToAccount { get; set; }
        public TransactionStatus Status { get; set; }
        public int? ApprovedByUserId { get; set; }
        public User ApprovedByUser { get; set; }

        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}
