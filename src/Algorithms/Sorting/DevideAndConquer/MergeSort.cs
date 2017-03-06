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
                var inConstruction = new List<T[]>();
                for (int i = 0; i < bits.Count; i= i + 2)
                {
                    var left = bits[i];
                    if (HasToTheRight(i, bits))
                    {
                        inConstruction.Add(left);
                    }
                    else
                    {
                        var right = bits[i + 1];
                        var joinedArray = CombineAndSort(left, right);
                        inConstruction.Add(joinedArray);
                    }
                }

                bits = inConstruction;
            }

            return bits[0];
        }

        private static bool HasToTheRight<T>(int i, List<T[]> bits) where T : IComparable<T>
        {
            return i + 1 > bits.Count-1;
        }

        private static void MakeArraysOfOne<T>(T[] source, List<T[]> bits) where T : IComparable<T>
        {
            bits.AddRange(source.Select(t => new[] {t}));
        }

        private static T[] CombineAndSort<T>(T[] left, T[] right) where T : IComparable<T>
        {
            var result = new List<T>(left.Length + right.Length);
            if (left[0].IsSmallerThan(right[0]))
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
