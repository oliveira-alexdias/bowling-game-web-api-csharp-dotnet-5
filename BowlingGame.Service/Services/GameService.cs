using System;
using System.Threading.Tasks;
using BowlingGame.Service.Entities;
using BowlingGame.Service.Factories;
using BowlingGame.Service.Interfaces;
using BowlingGame.Service.Models;

namespace BowlingGame.Service.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task<GameModel> CreateGame(string playerName)
        {
            var game = GameFactory.Create(playerName);
            await gameRepository.AddAsync(game);
            return new GameModel(game.Id, game.PlayerName);
        }
    }
}