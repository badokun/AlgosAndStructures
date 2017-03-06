using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Lists
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        private MyLinkedListNode<T> _head;
        private MyLinkedListNode<T> _current;

        public void Add(T item)
        {
            if (_head == null)
            {
                _head = new MyLinkedListNode<T>() {Value = item};
                _current = _head;
            }
            else
            {
                _current.Next = new MyLinkedListNode<T>() { Value = item };
                _current = _current.Next;
            }
        }

        public void RemoveLast()
        {
            var current = _head;

            var previous = current;
            while (current != null)
            {
                if (current.Next != null)
                {
                    previous = current;
                }
                current = current.Next;
            }
            previous.Next = null;
        }

        public void RemoveFirst()
        {
            _head = _head.Next;
        }


        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MyLinkedListNode<T>
    {
        public T Value { get; set; }
        public MyLinkedListNode<T> Next { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
