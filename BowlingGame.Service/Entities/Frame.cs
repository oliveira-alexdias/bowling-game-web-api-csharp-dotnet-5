using System;
using System.Collections.Generic;
using BowlingGame.Service.Exceptions;
using BowlingGame.Service.Extensions;
using BowlingGame.Service.ObjectOfValues;

namespace BowlingGame.Service.Entities
{
    public class Frame
    {
        public Frame() { }
        public Frame(string gameId, int order)
        {
            Id = Guid.NewGuid().ToString();
            GameId = gameId;
            Order = order;
            Rolls = new List<Roll>();
        }

        public string Id { get; set; }
        public string GameId { get; set; }
        public int Order { get; set; }
        public IList<Roll> Rolls { get; set; }
        public Game Game { get; set; }  /* EF Relation */

        public bool IsFirstRoll()
        {
            return Rolls[0].Score is null;
        }

        public bool IsSecondRoll()
        {
            return Rolls[1].Score is null &&
                   Rolls[0].Score != null;
        }

        public bool IsLastFrameBonusAvailable()
        {
            var firstRoll = Rolls[0].Score ?? 0;
            var secondRoll = Rolls[1].Score ?? 0;
            return IsLastFrame() && Rolls[2].Score is null && (firstRoll + secondRoll >= 10);
        }

        public bool IsLastFrame()
        {
            return Order == 10;
        }

        public void SetStrike()
        {
            Rolls[0].Score = Constants.MaxScore;
        }

        public void SetSpare()
        {
            Rolls[1].Score = Constants.MaxScore - Rolls[0].Score;
        }

        public void AddScoreToFirstRoll(string score)
        {
            if (score.IsSpare()) throw new InvalidScoreException(score);
            AddScoreToRoll(GetScoreValue(score), 0);
        }

        public void AddScoreToSecondRoll(string score)
        {
            var firstRollScore = Rolls[0].Score;
            var secondRollScore = GetScoreValue(score);
            if ((firstRollScore + secondRollScore > Constants.MaxScore) && !IsLastFrame()) throw new InvalidSumForFrameException();
            if (score.IsStrike() && !IsLastFrame()) throw new InvalidScoreException(score);
            AddScoreToRoll(GetScoreValue(score), 1);
        }

        public void AddScoreToThirdRoll(string score)
        {
            if (score.IsSpare()) throw new InvalidScoreException(score);
            AddScoreToRoll(GetScoreValue(score), 2);
        }

        private void AddScoreToRoll(int score, int roll)
        {
            Rolls[roll].Score = score;
        }

        public int GetScoreValue(string score)
        {
            if (score.IsFailed()) return 0;
            if (score.IsStrike()) return 10;
            var isInt = int.TryParse(score, out var scoreValue);
            return isInt ? scoreValue : throw new InvalidScoreException(score);
        }
    }
}