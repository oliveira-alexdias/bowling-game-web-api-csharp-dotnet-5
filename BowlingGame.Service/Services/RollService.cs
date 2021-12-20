using System;
using System.Threading.Tasks;
using BowlingGame.Service.Exceptions;
using BowlingGame.Service.Extensions;
using BowlingGame.Service.Interfaces;

namespace BowlingGame.Service.Services
{
    public class RollService : IRollService
    {
        private readonly IGameRepository gameRepository;

        public RollService(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task Roll(string gameId, string score)
        {
            var game = await gameRepository.GetByIdAsync(gameId);
            var index = game.CurrentFrameIndex;

            if (game.Frames[index].IsFirstRoll())
            {
                if (score.IsStrike())
                {
                    game.Frames[index].SetStrike();
                    game.IncreaseFrameIndex();
                }
                else
                {
                    game.Frames[index].AddScoreToFirstRoll(score);
                }
            }
            else if (game.Frames[index].IsSecondRoll())
            {
                if (score.IsSpare())
                {
                    game.Frames[index].SetSpare();
                }
                else
                {
                    game.Frames[index].AddScoreToSecondRoll(score);
                }

                game.IncreaseFrameIndex();
            }
            else if (game.Frames[index].IsLastFrameBonusAvailable())
            {
                game.Frames[index].AddScoreToThirdRoll(score);
            }
            else
            {
                throw new GameHasBeenFinishedException();
            }

            await gameRepository.UpdateAsync(game);
        }
    }
}