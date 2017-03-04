using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Search;
using NUnit.Framework;

namespace AlgorithmTests.Search
{
    [TestFixture]
    public class SearchTests
    {
        [Test]
        public void TestBadMatchTable()
        {
            // Arrange

            // Act
            var badMatchTable = new BadMatchTable("TRUTH");

            // Assert
            Assert.AreEqual(1, badMatchTable.GetShift('T'));
            Assert.AreEqual(3, badMatchTable.GetShift('R'));
            Assert.AreEqual(2, badMatchTable.GetShift('U'));
            Assert.AreEqual(5, badMatchTable.GetShift('Z'));
        }

        [Test]
        public void TestSearch()
        {
            // Arrange
            var toSearch = "We hold these truths to be self-evident";
            var toFind = "truth";

            // Act
            var results = new BoyerMoore().Search(toFind, toSearch).ToList();

            // Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(toSearch.IndexOf(toFind, StringComparison.Ordinal), results[0].Start);
        }

        [Test]
        public void TestSearchIpsum()
        {
            // Arrange
            var toSearch =
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            var toFind = "of";

            // Act
            var results = new BoyerMoore().Search(toFind, toSearch).ToList();

            // Assert
            Assert.AreEqual(5, results.Count);
            Assert.AreEqual(toSearch.IndexOf(toFind, StringComparison.Ordinal), results[0].Start);

            
        }

    }
}
