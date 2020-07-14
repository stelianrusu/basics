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

        public void TraverseGraphFrom(IGraph graph, Vertex start, Action<Vertex> onVisitAction)
        {
            this._visited = new bool[graph.Vertices.Count];
            this._vertexOrder = graph.Vertices
                .Select((item, i) => (Vertice: item, OrderedIndex: i)).ToList()
                .ToDictionary(v => v.Vertice, v => v.OrderedIndex);
            
            Recursion(start, onVisitAction);
        }

        private void Recursion(Vertex currentVertex, Action<Vertex> onVisitAction)
        {
            if (_visited[_vertexOrder[currentVertex]])
                    return;

            onVisitAction(currentVertex);
            _visited[_vertexOrder[currentVertex]] = true;
            foreach (var neighbor in currentVertex.Neighbors)
                Recursion(neighbor, onVisitAction);
        }

    }
}