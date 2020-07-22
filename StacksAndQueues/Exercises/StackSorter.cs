using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueues.Exercises
{
    public class StackSorter
    {
        private Stack<int> sortedStack = new Stack<int>();
        public void Sort(Stack<int> target)
        {
            sortedStack.Push(target.Pop());
            while (target.Count > 0)
            {
                int positionedNumber = target.Pop();
                int popedFromSorted = 0;
                while (sortedStack.Count > 0 && sortedStack.Peek() > positionedNumber)
                {
                    target.Push(sortedStack.Pop());
                    popedFromSorted++;
                }

                sortedStack.Push(positionedNumber);
                for (int i = 0; i < popedFromSorted; i++)
                    sortedStack.Push(target.Pop());
            }

            while (sortedStack.Count > 0)
            {
                target.Push(sortedStack.Pop());
            }
        }
    }
}
