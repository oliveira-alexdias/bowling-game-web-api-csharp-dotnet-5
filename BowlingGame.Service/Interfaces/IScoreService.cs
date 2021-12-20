using System;
using System.Threading.Tasks;
using BowlingGame.Service.Models;

namespace BowlingGame.Service.Interfaces
{
    public interface IScoreService
    {
        Task<GameModel> GetScore(string gameId);
    }
}