using FootballBetting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBetting.Data.EntityConfiguration
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(color => color.ColorId);

            builder.HasMany(color => color.PrimaryKitTeams)
                .WithOne(team => team.PrimaryKitColor)
                .HasForeignKey(x => x.PrimaryKitColorId);

            builder.HasMany(color => color.SecondaryKitTeams)
                .WithOne(team => team.SecondaryKitColor)
                .HasForeignKey(x => x.SecondaryKitColorId);
        }
    }
}