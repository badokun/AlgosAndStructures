using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Sorting.Linear;

namespace Algorithms.Sorting.DevideAndConquer
{
    public class MergeSort
    {
        public static T[] Sort<T>(T[] source) where T : IComparable<T>
        {
            var bits = new List<T[]>(source.Length);
            MakeArraysOfOne(source, bits);
            
            // Eventually we'll end up again with one item containing the reconstructed array
            while (bits.Count > 1)
            {
                var inProgress = new List<T[]>();
                for (int i = 0; i < bits.Count; i= i + 2)
                {
                    if (i + 1 > bits.Count-1)
                    {
                        inProgress.Add(bits[i]);
                    }
                    else
                    {
                        var joinedArray = CombineAndSort(bits[i], bits[i + 1]);
                        inProgress.Add(joinedArray);
                    }
                }

                bits = inProgress;
            }

            return bits[0];
        }

        private static void MakeArraysOfOne<T>(T[] source, List<T[]> bits) where T : IComparable<T>
        {
            bits.AddRange(source.Select(t => new T[] {t}));
        }

        private static T[] CombineAndSort<T>(T[] left, T[] right) where T : IComparable<T>
        {
            var result = new List<T>(left.Length + right.Length);
            if (left[0].CompareTo(right[0]) < 0)
            {
                result.AddRange(left);
                result.AddRange(right);
            }
            else
            {
                result.AddRange(right);
                result.AddRange(left);
            }

            return BubbleSort.Sort(result.ToArray());
        }
    }
}
