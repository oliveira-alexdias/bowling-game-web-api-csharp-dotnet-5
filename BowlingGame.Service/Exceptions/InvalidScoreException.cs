using System;

namespace BowlingGame.Service.Exceptions
{
    public class InvalidScoreException : Exception
    {
        public InvalidScoreException(string score) : base(
            $"The score {score} is invalid for this roll atempt.")
        {
        }
    }
}