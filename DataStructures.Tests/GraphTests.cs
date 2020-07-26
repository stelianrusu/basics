using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.Exercises;
using Graphs.WarmUp;
using Xunit;

namespace Basics.AlgoTests
{
    public class GraphTests
    {
        [Fact]
        public void PathExists()
        {
            MyGraph graph = new MyGraph();

            GraphNode node1 = new GraphNode() { Value = 1 };
            GraphNode node2 = new GraphNode() { Value = 2 };
            GraphNode node3 = new GraphNode() { Value = 3 };
            GraphNode node4 = new GraphNode() { Value = 4 };

            node1.Neighbors.Add(node2);
            node2.Neighbors.Add(node3);
            node2.Neighbors.Add(node4);

            RouteFinder routeFinder = new RouteFinder();
            Assert.True(routeFinder.PathExists(graph, node1, node3));
            Assert.False(routeFinder.PathExists(graph, node3, node4));
        }

        [Fact]
        public void SearchTree()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5,6 };
            SearchTreeBuilder builder = new SearchTreeBuilder();
            var result = builder.BuildFromSortedArray(arr);
        }

        [Fact]
        public void ListLevelBuilder()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6 };
            SearchTreeBuilder treeBuilder = new SearchTreeBuilder();
            var tree = treeBuilder.BuildFromSortedArray(arr);

            ListLevelBuilder builder = new ListLevelBuilder();
            List<LinkedList<SearchNode>> lists = builder.BuildLists(tree);

        }
    }
}
