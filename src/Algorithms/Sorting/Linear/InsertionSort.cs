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
                var currentItem = itemArray[i];
                var left = itemArray[i - 1];
                if (currentItem.IsSmallerThan(left))
                {
                    var currentIndex = i;
                    var insertionIndex = FindInsertionIndex(itemArray, currentIndex, currentItem);
                    Shared.InsertAndShiftToRight(itemArray, currentIndex, insertionIndex);
                }
            }

            return itemArray;
        }

        private static int FindInsertionIndex<T>(T[] itemArray, int currenIndex, T itemToCompare) where T : IComparable<T>
        {
            for (int j = currenIndex-1; j >= 0; j--)
            {
                var currentItem = itemArray[j];
                if (currentItem.IsSmallerThan(itemToCompare))
                {
                    return j+1;
                }
            }
            return 0;
        }
         
    }
}