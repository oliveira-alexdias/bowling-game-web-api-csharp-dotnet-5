using System;
using System.Threading.Tasks;
using BowlingGame.Service.Models;

namespace BowlingGame.Service.Interfaces
{
    public interface IGameService
    {
        Task<GameModel> CreateGame(string playerName);
        Task<bool> GameNotFound(string gameId);
    }
}