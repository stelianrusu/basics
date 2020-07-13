using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Graphs.Models;

namespace DataStructures.Graphs.Alg
{
    internal class DFSRecursiveVisitor
    {
        private readonly IGraph _graph;
        private bool[] _visited;
        private Dictionary<Vertex, int> _vertexOrder;
        public DFSRecursiveVisitor(IGraph graph)
        {
            this._graph = graph;

        }

        public event EventHandler<Vertex> OnVertexVisited;

        public void TraverseFrom(Vertex start)
        {
            this._visited = new bool[_graph.Vertices.Count];
            this._vertexOrder = _graph.Vertices
                .Select((item, i) => (Vertice: item, OrderedIndex: i)).ToList()
                .ToDictionary(v => v.Vertice, v => v.OrderedIndex);
            
            Recursion(start);
        }

        private void Recursion(Vertex currentVertex)
        {
            if (_visited[_vertexOrder[currentVertex]])
                    return;

            VisitVertex(currentVertex);
            _visited[_vertexOrder[currentVertex]] = true;
            foreach (var neighbor in currentVertex.Neighbors)
                Recursion(neighbor);
        }

        private void VisitVertex(Vertex currentVertex)
        {
            OnVertexVisited?.Invoke(this, currentVertex);
        }
    }
}