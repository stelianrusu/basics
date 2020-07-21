using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedLists.WarmUp;

namespace LinkedLists.Exercises
{
    public class ElementFinder
    {
        private int _kthFromEnd;

        public Node<int> FindFromBackRevursion(int kthFromEnd, SimpleLinkedList<int> list)
        {
            _kthFromEnd = kthFromEnd;
            IterateBack(list.Head);
            return _kthNode;
        }

        private int curIndex = 0;
        private Node<int> _kthNode;

        private void IterateBack(Node<int> cur)
        {
            if (cur.Next != null)
                IterateBack(cur.Next);
            curIndex++;

            if (curIndex == _kthFromEnd)
                _kthNode = cur;

            
           
        }

        public Node<int> FindFromBackIteration(int kthFromEnd, SimpleLinkedList<int> list)
        {
            var p1 = list.Head;
            var p2 = list.Head;

            int delta = 0;
            while (delta < kthFromEnd && p2 != null)
            {
                p2 = p2.Next;
                delta++;
            }

            if (delta < kthFromEnd)
                return null;

            while (p2 != null)
            {
                p2 = p2.Next;
                p1 = p1.Next;
            }

            return p1;
        }
    }
}
