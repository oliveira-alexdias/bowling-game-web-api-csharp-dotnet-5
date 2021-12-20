using System;

namespace BowlingGame.Service.Exceptions
{
    public class GameHasBeenFinishedException : Exception
    {
        public GameHasBeenFinishedException() : base("You can no longer roll in this game because it has been finished")
        {
        }
    }
}