using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class Hashtable<T>
    {
        private LinkedList<T>[] _source;
        private int _fillCount;
        private const int MaxFillFactor = 40;

        public Hashtable()
        {
            _source = new LinkedList<T>[10];
            _fillCount = 0;
        }
        public void Add(T item)
        {
            if (FillFactor() >= MaxFillFactor)
            {
                _fillCount = 0;
                var recreatedList = new LinkedList<T>[_source.Length*2];
                foreach (var sourceItem in _source)
                {
                    if (sourceItem != null)
                    {
                        foreach (var singleItem in sourceItem)
                        {
                            AddToSource(recreatedList, singleItem);
                        }
                    }
                }
                _source = recreatedList;
            }
            else
            {
                AddToSource(_source, item);
            }
        }

        private int FillFactor()
        {
            var v = (double)_fillCount / _source.Length * 100;
            return (int)v;
        }

        private void AddToSource(LinkedList<T>[] source, T item)
        {
            var index = Math.Abs(item.GetHashCode())% source.Length;
            if (source[index] == null)
            {
                source[index] = new LinkedList<T>();
                source[index].AddFirst(item);
                _fillCount++;
            }
            else
            {
                source[index].AddLast(item);
            }
        }
    }
}
