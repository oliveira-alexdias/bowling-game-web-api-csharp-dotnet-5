using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BowlingGame.Data.AzureCosmos.Context;
using BowlingGame.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BowlingGame.Data.AzureCosmos.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AzureCosmosContext DbContext;
        protected readonly DbSet<T> DbSet;

        protected Repository(AzureCosmosContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public virtual async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
            await SaveChangesAsync();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            await SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            return DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DbContext?.Dispose();
        }

    }
}