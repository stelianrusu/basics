using System.Collections.Generic;

namespace DataStructures.Graphs.Models.Generics
{
    public class Vertex<T>
    {
        public T Value { get; set; }
        public IList<Vertex<T>> Neighbors { get; set; } = new List<Vertex<T>>();
    }
}
