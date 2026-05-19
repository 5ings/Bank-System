using BankSystem.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Data.Entities
{
    public class BankCard
    {
        public int CardID { get; set; }
        public int AccountID { get; set; }
        public string CardNumber { get; set; }
        public CardType CardType { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }

        public Account Account { get; set; }
    }
}
