using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Graphs.Models;
using DataStructures.Graphs.Models.Generics;
using DataStructures.Graphs.Utils;

namespace DataStructures.Graphs.Alg
{
    public class ShortestPath<T>
    {
        public ICollection<Vertex<T>> FindPath(IGraph<T> graph, Vertex<T> from, Vertex<T> to)
        {
            Dictionary<Vertex<T>, Vertex<T>> bfsMatrix = BuildBFSMatrix(graph, from);
            Vertex<T> child = to;

            List<Vertex<T>> path = new List<Vertex<T>>();
            while (bfsMatrix.ContainsKey(child))
            {
                path.Add(child);
                child = bfsMatrix[child];
            }

            if (child == from)
            {
                path.Reverse();
                return path;
            }

            return new List<Vertex<T>>();
        }

        private Dictionary<Vertex<T>, Vertex<T>> BuildBFSMatrix(IGraph<T> graph, Vertex<T> from)
        {
            Dictionary<Vertex<T>, bool> visitedDictionary = graph.ConstructVisitedDictionary();
            Dictionary<Vertex<T>, Vertex<T>> parentMatrix = new Dictionary<Vertex<T>, Vertex<T>>();
            Queue<Vertex<T>> verticesQueue = new Queue<Vertex<T>>();
            verticesQueue.Enqueue(from);
            visitedDictionary[from] = true;

            while (verticesQueue.Count > 0)
            {
                Vertex<T> visitedVertex = verticesQueue.Dequeue();

                foreach (var edge in graph.GetEdgesFrom(visitedVertex))
                {
                    var vertexNeighbor = edge.To;
                    if (!visitedDictionary[vertexNeighbor])
                    {
                        visitedDictionary[vertexNeighbor] = true;
                        verticesQueue.Enqueue(vertexNeighbor);
                        parentMatrix.Add(vertexNeighbor, visitedVertex);
                    }
                }
            }

            return parentMatrix;
        }
    }
}
