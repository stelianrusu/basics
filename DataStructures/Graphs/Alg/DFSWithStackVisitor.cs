using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Graphs.Models;

namespace DataStructures.Graphs.Alg
{
    public class DFSWithStackVisitor
    {
        private readonly IGraph _graph;

        public event EventHandler<Vertex> OnVertexVisited;

        public DFSWithStackVisitor(IGraph graph)
        {
            _graph = graph;
        }

        public void TraverseFrom(Vertex start)
        {
            var visited = new bool[_graph.Vertices.Count];
            var vertexOrder = _graph.Vertices
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