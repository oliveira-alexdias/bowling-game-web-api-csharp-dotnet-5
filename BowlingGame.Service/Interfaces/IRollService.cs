using System;
using System.Threading.Tasks;

namespace BowlingGame.Service.Interfaces
{
    public interface IRollService
    {
        Task Roll(string gameId, string score);
    }
}