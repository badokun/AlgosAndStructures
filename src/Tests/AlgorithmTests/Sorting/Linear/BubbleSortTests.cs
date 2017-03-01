using System.Linq;
using Algorithms.Sorting.Linear;
using NUnit.Framework;


namespace AlgorithmTests.Sorting.Linear
{
    [TestFixture]
    public class BubbleSortTests
    {
        [Test]
        public void SameNumberOfItemsAreReturned()
        {
            // Arrange
            var source = new[] {1, 2, 3};

            // Act
            var result = BubbleSort.Sort(source);

            // Assert
            Assert.AreEqual(source.Count(), result.Count());
        }

        [Test]
        public void OrderItemsCorrectly()
        {
            // Arrange
            var source = new[] { "d","c", "b", "a" };

            // Act
            var result = BubbleSort.Sort(source).ToList();

            // Assert
            Assert.AreEqual(source.Count(), result.Count());
            Assert.AreEqual("a.b.c.d", string.Join(".", result));
        }
    }
}
