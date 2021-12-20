using System;

namespace BowlingGame.Service.Entities
{
    public class Roll
    {
        public Roll() {}

        public Roll(string frameId, int attempt)
        {
            Id = Guid.NewGuid().ToString();
            FrameId = frameId;
            Attempt = attempt;
        }

        public string Id { get; set; }
        public string FrameId { get; set; }
        public int? Score { get; set; }
        public int Attempt { get; set; }
        public Frame Frame { get; set; } /* EF Relation */
    }
}