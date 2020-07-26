using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graphs.WarmUp;

namespace Graphs.Exercises
{
    public class RouteFinder
    {
        public bool PathExists(MyGraph graph, GraphNode from, GraphNode to)
        {
            HashSet<GraphNode> visited = new HashSet<GraphNode>();
            
            Queue<GraphNode> nodeQueue = new Queue<GraphNode>();
            nodeQueue.Enqueue(from);

            while (nodeQueue.Count > 0)
            {
                var currentNode = nodeQueue.Dequeue();
                visited.Add(currentNode);
                if (currentNode.Equals(to))
                    return true;
                foreach (var currentNodeNeighbor in currentNode.Neighbors)
                {
                    if (!visited.Contains(currentNodeNeighbor))
                        nodeQueue.Enqueue(currentNodeNeighbor);
                }
            }

            return false;
        }
    }
}
