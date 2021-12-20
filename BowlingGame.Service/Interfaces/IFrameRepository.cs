using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BowlingGame.Service.Entities;

namespace BowlingGame.Service.Interfaces
{
    public interface IFrameRepository : IRepository<Frame>
    {
        Task<IEnumerable<Frame>> GetByGameIdAsync(Guid gameId);
    }
}