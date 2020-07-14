using System;
using DataStructures.Graphs.Models;
using DataStructures.Graphs.Models.Generics;

namespace DataStructures.Graphs.Alg
{
    public interface IDFSAlgorithm<T>
    {
        void TraverseGraphFrom(IGraph<T> graph, Vertex<T> start, Action<Vertex<T>> onVisitAction);
    }
}