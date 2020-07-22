using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueues.Exercises
{
    public class StackWithMin
    {
        private StackWithMinNode top;

        public void Push(int value)
        {
            var newNode = new StackWithMinNode()
            {
                Value = value,
            };


            if (top == null)
            {
                top = newNode;
                newNode.MinBeneathMe = newNode;
                return;
            }

            newNode.Next = top;
            newNode.MinBeneathMe = value >= top.MinBeneathMe.Value ? top.MinBeneathMe : newNode;
            top = newNode;
        }

        public int Pop()
        {
            int value = top.Value;
            top = top.Next;

            return value;
        }

        public int Min => top.MinBeneathMe.Value;
    }

    public class StackWithMinNode
    {
        public int Value { get; set; }
        public StackWithMinNode Next { get; set; }
        public StackWithMinNode MinBeneathMe { get; set; }
    }
}
