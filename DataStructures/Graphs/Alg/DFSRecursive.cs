using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Graphs.Models;

namespace DataStructures.Graphs.Alg
{
    public class DFSRecursive : IDFSAlgorithm
    {
        private bool[] _visited;
        private Dictionary<Vertex, int> _vertexOrder;

        public event EventHandler<Vertex> OnVertexVisited;

        public void TraverseGraphFrom(IGraph graph, Vertex start)
        {
            this._visited = new bool[graph.Vertices.Count];
            this._vertexOrder = graph.Vertices
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