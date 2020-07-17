using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Graphs.Models.Generics;

namespace DataStructures.Graphs.Alg
{
    public class WagShortestPath<T>
    {
        public Dictionary<Vertex<T>, int> CalculateDistances(IGraph<T> graph, Vertex<T> start)
        {
            var topSort = new TopSort<T>();
            var topOrder = topSort.GetTopologicalOrder(graph);

            Dictionary<Vertex<T>, int> calculatedValues = topOrder
                .ToDictionary(v => v, v => Int32.MaxValue);

            calculatedValues[start] = 0;
            foreach (var vertex in topOrder)
            {
                if(calculatedValues[vertex] == Int32.MaxValue)
                    continue;

                foreach (Edge<T> vertexNeighbor in graph.GetEdgesFrom(vertex))
                {
                    if (calculatedValues[vertexNeighbor.To] > (int)calculatedValues[vertex] + (int)vertexNeighbor.Weight)
                        calculatedValues[vertexNeighbor.To] = (int)calculatedValues[vertex] + (int)vertexNeighbor.Weight;
                }
            }

            return calculatedValues;
        }
    }
}
