using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StacksAndQueues.Exercises;
using Xunit;

namespace Basics.AlgoTests
{
    public class StackAndQueuesTests
    {
        [Fact]
        public void StackWithArray()
        {
            StackWithArray stack = new StackWithArray();
            stack.Push(1);

            Assert.False(stack.IsEmpty);
            Assert.Equal(1, stack.Pop());
            Assert.True(stack.IsEmpty);

            stack.Push(1);
            stack.Push(2);

            Assert.Equal(2, stack.Pop());
        }

        [Fact]
        public void MultipleStackWithArray()
        {
            MultipleStackWithArray stack = new MultipleStackWithArray(3);

            stack.Push(1, 10);
            stack.Push(2, 20);
            stack.Push(3, 30);

            stack.Push(1, 10);
            stack.Push(1, 11);

            stack.Push(2, 20);
            stack.Push(2, 21);
            stack.Push(2, 22);

            stack.Push(3, 30);
            stack.Push(3, 31);
            stack.Push(3, 32);
            stack.Push(3, 33);

            Assert.Equal(11, stack.Pop(1));
            Assert.Equal(22, stack.Pop(2));
            Assert.Equal(33, stack.Pop(3));
        }

        [Fact]
        public void StackWithMin()
        {
            StackWithMin stack = new StackWithMin();
            stack.Push(1);
            stack.Push(3);

            Assert.Equal(1, stack.Min);

            stack.Push(0);
            Assert.Equal(0, stack.Min);

            stack.Pop();
            Assert.Equal(1, stack.Min);

        }

        [Fact]
        public void SortStack()
        {
            StackSorter sorter = new StackSorter();

            Stack<int> stack = new Stack<int>(new int[] { 2, 1, 5, 3, 7, 9, 10, 4 });

            sorter.Sort(stack);
        }
    }
}
