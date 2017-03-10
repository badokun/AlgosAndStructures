using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LoyaltyPoints
{
    public class PointsEngine
    {
        enum SortOrder { Asc, Desc}
        private readonly List<Rule> _rules = new List<Rule>();
        public void AddRule(Rule rule)
        {
            _rules.Add(rule);
        }

        private IEnumerable<Score> CalculatePoints(
            Rule[] sortedRules, 
            Func<Rule, int> startFunc, 
            Func<Rule, int> endFunc,
            SortOrder sortOrder )
        {
            var firstRule = sortedRules.First();
            var leftWall = startFunc(firstRule);
            var rightWall = endFunc(firstRule);
            var points = firstRule.Points;
            for (int i = 1; i < sortedRules.Length; i++)
            {
                var current = sortedRules[i];
                var currentStart = startFunc(current);

                if (sortOrder == SortOrder.Asc)
                {
                    yield return new Score(leftWall, currentStart, points);
                }
                else
                {
                    yield return new Score(currentStart, leftWall, points);
                }

                leftWall = currentStart;

                if (sortOrder == SortOrder.Asc)
                {
                    if (rightWall > currentStart)
                    {
                        points += current.Points;
                    }
                }
                else
                {
                    if (rightWall < currentStart)
                    {
                        points += current.Points;
                    }
                }
            }

            if (sortOrder == SortOrder.Asc)
            {
                yield return new Score(leftWall, rightWall, points);
            }
            
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
            var asc = _rules.OrderBy(r => r.Start).ToArray();
            var score = new List<Score>();
            score.AddRange(CalculatePoints(
                asc, rule => rule.Start, rule => rule.End, SortOrder.Asc));
            var desc = _rules.OrderByDescending(r => r.End).ToArray();
            score.AddRange(CalculatePoints(desc, rule => rule.End, rule => rule.Start,
                SortOrder.Desc));

            return score;
        }
    }
}