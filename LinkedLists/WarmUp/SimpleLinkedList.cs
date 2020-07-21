using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists.WarmUp
{
    public class SimpleLinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head = null;
        public SimpleLinkedList()
        {
        }

        public SimpleLinkedList(IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                AddLast(value);
            }
        }

        public void AddLast(T value)
        {
            if (_head == null)
            {
                _head = new Node<T>(value);
                return;
            }

            var n = _head;
            while (n.Next != null)
                n = n.Next;

            n.Next = new Node<T>(value);
        }

        public void AddFirst(T value)
        {
            var node = new Node<T>(value) {Next = _head};
            this._head = node;
        }
        public Node<T> Head => this._head;

        public Node<T> Last
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

        public Node<T> Find(T value)
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

        public void Remove(Node<T> node)
        {
            if (_head == node)
            {
                _head = _head.Next;
                return;
            }
            var n = _head.Next;
            var prev = _head;
            while (n != null)
            {
                if (n == node)
                {
                    prev.Next = n.Next;
                    return;
                }

                prev = n;
                n = n.Next;
            }
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

        public void RearrangePairs()
        {
            if(_head == null)
                return;

            Node<T> slow = _head;
            Node<T> fast = _head;

            while (fast != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }

            var cur = _head;
            while (slow != null)
            {
                var nextCur = cur.Next;
                var nextSlow = slow.Next;

                cur.Next = slow;
                if(slow.Next != null)
                    slow.Next = nextCur;

                cur = nextCur;
                slow = nextSlow;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
}
