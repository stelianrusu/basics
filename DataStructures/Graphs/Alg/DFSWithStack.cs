using System;
using DataStructures.Graphs.Models;

namespace DataStructures.Graphs.Alg
{
    public class DFSWithStack
    {
        public void TraverseFrom(IGraph graph, Vertex from, Action<Vertex> visitFunction)
        {
            DFSWithStackVisitor visitor = new DFSWithStackVisitor(graph);
            visitor.OnVertexVisited += (sender, e) => visitFunction(e); 
            visitor.TraverseFrom(from);
        }

    }
}
