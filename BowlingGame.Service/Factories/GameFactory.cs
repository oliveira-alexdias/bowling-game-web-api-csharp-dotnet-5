using System;
using BowlingGame.Service.Entities;

namespace BowlingGame.Service.Factories
{
    public class GameFactory
    {
        public static Game Create(string playerName)
        {
            var game = new Game(playerName);
            game.Frames = FrameFactory.CreateList(game.Id);
            return game;
        }
    }
}