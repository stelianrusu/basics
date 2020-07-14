using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Graphs.Models;
using DataStructures.Graphs.Models.Generics;

namespace DataStructures.Graphs.Alg
{
    public class ComponentFinder<T>
    {
        private readonly IDFSAlgorithm<T> _dfs;

        public ComponentFinder(IDFSAlgorithm<T> dfs)
        {
            _dfs = dfs;
        }

        public List<GraphComponent<T>> FindComponents(IGraph<T> graph)
        {
            List<GraphComponent<T>> components = new List<GraphComponent<T>>();
            bool[] visited = new bool[graph.Vertices.Count];
            Dictionary<Vertex<T>, int> vertexOrder = graph.Vertices
                .Select((item, i) => (Vertice: item, OrderedIndex: i)).ToList()
                .ToDictionary(v => v.Vertice, v => v.OrderedIndex);

            foreach (var graphVertex in graph.Vertices)
            {
                if (!visited[vertexOrder[graphVertex]])
                {
                    GraphComponent<T> component = new GraphComponent<T>();

                    _dfs.TraverseGraphFrom(graph, graphVertex, v =>
                    {
                        component.Vertices.Add(v);
                        visited[vertexOrder[v]] = true;

                    });
                    components.Add(component);
                }
            }
            return components;
        }
    }

    public class GraphComponent<T>
    {
        public List<Vertex<T>> Vertices { get; set; } = new List<Vertex<T>>();
    }
}
