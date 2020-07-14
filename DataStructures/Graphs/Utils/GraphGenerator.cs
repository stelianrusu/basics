using DataStructures.Graphs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Graphs.Models.Generics;

namespace DataStructures.Graphs.Utils
{
    public class GraphGenerator
    {
        public static IList<Vertex<string>> GenerateVertices(int count)
        {
            return Enumerable.Range(1, 10).Select(i => new Vertex<string>() { Value = (i - 1).ToString() }).ToList();
        }
    }
}
