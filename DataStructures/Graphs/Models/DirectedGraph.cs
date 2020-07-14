using DataStructures.Graphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Graphs.Models.Generics;

namespace DataStructures.Graphs.Models
{
    public class DirectedGraph<T> : IGraph<T>
    {
        public IList<Vertex<T>> Vertices { get; private set; } = new List<Vertex<T>>();

        public void AddVertices(IList<Vertex<T>> vertices)
        {
            this.Vertices = vertices;
        }
    }
}
