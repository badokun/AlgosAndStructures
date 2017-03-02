using System.Linq;
using Algorithms.Sorting.Linear;
using NUnit.Framework;

namespace AlgorithmTests.Sorting.Linear
{
    [TestFixture]
    public class InsertionSortTests
    {
        [Test]
        public void SameNumberOfItemsAreReturned()
        {
            // Arrange
            var source = new[] { 1, 2, 3 };

            // Act
            var result = InsertionSort.Sort(source);

            // Assert
            Assert.AreEqual(source.Count(), result.Count());
        }

        [Test]
        public void OrderItemsCorrectly()
        {
            // Arrange
            // 4.2.9.15.13.8.7.18.2.12
            var source = new[] { 4,2,9,15,13,8,7,18,2,12 };

            // Act
            var result = InsertionSort.Sort(source).ToList();

            // Assert
            Assert.AreEqual(source.Count(), result.Count());
            Assert.AreEqual("2.2.4.7.8.9.12.13.15.18", string.Join(".", result));
        }
    }
}