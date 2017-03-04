using System;
using System.Net;

namespace Algorithms.Sorting.Linear
{
    internal static class Shared
    {
        internal static void Swap<T>(T[] source, int left, int right) where T : IComparable<T>
        {
            if (left != right)
            {
                var temp = source[left];
                source[left] = source[right];
                source[right] = temp;
            }
        }

        internal static void Move<T>(T[] itemArray, int sourceValueIndex, int insertionIndex)
        {
            // Moves items to the right after inserting at a specific index
            // 2 3 5 4 1
            // 2 3 4 5 1
            var valueToBeMoved = itemArray[sourceValueIndex];
            var toRight = default(T);
            for (int i = insertionIndex; i < sourceValueIndex; i++)
            {
                T current;
                if (toRight.Equals(default(T)))
                {
                    current = itemArray[i];
                }
                else
                {
                    current = toRight;
                }

                toRight = itemArray[i + 1];
                itemArray[i + 1] = current;
            }

            itemArray[insertionIndex] = valueToBeMoved;
        }

        internal static bool IsSmallerThan<T>(this T left, T right) where T : IComparable<T>
        {
            return left.CompareTo(right) < 0;
        }

        internal static bool IsGreaterThan<T>(this T left, T right) where T : IComparable<T>
        {
            return left.CompareTo(right) > 0;
        }
    }
}