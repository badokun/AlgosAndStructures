using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class Hashtable<TKey, TValue>
    {
         
        private LinkedList<KeyValuePair<TKey, TValue>>[] _source;
        private int _fillCount;
        private const int MaxFillFactor = 40;

        public Hashtable()
        {
            _source = new LinkedList<KeyValuePair<TKey, TValue>>[10];
            _fillCount = 0;
        }

        public void Add(TKey key, TValue item)
        {
            if (FillFactor() >= MaxFillFactor)
            {
                _fillCount = 0;
                var recreatedList = new LinkedList<KeyValuePair<TKey, TValue>>[_source.Length*2];
                foreach (var sourceItem in _source)
                {
                    if (sourceItem != null)
                    {
                        foreach (var singleItem in sourceItem)
                        {
                            AddToSource(recreatedList, singleItem.Key, singleItem.Value);
                        }
                    }
                }
                _source = recreatedList;
            }


            AddToSource(_source, key, item);
        }

        private int FillFactor()
        {
            var v = (double)_fillCount / _source.Length * 100;
            return (int)v;
        }

        private void AddToSource(LinkedList<KeyValuePair<TKey, TValue>>[] source, TKey key, TValue item)
        {
            var index = GetIndex(source, key);
            if (source[index] == null)
            {
                source[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
                source[index].AddFirst(new KeyValuePair<TKey, TValue>(key, item));
                _fillCount++;
            }
            else
            {
                source[index].AddLast(new KeyValuePair<TKey, TValue>(key, item));
            }
        }

        private static int GetIndex(LinkedList<KeyValuePair<TKey, TValue>>[] source, TKey key)
        {
            var index = Math.Abs(key.GetHashCode())%source.Length;
            return index;
        }

        public bool Remove(TKey key)
        {
            var index = GetIndex(_source, key);
            var linkedList = _source[index];
            if (linkedList.Count == 1)
            {
                _source[index] = null;
                _fillCount --;
                return true;
            }

            var current = linkedList.First;
            while (current != null)
            {
                if (current.Value.Key.Equals(key))
                {
                    linkedList.Remove(current);
                    return true;
                }

                current = current.Next;
            }

            return false;

        }
    }
}
