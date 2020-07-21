using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using LinkedLists.WarmUp;

namespace LinkedLists.Exercises
{
    public class Partitioner
    {
        public void PartitionAt(SimpleLinkedList<int> list, int partitionValue)
        {
            if (list.Head == null)
                return;

            var prev = list.Head;
            var cur = list.Head.Next;
            while (cur != null)
            {
                if (cur.Value < partitionValue)
                {
                    prev.Next = cur.Next;
                    cur.Next = list.Head;
                    cur = prev.Next;
                }
                else
                {
                    prev = prev.Next;
                    cur = cur.Next;
                }
            }
            ;
        }
    }
}
