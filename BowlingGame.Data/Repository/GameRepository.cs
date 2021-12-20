using System;
using System.Linq;
using System.Threading.Tasks;
using BowlingGame.Data.SqlServer.Context;
using BowlingGame.Service.Entities;
using BowlingGame.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BowlingGame.Data.SqlServer.Repository
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(SqlServerContext dbContext) : base(dbContext)
        {
        }
        
        public override Task<Game> GetByIdAsync(string id)
        {
            return DbContext.Games
                     .AsNoTracking()
                     .Include(f => f.Frames.OrderBy(o => o.Order))
                     .ThenInclude(r => r.Rolls.OrderBy(o => o.Attempt))
                     .FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}