using BowlingGame.Service.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BowlingGame.Data.SqlServer.Mappings
{
    internal class RollMapping : IEntityTypeConfiguration<Roll>
    {
        public void Configure(EntityTypeBuilder<Roll> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Score);
            builder.ToTable("Rolls");
        }
    }
}