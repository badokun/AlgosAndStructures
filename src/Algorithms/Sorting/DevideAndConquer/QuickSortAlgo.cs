using System;
using Algorithms.Sorting.Linear;

namespace Algorithms.Sorting.DevideAndConquer
{
    public class QuickSortAlgo
    {
        public static T[] Sort<T>(T[] source) where T : IComparable<T>
        {
            Quicksort(source, 0, source.Length-1);
            return source;
        }

        private static void Quicksort<T>(T[] source, int lo, int hi) where T : IComparable<T>
        {
            if (lo < hi)
            {
                var p = Partition(source, lo, hi);
                Quicksort(source, lo, p - 1);
                Quicksort(source, p + 1, hi);
            }
        }

        private static int Partition<T>(T[] source, int lo, int hi) where T : IComparable<T>
        {
            var pivot = source[hi];
            var wallIndex = lo - 1;
            for (int j = lo; j < hi; j++)
            {
                if (source[j].IsSmallerOrEqualThan(pivot))
                {
                    // Move wallIndex to right
                    wallIndex = wallIndex + 1;
                    Shared.Swap(source, wallIndex, j);
                }
            }

            Shared.Swap(source, hi, wallIndex + 1);
            return wallIndex + 1;
        }

        

    }
}