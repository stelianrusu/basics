using DataStructures.Graphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs.Models
{
    public class GraphWithNeighbors : IGraph
    {
        public IList<Vertex> Vertices { get; private set; } = new List<Vertex>();

        public void AddVertices(IList<Vertex> vertices)
        {
            this.Vertices = vertices;
        }
    }
}
