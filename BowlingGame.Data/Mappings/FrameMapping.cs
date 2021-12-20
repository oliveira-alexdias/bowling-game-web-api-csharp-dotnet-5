using BowlingGame.Service.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BowlingGame.Data.SqlServer.Mappings
{
    internal class FrameMapping : IEntityTypeConfiguration<Frame>
    {
        public void Configure(EntityTypeBuilder<Frame> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Rolls)
                .WithOne(p => p.Frame)
                .HasForeignKey(p => p.FrameId);
            
            builder.ToTable("Frames");
        }
    }
}