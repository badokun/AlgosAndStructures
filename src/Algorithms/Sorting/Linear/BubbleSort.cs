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
                bool hasSwitched = false;
                for (int i = 0; i < source.Length-1; i++)
                {
                    if (source[i].CompareTo(source[i + 1]) > 0)
                    {
                        var tempLeft = source[i];
                        var tempRight = source[i+1];
                        source[i] = tempRight;
                        source[i + 1] = tempLeft;
                        hasSwitched = true;
                    }
                }
                allSorted = hasSwitched == false;
            }

            return source;
        } 
    }
}
