using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BowlingGame.Service.Entities;
using Microsoft.EntityFrameworkCore;

namespace BowlingGame.Data.AzureCosmos.Context
{
    public class AzureCosmosContext : DbContext
    {
        public AzureCosmosContext()
        {
        }

        public AzureCosmosContext(DbContextOptions<AzureCosmosContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AzureCosmosContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedOn") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedOn").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedOn").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}