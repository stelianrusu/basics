using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedLists.WarmUp;

namespace LinkedLists.Exercises
{
    public class DupRemover
    {
        public void RemoveDuplicatesWithHashSet(DoubleLinkedList<int> list)
        {
            HashSet<int> duplicateTracker = new HashSet<int>();
            var cur = list.Head;
            while (cur != null)
            {
                if (duplicateTracker.Contains(cur.Value))
                    RemoveNode(cur);
                else
                    duplicateTracker.Add(cur.Value);

                cur = cur.Next;
            }
        }

        public void RemoveDuplicatesWithoutBuffer(DoubleLinkedList<int> list)
        {
            var cur = list.Head;
            while (cur != null)
            {
                var runner = cur.Next;
                while (runner != null)
                {
                    if(runner.Value == cur.Value)
                        RemoveNode(runner);
                    runner = runner.Next;
                }

                cur = cur.Next;
            }
            {
                
            }
        }

        private void RemoveNode(DoubleLinkedListNode<int> cur)
        {
            if (cur.Prev != null)
                cur.Prev.Next = cur.Next;
            if (cur.Next != null)
                cur.Next.Prev = cur.Prev;
        }
    }
}
