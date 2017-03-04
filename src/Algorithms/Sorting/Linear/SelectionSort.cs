using System;
using System.Linq;

namespace Algorithms.Sorting.Linear
{
    public class SelectionSort
    {
        public static T[] Sort<T>(T[] source) where T : IComparable<T>
        {
            var itemArray = source.ToArray();

            for (int i = 0; i < itemArray.Length; i++)
            {
                int smallestItemIndex = i;
                for (int j = i; j < itemArray.Length-1; j++)
                {
                    if (itemArray[j + 1].CompareTo(itemArray[smallestItemIndex]) < 0)
                    {
                        smallestItemIndex = j + 1;
                    }
                }
                if (smallestItemIndex != 0 && smallestItemIndex != i)
                {
                    Shared.Move(itemArray, smallestItemIndex, i);
                }
            }

            return itemArray;
        }
    }
}