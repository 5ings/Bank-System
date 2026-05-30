using BankSystem.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Data.Entities
{
    public class Complaint
    {
        public int ComplaintID { get; set; }
        public int ClientID { get; set; }
        public Client Client { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public ComplaintStatus Status { get; set; }
        public string ManagerComment { get; set; }
    }
}
