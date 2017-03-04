using System;
using System.Linq;

namespace Algorithms.Sorting.Linear
{
    public class InsertionSort
    {
        public static T[] Sort<T>(T[] source) where T : IComparable<T>
        {
            var itemArray = source.ToArray();

            for (int i = 1; i < itemArray.Length; i++)
            {
                var currentValue = itemArray[i];
                var oneBefore = itemArray[i - 1];
                if (IsSmallerThan<T>(currentValue, oneBefore))
                {
                    var currentValueIndex = i;
                    var insertionIndex = FindInsertionIndex<T>(itemArray, currentValueIndex, currentValue);
                    Shared.Move<T>(itemArray, currentValueIndex, insertionIndex);
                }
            }

            return itemArray;
        }

       


        private static int FindInsertionIndex<T>(T[] itemArray, int currentValueIndex, T currentValue) where T : IComparable<T>
        {
            for (int j = currentValueIndex-1; j >= 0; j--)
            {
                if (IsSmallerThan<T>(itemArray[j], currentValue))
                {
                    return j+1;
                }
            }
            return 0;
        }

        private static bool IsSmallerThan<T>(T current, T target) where T : IComparable<T>
        {
            return current.CompareTo(target) < 0;
        }
    }
}