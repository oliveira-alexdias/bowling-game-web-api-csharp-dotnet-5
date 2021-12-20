using System.Collections.Generic;
using BowlingGame.Service.Entities;
using BowlingGame.Service.ObjectOfValues;

namespace BowlingGame.Service.Factories
{
    public class FrameFactory
    {
        public static List<Frame> CreateList(string gameId)
        {
            var frames = new List<Frame>();

            for (var i = 1; i <= Constants.NumberOfFrames; i++)
            {
                var frame = new Frame(gameId, i);
                frame.Rolls = RollFactory.CreateList(frame.Id, i);
                frames.Add(frame);
            }

            return frames;
        }
    }
}