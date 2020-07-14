using DataStructures.Graphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs.Models
{
    public class BidirectionalGraphWithNeighbors : IGraph
    {
        public IList<Vertex> Vertices { get; private set; } = new List<Vertex>();

        public void AddVertices(IList<Vertex> vertices)
        {
            this.Vertices = vertices;
            EnsureBothDirections();
        }

        private void EnsureBothDirections()
        {
            foreach (var v1 in Vertices)
            {
                var allNeighbors = new List<Vertex>();
                foreach (var v2 in Vertices)
                {
                    if(v2 == v1)
                        allNeighbors.AddRange(v2.Neighbors);
                    if(v2.Neighbors.Contains(v1) && !allNeighbors.Contains(v2))
                        allNeighbors.Add(v2);
                }

                v1.Neighbors = allNeighbors;
            }
        }
    }
}
