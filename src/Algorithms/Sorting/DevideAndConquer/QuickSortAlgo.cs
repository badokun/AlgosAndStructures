using System;

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
                var p = Partition<T>(source, lo, hi);
                Quicksort<T>(source, lo, p - 1);
                Quicksort<T>(source, p + 1, hi);
            }
        }

        private static int Partition<T>(T[] source, int lo, int hi) where T : IComparable<T>
        {
            var pivot = source[hi];
            var i = lo - 1;
            for (int j = lo; j < hi; j++)
            {
                if (source[j].CompareTo(pivot) <= 0)
                {
                    i = i + 1;
                    Swap(source, i, j);
                }
            }
            Swap(source, hi, i + 1);
            return i + 1;
        }

        private static void Swap<T>(T[] source, int left, int right) where T : IComparable<T>
        {
            if (left != right)
            {
                var temp = source[left];
                source[left] = source[right];
                source[right] = temp;
                //Debug.WriteLine(string.Join(" ", source));
            }
        }

    }
}