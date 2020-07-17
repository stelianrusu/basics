using DataStructures.Graphs.Models;
using DataStructures.Graphs.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Graphs.Alg;
using DataStructures.Graphs.Models.Generics;
using Xunit;
using Xunit.Abstractions;

namespace Basics.AlgoTests
{
    public class DFSTest
    {
        private readonly ITestOutputHelper _output;

        public DFSTest(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void TestRecursiveDFS()
        {
            string graphString = @"
0-1,2
1-0
2-0";
            var graph = ReadDirectedGraphFromString(graphString);
            
            var visitedVertices = new List<Vertex<string>>();

            DFSRecursive<string> visitor = new DFSRecursive<string>();
            visitor.TraverseGraphFrom(graph, graph.Vertices[0], v =>
            {
                _output.WriteLine(v.Value);
                visitedVertices.Add(v);
            });

            Assert.Equal(3, visitedVertices.Count);

        }


        [Fact]
        public void TestDFSWithStack()
        {
            string graphString = @"
0-1,2
1-0
2-0,3
3-4,5
4-3
5-3";
            var graph = ReadDirectedGraphFromString(graphString);

            DFSWithStack<string> visitor = new DFSWithStack<string>();
            var visitedVertices = new List<Vertex<string>>();

            visitor.TraverseGraphFrom(graph, graph.Vertices[0], v =>
            {
                _output.WriteLine(v.Value);
                visitedVertices.Add(v);
            });

            Assert.Equal(6, visitedVertices.Count);

        }



        [Fact]
        public void TestFindComponents()
        {
            string graphString = @"
0-1,2
1-0
2-0,3
3-2
4-6
5-6
6-4,5
7-8
8-7
9-";
            var graph = ReadDirectedGraphFromString(graphString);

            ComponentFinder<string> componentFinder = new ComponentFinder<string>(new DFSRecursive<string>());
            List<GraphComponent<string>> graphComponents = componentFinder.FindComponents(graph);

            Assert.Equal(4, graphComponents.Count);

        }

        [Fact]
        public void TestFindShortestPath()
        {
            string graphString = @"
0-1,2
1-0
2-0,3
3-2,5,6
4-6
5-6,3
6-";
            var graph = ReadDirectedGraphFromString(graphString);

            var pathAlg = new ShortestPath<string>();
            var path = pathAlg.FindPath(graph, graph.Vertices[0], graph.Vertices[6]);
            Assert.Equal(3, path.Count);
        }


        [Fact]
        public void TestTwoDMazePathFinder()
        {
            TwoDMazePathFinder mazer = new TwoDMazePathFinder();

            string mazeString = @"
S000X
X0X00
X00XX
X0X0E
X0X00
X000X";
            TwoDMaze m = ReadMazeFromString(mazeString);

            List<MazeField> path = mazer.Find(m);
            Assert.Equal(11, path.Count);
        }



        [Fact]
        public void TestTopSort()
        {
            TopSort<string> topSort = new TopSort<string>();

            string graphString = @"
C-A,B
B-D
A-D
E-A,D,F
D-G,H
F-K,J
G-I
H-I,J
I-L
J-L,M
K-J
L-
M-";
            IGraph<string> graph = ReadDirectedGraphFromString(graphString);

            IList<Vertex<string>> topologicalOrder = topSort.GetTopologicalOrder(graph);
            Assert.Equal("E", topologicalOrder[0].Value);
            Assert.Equal("L", topologicalOrder[11].Value);
            Assert.Equal("M", topologicalOrder[12].Value);
        }

        [Fact]
        public void TestShortestPaths()
        {
            string graphString = @"
A:B_3,C_6
B:C_4,D_4,E_11
C:D_8,G_11
D:E_-4,F_5,G_2
E:H_9
F:H_1
G:H_2
H:";
           var graph = ReadDirectedWeightedGraphFromString(graphString);
           WagShortestPath<string> alg = new WagShortestPath<string>();
           var distances = alg.CalculateDistances(graph, graph.Vertices[1]);

        }

        private IGraph<string> ReadDirectedGraphFromString(string graphString)
        {
            var graph = new GraphAdjList<string>();
            var lines = graphString.Split(Environment.NewLine).Where(s => !string.IsNullOrEmpty(s)).ToList();

            foreach (var line in lines)
            {
                string[] strings = line.Split("-");
                Vertex<string> v = new Vertex<string> {Value = strings[0]};
                graph.Vertices.Add(v);
            }

            foreach (var line in lines)
            {
                string[] strings = line.Split("-");
                Vertex<string> vertex = graph.Vertices.First(v => v.Value == strings[0]);

                foreach (string neighbour in strings[1].Split(","))
                {
                    if (neighbour != "")
                    {
                        var edge = new Edge<string>(){From = vertex, To = graph.Vertices.First(v => v.Value == neighbour) };
                        graph.AddEdges(new [] { edge });
                    }
                }
            }

            return graph;
        }

        private TwoDMaze ReadMazeFromString(string mazeString)
        {
            TwoDMaze maze = new TwoDMaze();
            var lines = mazeString.Split(Environment.NewLine).Where(s => !string.IsNullOrEmpty(s)).ToList();

            maze.Fields = new MazeField[lines.Count, lines[0].Length];

            int i = 0, j = 0;
            foreach (var line in lines)
            {
                j = 0;
                foreach (char c in line.ToCharArray())
                {
                    if (c == '0')
                        maze.Fields[i, j] = new MazeField() { FieldType = FieldType.Clear, Label = $"{i},{j}" };

                    if (c == 'X')
                        maze.Fields[i, j] = new MazeField() { FieldType = FieldType.Obstacle, Label = $"X" };

                    if (c == 'S')
                        maze.Fields[i, j] = new MazeField() { FieldType = FieldType.Start, Label = $"S" };

                    if (c == 'E')
                        maze.Fields[i, j] = new MazeField() { FieldType = FieldType.End, Label = $"E" };

                    j++;
                }

                i++;
            }

            return maze;
        }

        private IGraph<string> ReadDirectedWeightedGraphFromString(string graphString)
        {
            var graph = new GraphAdjList<string>();
            var lines = graphString.Split(Environment.NewLine).Where(s => !string.IsNullOrEmpty(s)).ToList();

            foreach (var line in lines)
            {
                string[] strings = line.Split(":");
                Vertex<string> v = new Vertex<string> { Value = strings[0] };
                graph.Vertices.Add(v);
            }

            foreach (var line in lines)
            {
                string[] strings = line.Split(":");
                var vertex = graph.Vertices.First(v => v.Value == strings[0]);

                var edges = new List<Edge<string>>();
                foreach (string neighbour in strings[1].Split(","))
                {
                    if (neighbour != "")
                    {
                        var edgeStrParts = neighbour.Split("_");
                        edges.Add(new Edge<string>()
                        {
                            From = vertex,
                            To = graph.Vertices.First(v => v.Value == edgeStrParts[0]),
                            Weight = int.Parse(edgeStrParts[1])
                        });
                    }
                }

                graph.AddEdges(edges);
            }

            return graph;
        }
    }

}
