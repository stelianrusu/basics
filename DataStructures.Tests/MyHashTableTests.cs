using System;
using System.Collections.Generic;
using System.Text;
using ArraysAndStrings.WarmUp;
using Xunit;

namespace Basics.AlgoTests
{
    public class MyHashtableTests
    {
        [Fact]
        public void CanAddNewItem()
        {
            MyHashTable<int, string> myList = new MyHashTable<int, string>();
            myList.Add(1, "one");
            string s = myList[1];

            Assert.Equal("one", s);
        }

    }
}
