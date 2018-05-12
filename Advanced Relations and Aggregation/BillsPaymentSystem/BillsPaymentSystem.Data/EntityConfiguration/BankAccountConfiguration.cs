using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillsPaymentSystem.Data.EntityConfiguration
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(bankAccount => bankAccount.BankAccountId);

            builder.HasMany(creditCard => creditCard.PaymentMethods)
                .WithOne(paymentMethod => paymentMethod.BankAccount)
                .HasForeignKey(creditCard => creditCard.BankAccountId);
        }
    }
}