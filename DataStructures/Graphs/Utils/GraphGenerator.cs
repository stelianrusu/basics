using DataStructures.Graphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs.Utils
{
    public class GraphGenerator
    {
        public static IList<Vertex> GenerateVertices(int count)
        {
            return Enumerable.Range(1, 10).Select(i => new Vertex() { Label = (i-1).ToString() }).ToList();
        }
    }
}
