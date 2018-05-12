using FootballBetting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBetting.Data.EntityConfiguration
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasKey(x => x.TownId);

            builder.HasMany(x => x.Teams).WithOne(y => y.Town).HasForeignKey(x => x.TownId);

            builder.HasOne(town => town.Country)
                .WithMany(country => country.Towns)
                .HasForeignKey(town => town.CountryId);
        }
    }
}