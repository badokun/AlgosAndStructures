using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting.DevideAndConquer
{
    public class QuickSort
    {
        public static T[] Sort<T>(T[] source) where T : IComparable<T>
        {
            var partitionIndices = Enumerable.Range(0, source.Length).ToList();
            partitionIndices.Shuffle();
            
            var arrayInProgress = source;
            for (int i = 0; i < arrayInProgress.Length; i++)
            {
                var partitionIndex = partitionIndices[i];
                var partitionValue = arrayInProgress[partitionIndex];
                var left = Split(arrayInProgress, partitionIndex, Side.Left).ToArray();
                var right = Split(arrayInProgress, partitionIndex, Side.Right).ToArray();
                var leftStayOrGo = DoStayOrGo(left, partitionValue, Side.Left);
                var rightStayOrGo = DoStayOrGo(right, partitionValue, Side.Right);
                int c = 0;
                for (int j = 0; j < arrayInProgress.Length; j++)
                {
                    arrayInProgress[j] = default(T);
                }
                foreach (var item in leftStayOrGo.Stay)
                {
                    arrayInProgress[c] = item;
                    c++;
                }
                foreach (var item in rightStayOrGo.Go)
                {
                    arrayInProgress[c] = item;
                    c++;
                }
                
                foreach (var item in leftStayOrGo.Go)
                {
                    arrayInProgress[c] = item;
                    c++;
                }
                foreach (var item in rightStayOrGo.Stay)
                {
                    arrayInProgress[c] = item;
                    c++;
                }
            }

            return arrayInProgress;
        }

        private static StayOrGo<T> DoStayOrGo<T>(T[] items, T partitionValue, Side side) where T : IComparable<T>
        {
            var stayOrGo = new StayOrGo<T>();
            for (int i = 0; i < items.Length; i++)
            {
                switch (side)
                {
                    case Side.Left:
                        if (items[i].CompareTo(partitionValue) <= 0)
                        {
                            stayOrGo.Stay.Add(items[i]);
                        }
                        else
                        {
                            stayOrGo.Go.Add(items[i]);
                        }
                        break;
                    case Side.Right:
                        if (items[i].CompareTo(partitionValue) > 0)
                        {
                            stayOrGo.Stay.Add(items[i]);
                        }
                        else
                        {
                            stayOrGo.Go.Add(items[i]);
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(side), side, null);
                }
               
            }

            return stayOrGo;
        }

        private static IEnumerable<T> Split<T>(T[] source, int partitionIndex, Side side) where T : IComparable<T>
        {
            switch (side)
            {
                case Side.Left:
                    for (int i = 0; i < partitionIndex; i++)
                    {
                        yield return source[i];
                    }
                    break;
                case Side.Right:
                    for (int i = partitionIndex; i < source.Length; i++)
                    {
                        yield return source[i];
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(side), side, null);
            }
        }

        private enum Side
        {
            Left,
            Right
        }
    }

    internal class StayOrGo<T> where T : IComparable<T>
    {
        public StayOrGo()
        {
            Stay = new List<T>();
            Go = new List<T>();
        }
        public List<T> Stay { get; set; }
        public List<T> Go { get; set; }
    }

    

}