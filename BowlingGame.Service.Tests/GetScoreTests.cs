using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BowlingGame.Service.Entities;
using BowlingGame.Service.Factories;
using BowlingGame.Service.Interfaces;
using BowlingGame.Service.Services;
using Moq;
using Xunit;

namespace BowlingGame.Service.Tests
{
    public class GetScoreTests
    {
        private Game game;
        private Mock<IGameRepository> mock;

        [Theory]
        [InlineData("John", new int[] { 10, 0, 1, 9, 7, 2, 10, 0, 1, 8, 9, 0, 8, 1, 5, 5, 10, 0, 6, 3, 0 }, 140)]
        [InlineData("Peter", new int[] { 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 10, 10 }, 300)]
        [InlineData("Catarina", new int[] { 3, 4, 5, 5, 0, 2, 4, 6, 7, 2, 9, 0, 3, 4, 5, 0, 9, 0, 10, 2, 4 }, 91)]
        [InlineData("Thomas", new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 7, 2, 1, 1, 1, 3, 3, 3, 3, 3, 3, 1, 0 }, 34)]
        [InlineData("Mary", new int[] { 4, 4, 3, 7, 10, 0, 0, 1, 10, 0, 4, 6, 2, 7, 8, 2, 2, 8, 9, 1, 10 }, 132)]
        [InlineData("Carlo", new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 }, 20)]
        public async Task GetScore_Expected_Must_Be_Equals_To_Actual(string playerName, int[] rolls, int expected)
        {
            // Arrange
            var index = 0;
            mock = new Mock<IGameRepository>();
            game = GameFactory.Create(playerName);
            var scoreServiceMocked = new ScoreService(mock.Object);

            foreach (var frame in game.Frames)
                foreach (var roll in frame.Rolls)
                    roll.Score = rolls[index++];

            mock.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(game);

            // Act
            var result = await scoreServiceMocked.GetScore(game.Id);
            var actual = result.Score;

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
