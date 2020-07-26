using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.WarmUp
{
    public class MyGraph
    {
        public List<GraphNode> Nodes { get; set; } = new List<GraphNode>();
    }

    public class GraphNode
    {
        public int Value { get; set; }
        public List<GraphNode> Neighbors { get; set; } = new List<GraphNode>();
    }
}
