using System;

namespace Algorithms.LoyaltyPoints
{
    public class Score
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int Points { get; set; }
        public Score(int start, int end, int points)
        {
            Start = start;
            End = end;
            Points = points;
        }
    }
}
