using System;

namespace Algorithms.Sorting.Linear
{
    public class BubbleSort 
    {
        public static T[] Sort<T>(T[] source) where T : IComparable<T>
        {
            var allSorted = false;
            while (!allSorted)
            {
                bool itemPushedToTheEnd = false;
                for (int i = 0; i < source.Length-1; i++)
                {
                    var currentItem = source[i];
                    var right = source[i + 1];
                    if (currentItem.IsGreaterThan(right))
                    {
                        Shared.Swap(source, i, i + 1);
                        itemPushedToTheEnd = true;
                    }
                }

                allSorted = itemPushedToTheEnd == false;
            }

            return source;
        } 
    }

    
}
