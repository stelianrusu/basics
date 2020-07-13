using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs.Models
{
    public interface IGraph
    {
        IList<Vertex> Vertices { get; }

        void AddVertices(IList<Vertex> vertices);
    }
}
