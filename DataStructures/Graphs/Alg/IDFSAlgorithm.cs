using System;
using DataStructures.Graphs.Models;

namespace DataStructures.Graphs.Alg
{
    public interface IDFSAlgorithm
    {
        void TraverseGraphFrom(IGraph graph, Vertex start, Action<Vertex> onVisitAction);
    }
}