using System;
using System.Collections.Generic;

namespace BillsPaymentSystem.Models
{
    public class CreditCard
    {
        public Guid CreditCardId { get; set; }
        public decimal Limit { get; set; }
        public decimal MoneyOwed { get; set; }
        public decimal LimitLeft { get; set; }
        public DateTime ExpirationDate { get; set; }

        public ICollection<PaymentMethod> PaymentMethods { get; set; }

        public CreditCard()
        {
            PaymentMethods = new HashSet<PaymentMethod>();
        }
    }
}