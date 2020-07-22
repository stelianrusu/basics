using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueues.Exercises
{
    public class StackWithArray
    {
        private int[] arr = new int[100];
        private int top = -1;

        public void Push(int el)
        {
            top++;
            arr[top] = el;
        }

        public int Pop()
        {
            if(top == -1)
                throw  new NotSupportedException();
            top--;
            return arr[top + 1];
        }

        public int Peek()
        {
            if (top == -1)
                throw new NotSupportedException();
            return arr[top];
        }

        public bool IsEmpty => top == -1;

    }
}
