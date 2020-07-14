using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Graphs.Models;
using DataStructures.Graphs.Models.Generics;

namespace DataStructures.Graphs.Utils
{
    public static class HelperStructures
    {
        public static Dictionary<Vertex<T>, bool> ConstructVisitedDictionary<T>(this IGraph<T> graph)
        {
            return graph.Vertices
                .Select(item => (Vertice: item, Visited: false)).ToList()
                .ToDictionary(v => v.Vertice, v => v.Visited);
        }
    }
}
