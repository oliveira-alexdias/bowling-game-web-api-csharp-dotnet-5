using System.Collections.Generic;
using System.Threading.Tasks;
using BowlingGame.Service.Interfaces;
using BowlingGame.Service.Models;
using BowlingGame.Service.ObjectOfValues;

namespace BowlingGame.Service.Services
{
    public class ScoreService : IScoreService
    {
        private readonly IGameRepository gameRepository;

        public ScoreService(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task<GameModel> GetScore(string gameId)
        {
            var game = await gameRepository.GetByIdAsync(gameId);
            var totalScore = 0;

            var rolls = game.GetListOfRolls();

            for (var i = 0; i < rolls.Count - 1; i += 2)
            {
                if (IsLastFrame(i))
                {
                    totalScore += rolls[i] + rolls[i + 1] + rolls[i + 2];
                }
                else if (IsDoubleStrike(rolls, i))
                {
                    var doubleStrikeBonus = rolls[i + 2] + rolls[i + 4];
                    totalScore += Constants.MaxScore + doubleStrikeBonus;
                }
                else if (IsStrike(rolls, i))
                {
                    var strikeBonus = rolls[i + 2] + rolls[i + 3];
                    totalScore += Constants.MaxScore + strikeBonus;
                }
                else if (IsSpare(rolls, i))
                {
                    var spareBonus = rolls[i + 2];
                    totalScore += Constants.MaxScore + spareBonus;
                }
                else
                {
                    totalScore += rolls[i] + rolls[i + 1];
                }
            }

            return new GameModel(game.Id, game.PlayerName, totalScore);
        }

        private static bool IsLastFrame(int index)
        {
            return index == 18;
        }

        private static bool IsStrike(IReadOnlyList<int> rolls, int index)
        {
            return rolls[index] == Constants.MaxScore;
        }

        private static bool IsDoubleStrike(IReadOnlyList<int> rolls, int index)
        {
            return IsStrike(rolls, index) && IsStrike(rolls, index + 2);
        }

        private static bool IsSpare(IReadOnlyList<int> rolls, int index)
        {
            return rolls[index] + rolls[index + 1] == Constants.MaxScore;
        }
    }
}