using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Algorithms.Sorting.Linear
{
    public class InsertionSort
    {
        public static IEnumerable<T> Sort<T>(IEnumerable<T> source) where T : IComparable<T>
        {
            var itemArray = source.ToArray();

            for (int i = 1; i < itemArray.Length; i++)
            {
                if (IsSmallerThan<T>(itemArray[i], itemArray[i - 1]))
                {
                    var currentValue = itemArray[i];
                    var currentValueIndex = i;
                    var insertionIndex = FindInsertionIndex<T>(itemArray, currentValueIndex, currentValue);
                    Move<T>(itemArray, currentValueIndex, insertionIndex);
                   
                }
            }

            return itemArray;
        }

        private static void Move<T>(T[] itemArray, int currentValueIndex, int insertionIndex)
        {
            for (int i = currentValueIndex; i > 0; i--)
            {
                var left = itemArray[i - 1];
                var middle = itemArray[i];
                itemArray[i - 1] = middle;
                itemArray[i] = left;
            }
        }


        private static int FindInsertionIndex<T>(T[] itemArray, int currentValueIndex, T currentValue) where T : IComparable<T>
        {
            for (int j = currentValueIndex-1; j >= 0; j--)
            {
                if (IsSmallerThan<T>(itemArray[j], currentValue))
                {
                    return j;
                }
            }
            return 0;
        }

        private static bool IsGreaterThan<T>(T current, T target) where T : IComparable<T>
        {
            return current.CompareTo(target) > 0;
        }

        private static bool IsSmallerThan<T>(T current, T target) where T : IComparable<T>
        {
            return current.CompareTo(target) < 0;
        }
    }
}