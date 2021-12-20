using BowlingGame.Service.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BowlingGame.Data.SqlServer.Mappings
{
    internal class GameMapping : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PlayerName)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasMany(p => p.Frames)
                   .WithOne(p => p.Game)
                   .HasForeignKey(p => p.GameId);

            builder.ToTable("Games");
        }
    }
}
