using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BowlingGame.Service.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task AddAsync(T entity);
        Task<T> GetByIdAsync(string id);
        Task<List<T>> GetAllAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}