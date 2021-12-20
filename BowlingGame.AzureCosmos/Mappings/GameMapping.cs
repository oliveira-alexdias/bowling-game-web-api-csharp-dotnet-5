using BowlingGame.Service.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BowlingGame.Data.AzureCosmos.Mappings
{
    public class GameMapping : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToContainer("Games");

            builder.HasNoDiscriminator();

            builder.HasPartitionKey(i => i.Id);

            builder.Property(i => i.CurrentFrameIndex);
            builder.Property(i => i.PlayerName);
            builder.Property(i => i.CreatedOn);

            // It removes the EF relations for SQL Server
            builder.OwnsMany(i => i.Frames, f =>
            {
                f.Ignore(g => g.Game);
                f.Ignore(g => g.Id);
                f.Ignore(g => g.GameId);

                f.OwnsMany(r => r.Rolls, r =>
                {
                    r.Ignore(p => p.Frame);
                    r.Ignore(p => p.Id);
                    r.Ignore(p => p.FrameId);
                });
            });
        }
    }
}