using System;
using BowlingGame.Service.Models;

namespace BowlingGame.API.Response
{
    public class CreateGameResponse
    {
        public CreateGameResponse(GameModel gameModel)
        {
            Id = gameModel.Id;
            PlayerName = gameModel.PlayerName;
        }

        public string Id { get; set; }
        public string PlayerName { get; set; }
    }

    public class GetScoreResponse
    {
        public GetScoreResponse(GameModel gameModel)
        {
            Id = gameModel.Id;
            Score = gameModel.Score;
            PlayerName = gameModel.PlayerName;
        }

        public string Id { get; set; }
        public string PlayerName { get; set; }
        public int Score { get; set; }
    }
}
