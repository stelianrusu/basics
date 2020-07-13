using System;
using DataStructures.Graphs.Models;

namespace DataStructures.Graphs.Alg
{
    public interface IDFSAlgorithm
    {
        event EventHandler<Vertex> OnVertexVisited;
        void TraverseGraphFrom(IGraph graph, Vertex start);
    }
}