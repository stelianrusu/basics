using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueues.Exercises
{
    public class MultipleStackWithArray
    {
        private readonly int _stackCount;
        private int[] arr = new int[100];
        private int[] tops;
        public MultipleStackWithArray(int stackCount)
        {
            _stackCount = stackCount;
            tops = new int[stackCount];
            for (int i = 0; i < stackCount; i++)
            {
                tops[i] = -1 - i;
            }
        }
        

        public void Push(int stackNumber, int el)
        {
            IncreaseTop(stackNumber);
            SetTopValue(stackNumber, el);
        }

        private void SetTopValue(int stackNumber, int el)
        {
            arr[GetTopIndex(stackNumber)] = el;
        }

        private void IncreaseTop(int stackNumber)
        {
            int currentTop = GetTopIndex(stackNumber);
            currentTop += _stackCount;
            tops[stackNumber - 1] = currentTop;
        }

        private void DecreaseTop(int stackNumber)
        {
            int currentTop = GetTopIndex(stackNumber);
            currentTop -= _stackCount;
            tops[stackNumber - 1] = currentTop;
        }

        private int GetTopIndex(int stackNumber)
        {
            return tops[stackNumber -1];
        }

        public int Pop(int stackNumber)
        {
            if(tops[stackNumber - 1] < 0)
                throw  new NotSupportedException();
            int val = arr[GetTopIndex(stackNumber)];
            DecreaseTop(stackNumber);
            return val;
        }

        public int Peek(int stackNumber)
        {
            if (tops[stackNumber] < 0)
                throw new NotSupportedException();
            return arr[GetTopIndex(stackNumber)];
        }
    }
}
