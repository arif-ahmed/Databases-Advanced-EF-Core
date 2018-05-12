using System;
using System.Collections.Generic;

namespace BillsPaymentSystem.Models
{
    public class BankAccount
    {
        public Guid BankAccountId { get; set; }
        public decimal Balance { get; private set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }

        public ICollection<PaymentMethod> PaymentMethods { get; set; }

        public BankAccount()
        {            
            PaymentMethods = new HashSet<PaymentMethod>();
        }
    }
}