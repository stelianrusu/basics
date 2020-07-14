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

        void AddVertices(IList<Vertex<T>> vertices);
    }
}
