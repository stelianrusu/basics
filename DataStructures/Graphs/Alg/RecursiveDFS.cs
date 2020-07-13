using System;
using DataStructures.Graphs.Models;

namespace DataStructures.Graphs.Alg
{
    public class RecursiveDFS
    {
        public void TraverseFrom(IGraph graph, Vertex from, Action<Vertex> visitFunction)
        {
            DFSRecursiveVisitor visitor = new DFSRecursiveVisitor(graph);
            visitor.OnVertexVisited += (sender, e) => visitFunction(e); 
            visitor.TraverseFrom(from);
        }
    }
}
