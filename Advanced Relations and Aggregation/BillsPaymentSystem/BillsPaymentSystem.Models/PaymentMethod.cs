using System;
using BillsPaymentSystem.Models.Enums;

namespace BillsPaymentSystem.Models
{
    public class PaymentMethod
    {
        public Guid Id { get; set; }
        public PaymentMethodType Type { get; set; }
        public Guid UserId { get; set; }
        public Guid? BankAccountId { get; set; }
        public Guid? CreditCardId { get; set; }

        public User User { get; set; }
        public BankAccount BankAccount { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}