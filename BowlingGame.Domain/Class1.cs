using System;
using System.Collections;
using System.Collections.Generic;

namespace BowlingGame.Domain
{
    public class Game
    {
        public Guid Id { get; set; }
        public string PlayerName { get; set; }
        public IList<Frame> Frames { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class Frame
    {
        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public string FirstAttempt { get; set; }
        public string SecondAttempt { get; set; }
        public int Score { get; set; }
    }
}
