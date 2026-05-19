using BankSystem.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Data.Entities
{
    public class Loan
    {
        public int LoanID { get; set; }
        public int ClientID { get; set; }
        public decimal Amount { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int TermMonths { get; set; }
        public LoanStatus Status { get; set; }

        public Client Client { get; set; }
    }
}
