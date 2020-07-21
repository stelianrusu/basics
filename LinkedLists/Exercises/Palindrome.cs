using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedLists.WarmUp;

namespace LinkedLists.Exercises
{
    public class Palindrome
    {
        public bool Check(SimpleLinkedList<int> list)
        {
            if (list.Head?.Next == null)
                return true;

            var slow = list.Head;
            var fast = list.Head;
            Stack<int> stack = new Stack<int>();
            while (fast?.Next != null)
            {
                stack.Push(slow.Value);

                slow = slow.Next;
                fast = fast.Next.Next;
            }

            if (fast != null)
                slow = slow.Next;

            while (slow != null)
            {
                int topStack = stack.Pop();
                if (topStack != slow.Value)
                    return false;
                slow = slow.Next;
            }

            return true;
        }
    }
}
