using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Sorting.DevideAndConquer;
using Algorithms.Sorting.Linear;
using NUnit.Framework;

namespace AlgorithmTests.Sorting.Linear
{
    public class SortingAlgosSource
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
                Name = "QuickSortAlgo",
                SortingFunc = QuickSortAlgo.Sort
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
}