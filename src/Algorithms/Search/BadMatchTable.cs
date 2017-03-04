using System.Collections.Generic;

namespace Algorithms.Search
{
    public class BadMatchTable
    {
        private readonly Dictionary<char, int> _distances;
        private readonly int _default;

        public BadMatchTable(string pattern)
        {
            /*
             *  TRUTH
             *  0321
             */
            _distances = new Dictionary<char, int>();
            _default = pattern.Length;
            for (var i = 0; i < pattern.Length-1; i++)
            {
                _distances[pattern[i]] = pattern.Length - i - 1;
            }
        }

        public int GetShift(char c)
        {
            return !_distances.ContainsKey(c) ? _default : _distances[c];
        }
    }
}