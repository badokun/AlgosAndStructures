using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LoyaltyPoints
{
    public class PointsEngine
    {
        private readonly List<Rule> _rules = new List<Rule>();
        public void AddRule(Rule rule)
        {
            _rules.Add(rule);
        }

        public IEnumerable<Score> CalculatePoints()
        {
            /*

            Rule 2: |------3------| 
            Rule 1:     |--------5--------| 
            Rule 3:         |----1----| 
            Result: |-3-|-8-|--9--|-6-|-5-| 

            Rule 1:     |--------5--------| 
            Rule 3:         |----1----| 
            Rule 2: |------3------| 
            Result: |-3-|-8-|--9--|-6-|-5-| 
            */
            var asc = _rules.OrderBy(r => r.Start).ToList();
            var first = asc.First();
            var start = first.Start;
            var end = first.End;
            var points = first.Points;
            for (int i = 1; i < asc.Count; i++)
            {
                var current = asc[i];
                yield return new Score(start, current.Start, points);
                start = current.Start;
                if (end > current.Start)
                {
                    points += current.Points;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            yield return new Score(start, end, points);


            var desc = _rules.OrderByDescending(r => r.End).ToList();
            var firstDesc = desc.First();
            start = firstDesc.Start;
            end = firstDesc.End;
            points = firstDesc.Points;
            for (int i = 1; i < desc.Count; i++)
            {
                var current = desc[i];
                yield return new Score(current.End, end, points);
                end = current.End;
                if (current.Start > start)
                {
                    points += current.Points;
                }
            }
        }
    }
}