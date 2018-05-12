using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPaymentSystem.Data.EntityConfiguration
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasKey(creditCard => creditCard.CreditCardId);

            builder.Ignore(creditCard => creditCard.LimitLeft);

            builder.HasMany(creditCard => creditCard.PaymentMethods)
                .WithOne(paymentMethod => paymentMethod.CreditCard)
                .HasForeignKey(creditCard => creditCard.CreditCardId);
        }
    }
}