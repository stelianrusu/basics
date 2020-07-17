using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs.Models.Generics
{
    public interface IGraph<T>
    {
        IList<Vertex<T>> Vertices { get; }
        IList<Edge<T>> GetEdgesFrom(Vertex<T> vertex);

        void AddEdges(IList<Edge<T>> edges);
        void AddVertices(IList<Vertex<T>> vertices);
    }


    public class Edge<T> 
    {
        public Vertex<T> From { get; set; }
        public Vertex<T> To { get; set; }
        public object Weight { get; set; }
    }
}
