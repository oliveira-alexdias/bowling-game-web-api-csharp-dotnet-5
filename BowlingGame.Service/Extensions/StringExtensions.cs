using System;

namespace BowlingGame.Service.Extensions
{
    public static class StringExtensions
    {
        public static bool IsStrike(this string score)
        {
            return score.Equals("X", StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool IsSpare(this string score)
        {
            return score.Equals("/");
        }

        public static bool IsFailed(this string score)
        {
            return score.Equals("-") || score.Equals("F", StringComparison.CurrentCultureIgnoreCase);
        }
    }
}