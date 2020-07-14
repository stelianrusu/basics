using DataStructures.Graphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Graphs.Models.Generics;

namespace DataStructures.Graphs.Models
{
    public class BidirectionalGraphWithNeighbors<T> : IGraph<T>
    {
        public IList<Vertex<T>> Vertices { get; private set; } = new List<Vertex<T>>();

        public void AddVertices(IList<Vertex<T>> vertices)
        {
            this.Vertices = vertices;
            EnsureBothDirections();
        }

        private void EnsureBothDirections()
        {
            foreach (var v1 in Vertices)
            {
                IList<Vertex<T>> allNeighbors = v1.Neighbors.ToList();
                foreach (var v2 in Vertices.Except(new[] { v1 }))
                {
                    if (v2.Neighbors.Contains(v1) && !allNeighbors.Contains(v2))
                        allNeighbors.Add(v2);
                }

                v1.Neighbors = allNeighbors;
            }
        }
    }
}
