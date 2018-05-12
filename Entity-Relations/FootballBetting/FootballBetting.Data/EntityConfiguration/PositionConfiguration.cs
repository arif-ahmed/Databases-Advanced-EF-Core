using FootballBetting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballBetting.Data.EntityConfiguration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(position => position.PositionId);

            builder.HasMany(position => position.Players)
                .WithOne(player => player.Position)
                .HasForeignKey(position => position.PlayerId);
        }
    }
}