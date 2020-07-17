using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Graphs.Models;
using DataStructures.Graphs.Models.Generics;
using DataStructures.Graphs.Utils;

namespace DataStructures.Graphs.Alg
{
    public class DFSWithStack<T> : IDFSAlgorithm<T>
    {

        public void TraverseGraphFrom(IGraph<T> graph, Vertex<T> start, Action<Vertex<T>> onVisitAction)
        {
            Dictionary<Vertex<T>, bool> visitedDictionary = graph.ConstructVisitedDictionary();

            Stack<Vertex<T>> vertexStack = new Stack<Vertex<T>>();
            vertexStack.Push(start);

            while (vertexStack.Count > 0)
            {
                var vertex = vertexStack.Pop();
                visitedDictionary[vertex] = true;
                onVisitAction(vertex);
                foreach (var edge in graph.GetEdgesFrom(vertex))
                {
                    if(!visitedDictionary[edge.To])
                        vertexStack.Push(edge.To);
                }
            }
        }
    }
}