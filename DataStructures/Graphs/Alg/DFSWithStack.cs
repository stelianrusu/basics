using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Graphs.Models;

namespace DataStructures.Graphs.Alg
{
    public class DFSWithStack : IDFSAlgorithm
    {

        public event EventHandler<Vertex> OnVertexVisited;

        public void TraverseGraphFrom(IGraph graph, Vertex start)
        {
            var visited = new bool[graph.Vertices.Count];
            var vertexOrder = graph.Vertices
                .Select((item, i) => (Vertice: item, OrderedIndex: i)).ToList()
                .ToDictionary(v => v.Vertice, v => v.OrderedIndex);

            Stack<Vertex> vertexStack = new Stack<Vertex>();
            vertexStack.Push(start);

            while (vertexStack.Count > 0)
            {
                var vertex = vertexStack.Pop();
                visited[vertexOrder[vertex]] = true;
                VisitVertex(vertex);
                foreach (var vertexNeighbor in vertex.Neighbors)
                {
                    if(!visited[vertexOrder[vertexNeighbor]])
                        vertexStack.Push(vertexNeighbor);
                }
            }
        }

        private void VisitVertex(Vertex currentVertex)
        {
            OnVertexVisited?.Invoke(this, currentVertex);
        }
    }
}