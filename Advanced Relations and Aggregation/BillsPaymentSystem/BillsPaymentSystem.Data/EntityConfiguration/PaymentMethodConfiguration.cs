using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPaymentSystem.Data.EntityConfiguration
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(paymentMethod => paymentMethod.Id);
            builder.Property(paymentMethod => paymentMethod.Type).IsRequired();
            builder.Property(paymentMethod => paymentMethod.UserId).IsRequired();
            builder.Property(paymentMethod => paymentMethod.BankAccountId).IsRequired();
            builder.Property(paymentMethod => paymentMethod.CreditCardId).IsRequired();

            builder.HasOne(paymentMethod => paymentMethod.User).WithMany(user => user.PaymentMethods)
                .HasForeignKey(paymentMethod => paymentMethod.UserId);

            builder.HasOne(paymentMethod => paymentMethod.CreditCard)
                .WithMany(creditCard => creditCard.PaymentMethods)
                .HasForeignKey(paymentMethod => paymentMethod.CreditCardId);

            builder.HasOne(paymentMethod => paymentMethod.BankAccount)
                .WithMany(bankAccount => bankAccount.PaymentMethods)
                .HasForeignKey(paymentMethod => paymentMethod.BankAccountId);
        }
    }
}