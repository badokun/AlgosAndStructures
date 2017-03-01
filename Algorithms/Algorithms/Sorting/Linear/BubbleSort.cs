using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting.Linear
{
    //Comparisons
    //Swaps

    public class BubbleSort 
    {
        public static IEnumerable<T> Sort<T>(IEnumerable<T> source) where T : IComparable<T>
        {
            var itemArray = source.ToArray();
            var allSorted = false;
            while (!allSorted)
            {
                bool hasSwitched = false;
                for (int i = 0; i < itemArray.Length-1; i++)
                {
                    if (itemArray[i].CompareTo(itemArray[i + 1]) > 0)
                    {
                        var tempLeft = itemArray[i];
                        var tempRight = itemArray[i+1];
                        itemArray[i] = tempRight;
                        itemArray[i + 1] = tempLeft;
                        hasSwitched = true;
                    }
                }
                allSorted = hasSwitched == false;
            }

            return itemArray;
        } 
    }
}
