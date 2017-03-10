using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms;
using NUnit.Framework;

namespace AlgorithmTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestCase("status", 2)]
        [TestCase("stattusat", 5)]
        public void FindIndexOfNonRepeated(string input, int index)
        {
            // Arrange

            // Act
            var result =StringCalculator.FindIndexOfNonRepeated(input);

            // Assert
            Assert.AreEqual(index, result);
        }
    }
}
