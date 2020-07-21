using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists.WarmUp
{
    public class DoubleLinkedList<T> : IEnumerable<T>
    {
        private DoubleLinkedListNode<T> _head;

        public DoubleLinkedList()
        {
            
        }
        public DoubleLinkedList(IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                AddLast(value);
            }
        }
        public void AddLast(T value)
        {
            var newNode = new DoubleLinkedListNode<T>(value);
            if (_head == null)
            {
                _head = newNode;
                return;
            }

            var n = _head;
            while (n.Next != null)
                n = n.Next;
            newNode.Prev = n;
            n.Next = newNode;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var n = _head;
            while (n != null)
            {
                yield return n.Value;
                n = n.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public DoubleLinkedListNode<T> Head => this._head;

        public DoubleLinkedListNode<T> Last
        {
            get
            {
                if (_head == null)
                    return null;

                var n = _head;
                while (n.Next != null)
                    n = n.Next;

                return n;
            }
        }
        public DoubleLinkedListNode<T> Find(T value)
        {
            var n = _head;
            while (n != null)
            {
                if (n.Value.Equals(value))
                    return n;
                n = n.Next;
            }

            return null;
        }

        public void Remove(DoubleLinkedListNode<T> node)
        {
            if (node == _head)
            {
                _head = _head.Next;
                if (_head != null)
                    _head.Prev = null;
                return;
            }
            var n = _head;
            while (n != null && n!=node)
                n = n.Next;

            if(n == null)
                return;

            if (n.Prev != null)
                n.Prev.Next = n.Next;
            if (n.Next != null)
                n.Next.Prev = n.Prev;

         
        }

        public List<T> ToList()
        {
            List<T> l = new List<T>();
            foreach (var item in this)
            {
                l.Add(item);
            }

            return l;
        }
    }

    public class DoubleLinkedListNode<T>
    {
        public DoubleLinkedListNode(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }
        public DoubleLinkedListNode<T> Next { get; set; }
        public DoubleLinkedListNode<T> Prev { get; set; }


      
    }
}
