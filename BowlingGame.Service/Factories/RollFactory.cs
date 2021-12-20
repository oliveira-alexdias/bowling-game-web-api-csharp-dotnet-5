using System.Collections.Generic;
using BowlingGame.Service.Entities;
using BowlingGame.Service.ObjectOfValues;

namespace BowlingGame.Service.Factories
{
    public class RollFactory
    {
        public static List<Roll> CreateList(string frameId, int frameOrder)
        {
            var rolls = new List<Roll>();

            var numberOfRolls = frameOrder == Constants.LastFrameOrder ? 3 : 2;

            for (var i = 1; i <= numberOfRolls; i++)
            {
                rolls.Add(new Roll(frameId, i));
            }

            return rolls;
        }
    }
}