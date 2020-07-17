using DataStructures.Graphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Graphs.Models.Generics;

namespace DataStructures.Graphs.Models
{
    public class GraphAdjList<T> : IGraph<T>
    {
        private Dictionary<Vertex<T>, IList<Edge<T>>> edgeMatrix = new Dictionary<Vertex<T>, IList<Edge<T>>>();
        public IList<Vertex<T>> Vertices { get; private set; } = new List<Vertex<T>>();
        public IList<Edge<T>> GetEdgesFrom(Vertex<T> vertex)
        {
            if (edgeMatrix.ContainsKey(vertex))
                return edgeMatrix[vertex];

            return new List<Edge<T>>();
        }

        public void AddEdges(IList<Edge<T>> edges)
        {
            IEnumerable<IGrouping<Vertex<T>, Edge<T>>> groupBy = edges.GroupBy(e => e.From);
            foreach (var edgeFromGroup in groupBy)
            {
                var from = edgeFromGroup.Key;
                var edgesFrom = edgeFromGroup.ToList();

                if (edgeMatrix.ContainsKey(from))
                {
                    edgesFrom.AddRange(edgeMatrix[from]);
                    edgesFrom = edgesFrom.GroupBy(e => e.To).Select(g => g.First()).ToList();
                }

                edgeMatrix[from] = edgesFrom;
            }
        }

        public void AddVertices(IList<Vertex<T>> vertices)
        {
            this.Vertices = vertices;
        }

    }
}
