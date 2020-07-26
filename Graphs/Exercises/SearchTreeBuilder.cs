using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Exercises
{
    public class SearchTreeBuilder
    {
        public SearchNode BuildFromSortedArray(int[] arr)
        {
            return BuildNode(arr, 0, arr.Length - 1);

        }

        private SearchNode BuildNode(int[] arr, int left, int right)
        {

            int middle = (left + right + 1) / 2;
            SearchNode node = new SearchNode(){Value = arr[middle]};
            if (left == right)
                return node;

            node.Left = BuildNode(arr, left, middle - 1);
            if(right > middle)
                node.Right = BuildNode(arr, middle + 1, right);

            return node;
        }
    }

    public class SearchNode
    {
        public int Value { get; set; }
        public SearchNode Left { get; set; }
        public SearchNode Right { get; set; }
    }
}
