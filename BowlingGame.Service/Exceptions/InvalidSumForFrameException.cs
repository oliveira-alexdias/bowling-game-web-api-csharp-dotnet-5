using System;
using BowlingGame.Service.ObjectOfValues;

namespace BowlingGame.Service.Exceptions
{
    public class InvalidSumForFrameException : Exception
    {
        public InvalidSumForFrameException() : base(
            $"The sum of scores for a frame cannot be greater than {Constants.MaxScore}.")
        {
        }
    }

    public class InvalidScoreException : Exception
    {
        public InvalidScoreException(string score) : base(
            $"The score {score} is invalid for this operation.")
        {
        }
    }
}