using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Sorting.DevideAndConquer;
using Algorithms.Sorting.Linear;
using NUnit.Framework;

namespace AlgorithmTests.Sorting.Linear
{
    [TestFixture]
    public class GenericSortTests
    {
        [TestCaseSource(typeof (SortingFunctionsSource), "Linear")]
        public void OrderItemsCorrectly(string name, Func<int[], int[]> sortingFunction)
        {
            // Arrange
            var source = GetRandomSource(1000).ToArray();
            
            // Act
            var result = sortingFunction(source).ToList();
            Console.WriteLine(string.Join(".", source));

            // Assert
            // Compare against .NET built in sorting
            Assert.AreEqual(string.Join(".", source.OrderBy(i => i)), string.Join(".", result));
            Assert.AreEqual(source.Count(), result.Count());
        }

        [TestCaseSource(typeof(SortingFunctionsSource), "Linear")]
        public void OrderItemsCorrectlyFixedSource(string name, Func<int[], int[]> sortingFunction)
        {
            // Arrange
            var source = new[] { 4, 2, 9, 15, 13, 8, 7, 18, 2, 12 };

            // Act
            var result = sortingFunction(source).ToList();
            Console.WriteLine(string.Join(".", source));

            // Assert
            // Compare against .NET built in sorting
            Assert.AreEqual("2.2.4.7.8.9.12.13.15.18", string.Join(".", result));
        }

        [TestCaseSource(typeof(SortingFunctionsSource), "Linear")]
        public void OrderItemsCorrectlyFixedSourceAsInExample(string name, Func<int[], int[]> sortingFunction)
        {
            // Arrange
            var source = new[] {3, 8, 2, 1, 5, 4, 6, 7, 1};

            // Act
            var result = sortingFunction(source).ToList();
            Console.WriteLine(string.Join(".", source));
            Console.WriteLine(string.Join(".", result));

            // Assert
            // Compare against .NET built in sorting
            Assert.AreEqual("1.1.2.3.4.5.6.7.8", string.Join(".", result));
        }

        private IEnumerable<int> GetRandomSource(int i)
        {
            var random = new Random(1);
            for (int j = 0; j < i; j++)
            {
                yield return random.Next();
            }
        }
    }

    public class SortingFunctionsSource
    {
        public static IEnumerable Linear
        {
            get
            {
                return GetAll().Select(algo => new TestCaseData(algo.Name, algo.SortingFunc));
            }
        }

        private static IEnumerable<SortingAlgo> GetAll()
        {
            yield return new SortingAlgo()
            {
                Name = "MergeSort",
                SortingFunc = MergeSort.Sort
            };

            yield return new SortingAlgo()
            {
                Name = "SelectionSort",
                SortingFunc = SelectionSort.Sort
            };

            yield return new SortingAlgo()
            {
                Name = "BubbleSort",
                SortingFunc = BubbleSort.Sort
            };

            yield return new SortingAlgo()
            {
                Name = "InsertionSort",
                SortingFunc = InsertionSort.Sort
            };

            
        } 
    }

    internal class SortingAlgo
    {
        internal string Name { get; set; }
        internal Func<int[], int[]> SortingFunc { get; set; }
    }
}