using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame.Service.Entities
{
    public class Game
    {
        public Game() { }

        public Game(string playerName)
        {
            Id = Guid.NewGuid().ToString();
            PlayerName = playerName;
            Frames = new List<Frame>();
        }

        public string Id { get; set; }
        public string PlayerName { get; set; }
        public int CurrentFrameIndex { get; set; }
        public IList<Frame> Frames { get; set; }
        public DateTime CreatedOn { get; set; }

        public void IncreaseFrameIndex()
        {
            if (CurrentFrameIndex < 9) CurrentFrameIndex++;
        }

        public List<int> GetListOfRolls()
        {
            var rolls = new List<int>();

            foreach (var frame in Frames)
            {
                rolls.AddRange(frame.Rolls.Select(GetRollScoreValue));
            }

            return rolls;
        }

        private static int GetRollScoreValue(Roll roll)
        {
            if (roll.Score is null) return 0;
            return (int)roll.Score;
        }
    }
}