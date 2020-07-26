using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.WarmUp;

namespace Graphs.Exercises
{
    public class TopSort
    {
        HashSet<GraphNode> visitedHash = new HashSet<GraphNode>();
        public List<GraphNode> CreateOrder(MyGraph graph)
        {
            List<GraphNode> dfsDiscoveryResult = dfs(graph.Nodes[0]);
        }

        private List<GraphNode> dfs(GraphNode node)
        {
            List<GraphNode> discoveredNodes = new List<GraphNode>();
            visitedHash.Add(node);
            foreach (var neighbour in node.Neighbors)
            {
                if(!visitedHash.Contains(neighbour))
                    discoveredNodes.AddRange(dfs(neighbour));
            }

            discoveredNodes.Add(node);
            return discoveredNodes;
        }
    }
}
