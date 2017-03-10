using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.LoyaltyPoints;
using NUnit.Framework;

namespace AlgorithmTests.LoyaltyPoints
{
    [TestFixture]
    public class PointsEngineTests
    {
        [Test]
        public void TestPoints()
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

            // Arrange
            var engine = new PointsEngine();
            engine.AddRule(new Rule() { Start = 5, End = 30, Points = 5 });
            engine.AddRule(new Rule() { Start = 10, End =  25, Points = 1 });
            engine.AddRule(new Rule() { Start = 1, End = 15, Points = 3 });

            // Act
            var results = engine.CalculatePoints().OrderBy(r => r.Start).ToList();

            // Assert
            AssertRule(results[0].Start, results[0].End, results[0].Points,
                1,5,3);
            AssertRule(results[1].Start, results[1].End, results[1].Points,
                5, 10, 8);
            AssertRule(results[2].Start, results[2].End, results[2].Points,
                10, 15, 9);

            AssertRule(results[3].Start, results[3].End, results[3].Points,
               15, 25, 6);
            AssertRule(results[4].Start, results[4].End, results[4].Points,
               25, 30, 5);

            Assert.AreEqual(5, results.Count);
        }

        private void AssertRule(int start, int end, int points, 
            int expectedStart,
            int expectedEnd,
            int expectedPoints)
        {
            Assert.AreEqual(expectedStart, start);
            Assert.AreEqual(expectedEnd, end);
            Assert.AreEqual(expectedPoints, points);
        }
    }
}
