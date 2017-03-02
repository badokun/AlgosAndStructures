using System;

namespace AlgorithmTests.Sorting.Linear
{
    internal class SortingAlgo
    {
        internal string Name { get; set; }
        internal Func<int[], int[]> SortingFunc { get; set; }
    }
}