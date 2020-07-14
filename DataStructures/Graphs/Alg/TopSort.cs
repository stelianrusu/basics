using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Graphs.Models.Generics;
using DataStructures.Graphs.Utils;

namespace DataStructures.Graphs.Alg
{
    public class TopSort<T>
    {
        public IList<Vertex<T>> GetTopologicalOrder(IGraph<T> graph)
        {
            DFSRecursive<T> dfs = new DFSRecursive<T>();
            LinkedList<Vertex<T>> orderedList = new LinkedList<Vertex<T>>();
            
            var visited = graph.ConstructVisitedDictionary();

            while (visited.Count(v => v.Value == false) > 0)
            {

                var notVisitedVertex = visited.First(v => v.Value == false).Key;
                dfs.TraverseGraphFrom(graph, notVisitedVertex, vertex =>
                {
                    if (visited[vertex] == false)
                    {
                        orderedList.AddFirst(vertex);
                        visited[vertex] = true;
                    }
                });
            }

            return orderedList.ToList();
        }
    }
}
