using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Graphs.Models;

namespace DataStructures.Graphs.Alg
{
    public class ComponentFinder
    {
        private readonly IDFSAlgorithm _dfs;

        public ComponentFinder(IDFSAlgorithm dfs)
        {
            _dfs = dfs;
        }

        public List<GraphComponent> FindComponents(IGraph graph)
        {
            List<GraphComponent> components = new List<GraphComponent>();
            bool[] visited = new bool[graph.Vertices.Count];
            Dictionary<Vertex, int> vertexOrder = graph.Vertices
                .Select((item, i) => (Vertice: item, OrderedIndex: i)).ToList()
                .ToDictionary(v => v.Vertice, v => v.OrderedIndex);

            foreach (var graphVertex in graph.Vertices)
            {
                if (!visited[vertexOrder[graphVertex]])
                {
                    GraphComponent component = new GraphComponent();

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

    public class GraphComponent
    {
        public List<Vertex> Vertices { get; set; } = new List<Vertex>();
    }
}
