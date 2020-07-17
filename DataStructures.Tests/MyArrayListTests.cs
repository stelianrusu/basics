using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ArraysAndStrings.WarmUp;
using Xunit;

namespace Basics.AlgoTests
{
    public class MyArrayListTests
    {
        [Fact]
        public void CanAddNewItem()
        {
            MyArrayList<int> myList = new MyArrayList<int>();
            myList.Add(1);

            Assert.Equal(1, myList[0]);
        }

        [Fact]
        public void CanIncrease()
        {
            MyArrayList<int> myList = new MyArrayList<int>(1);
            myList.Add(1);
            myList.Add(2);

            Assert.Equal(2, myList[1]);
        }

        [Fact]
        public void CanCalculateLength()
        {
            ArrayList a = new ArrayList();
            MyArrayList<int> myList = new MyArrayList<int>(1);
            myList.Add(1);

            Assert.Equal(1, myList.Length);
        }
    }
}
