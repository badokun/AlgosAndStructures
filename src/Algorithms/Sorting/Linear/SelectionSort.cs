using System;
using System.Linq;

namespace Algorithms.Sorting.Linear
{
    public class SelectionSort
    {
        public static T[] Sort<T>(T[] source) where T : IComparable<T>
        {
            var itemArray = source.ToArray();

            for (int currentIndex = 0; currentIndex < itemArray.Length; currentIndex++)
            {
                int smallestItemIndex = currentIndex;
                for (int scanningIndex = currentIndex; scanningIndex < itemArray.Length-1; scanningIndex++)
                {
                    var nextItem = itemArray[scanningIndex + 1];
                    var nextItemIndex = scanningIndex + 1;
                    var smallestItem = itemArray[smallestItemIndex];
                    if (nextItem.IsSmallerThan(smallestItem))
                    {
                        smallestItemIndex = nextItemIndex;
                    }
                }
                if (smallestItemIndex != 0 && smallestItemIndex != currentIndex)
                {
                    Shared.InsertAndShiftToRight(itemArray, smallestItemIndex, currentIndex);
                }
            }

            return itemArray;
        }
    }
}