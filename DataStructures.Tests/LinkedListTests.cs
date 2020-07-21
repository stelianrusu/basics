using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedLists.Exercises;
using LinkedLists.WarmUp;
using Xunit;

namespace Basics.AlgoTests
{
    public class LinkedListTests
    {
        [Fact]
        public void CheckListImplementation()
        {
            var myList = new SimpleLinkedList<int>();
            List<int> netList = new List<int>();
            myList.AddFirst(1);
            foreach (var i in myList)
            {
                netList.Add(i);
            }
            LinkedList<int> nwtList = new LinkedList<int>();

            Assert.Equal(1, netList[0]);

            myList.AddFirst(0);
            Assert.Equal(0, myList.Head.Value);
            Assert.Equal(1, myList.Last.Value);

            SimpleLinkedList<int> my3 = new SimpleLinkedList<int>(new[] { 1, 2, 3 });

            var node2 = my3.Find(2);
            my3.Remove(node2);

            netList.Clear();
            foreach (var i in my3)
            {
                netList.Add(i);
            }

            Assert.Equal(1, netList[0]);
            Assert.Equal(3, netList[1]);

            my3.Remove(my3.Head);

            netList.Clear();
            foreach (var i in my3)
            {
                netList.Add(i);
            }
            Assert.Equal(3, netList[0]);


        }

        [Fact]
        public void Rearange()
        {
            var myList = new SimpleLinkedList<int>(new[] { 1, 3, 5, 2, 4, 6 });
            myList.RearrangePairs();

            var netList = new List<int>();
            foreach (var i in myList)
            {
                netList.Add(i);
            }

            Assert.Equal(1, netList[0]);
            Assert.Equal(2, netList[1]);
            Assert.Equal(3, netList[2]);
            Assert.Equal(4, netList[3]);
            Assert.Equal(5, netList[4]);
            Assert.Equal(6, netList[5]);
        }

        [Fact]
        public void CheckDoubleListImplementation()
        {
            var myList = new DoubleLinkedList<int>();
            List<int> netList = new List<int>();
            myList.AddLast(1);
            foreach (var i in myList)
            {
                netList.Add(i);
            }
            LinkedList<int> nwtList = new LinkedList<int>();

            Assert.Equal(1, netList[0]);

            myList.AddLast(0);
            Assert.Equal(1, myList.Head.Value);
            Assert.Equal(0, myList.Last.Value);

            DoubleLinkedList<int> my3 = new DoubleLinkedList<int>(new[] { 1, 2, 3 });

            var node2 = my3.Find(2);
            my3.Remove(node2);

            netList.Clear();
            foreach (var i in my3)
            {
                netList.Add(i);
            }

            Assert.Equal(1, netList[0]);
            Assert.Equal(3, netList[1]);

            my3.Remove(my3.Head);

            netList.Clear();
            foreach (var i in my3)
            {
                netList.Add(i);
            }
            Assert.Equal(3, netList[0]);

            var my2List = new DoubleLinkedList<int>(new int[] { 1, 2, 3 });
            my2List.Remove(my2List.Find(3));
            my2List.Remove(my2List.Find(1));
            my2List.Remove(my2List.Find(2));

            Assert.Null(my2List.Head);
        }

        [Fact]
        public void RemoveDuplicatesWithHashSet()
        {
            DupRemover r = new DupRemover();

            var linkedList = new DoubleLinkedList<int>(new int[] { 1, 2, 2, 1, 3, 4, 24, 5, 4 });
            r.RemoveDuplicatesWithHashSet(linkedList);
            var result = linkedList.ToList();


        }

        [Fact]
        public void RemoveDuplicatesWithRunner()
        {
            DupRemover r = new DupRemover();

            var linkedList = new DoubleLinkedList<int>(new int[] { 1, 2, 2, 1, 3, 4, 24, 5, 4 });
            r.RemoveDuplicatesWithoutBuffer(linkedList);
            var result = linkedList.ToList();


        }

        [Fact]
        public void KthElement()
        {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>(new int[] { 1, 2, 3, 4, 5 });
            ElementFinder finder = new ElementFinder();
            Node<int> el = finder.FindFromBackRevursion(2, list);
            Assert.Equal(4, el.Value);
        }

        [Fact]
        public void KthElementIteration()
        {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>(new int[] { 1, 2, 3, 4, 5 });
            ElementFinder finder = new ElementFinder();
            Node<int> el = finder.FindFromBackIteration(2, list);
            Assert.Equal(4, el.Value);
        }
        [Fact]
        public void Partitioner()
        {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>(new int[] { 3, 5, 8, 5, 10, 1, 2 });
            Partitioner p = new Partitioner();
            p.PartitionAt(list, 5);

        }

        [Fact]
        public void ListAsNumber()
        {
            ListAsNumber lan = new ListAsNumber();
            var result = lan.Sum(new SimpleLinkedList<int>(new int[] { 6, 1, 7 }),
                new SimpleLinkedList<int>(new int[] { 2, 9, 5 }));
        }

        [Fact]
        public void ListAsNumberReverse()
        {
            ListAsNumber lan = new ListAsNumber();
            var result = lan.SumReverse(new SimpleLinkedList<int>(new int[] { 6, 1, 7 }),
                new SimpleLinkedList<int>(new int[] { 2, 9, 5 }));

        }

        [Fact]
        public void Palindrome()
        {
            Palindrome pal = new Palindrome();
            var result = pal.Check(new SimpleLinkedList<int>(new int[] { 1,2, 1 }));
            Assert.True(result);
        }
    }
}
