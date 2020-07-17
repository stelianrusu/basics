using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Graphs.Models;
using DataStructures.Graphs.Models.Generics;
using DataStructures.Graphs.Utils;

namespace DataStructures.Graphs.Alg
{
    public class DFSRecursive<T> : IDFSAlgorithm<T>
    {
        private Dictionary<Vertex<T>, bool> visitedDictionary;

        public void TraverseGraphFrom(IGraph<T> graph, Vertex<T> start, Action<Vertex<T>> onVisitAction)
        {
            visitedDictionary = graph.ConstructVisitedDictionary();

            Recursion(graph, start, onVisitAction);
        }

        private void Recursion(IGraph<T> graph, Vertex<T> currentVertex, Action<Vertex<T>> onVisitAction)
        {
            if (visitedDictionary[currentVertex])
                return;

            visitedDictionary[currentVertex] = true;
            foreach (var edge in graph.GetEdgesFrom(currentVertex))
                Recursion(graph, edge.To, onVisitAction);
            onVisitAction(currentVertex);

        }

    }
}