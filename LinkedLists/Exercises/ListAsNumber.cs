using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedLists.WarmUp;

namespace LinkedLists.Exercises
{
    public class ListAsNumber
    {

        public SimpleLinkedList<int> Sum(SimpleLinkedList<int> list1, SimpleLinkedList<int> list2)
        {
            SimpleLinkedList<int> resultList = new SimpleLinkedList<int>();
            var n1 = list1.Head;
            var n2 = list2.Head;
            int carry = 0;
            while (n1 != null || n2 != null)
            {
                int op1 = 0, op2 = 0;
                if (n1 != null)
                    op1 = n1.Value;

                if (n2 != null)
                    op2 = n2.Value;

                int rez = op1 + op2 + carry;

                resultList.AddLast(rez % 10);
                carry = rez / 10;

                n1 = n1?.Next;
                n2 = n2?.Next;
            }

            if (carry == 1)
                resultList.AddLast(1);
            return resultList;
        }

        public SimpleLinkedList<int> SumReverse(SimpleLinkedList<int> list1, SimpleLinkedList<int> list2)
        {
            SimpleLinkedList<int> resultList = new SimpleLinkedList<int>();
            EqualizeLength(list1, list2);
            var n1 = list1.Head;
            var n2 = list2.Head;

            PartialSum result = BuildSum(n1, n2);
            resultList.AddFirst(result.Node.Value);
            if (result.Carry > 0)
                resultList.AddFirst(1);

            return resultList;
        }

        private PartialSum BuildSum(Node<int> n1, Node<int> n2)
        {
            if (n1 == null)
                return new PartialSum() { Node = null, Carry = 0 };
             
            var partialResult = BuildSum(n1.Next, n2.Next);
            PartialSum sum = new PartialSum();
            int result = n1.Value + n2.Value + partialResult.Carry;
            sum.Node = new Node<int>(result % 10);
            sum.Carry = result / 10;
            sum.Node.Next = partialResult.Node;

            return sum;
        }

        class PartialSum
        {
            public Node<int> Node { get; set; }
            public int Carry { get; set; }
        }
        private void EqualizeLength(SimpleLinkedList<int> list1, SimpleLinkedList<int> list2)
        {
            int length1 = 0;
            var n1 = list1.Head;
            while (n1 != null)
            {
                length1++;
                n1 = n1.Next;
            }

            int length2 = 0;
            var n2 = list2.Head;
            while (n2 != null)
            {
                length2++;
                n2 = n2.Next;
            }

            if (length1 > length2)
            {
                while (length1 > length2)
                {
                    list2.AddFirst(0);
                    length2++;
                }

                return;
            }

            if (length2 > length1)
            {
                while (length2 > length1)
                {
                    list1.AddFirst(0);
                    length1++;
                }
            }
        }
    }
}
