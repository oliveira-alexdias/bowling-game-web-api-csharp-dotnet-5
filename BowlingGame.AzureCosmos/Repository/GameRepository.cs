using System;
using System.Threading.Tasks;
using BowlingGame.Data.AzureCosmos.Context;
using BowlingGame.Service.Entities;
using BowlingGame.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BowlingGame.Data.AzureCosmos.Repository
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(AzureCosmosContext dbContext) : base(dbContext)
        {
        }
        
        public override Task<Game> GetByIdAsync(string id)
        {
            return DbContext.Games
                     .AsNoTracking()
                     .FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}