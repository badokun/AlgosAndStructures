namespace Algorithms.Sorting.Linear
{
    internal class Shared
    {
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
    }
}