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
            var graph = new BidirectionalGraphWithNeighbors<string>();
            var vertices = GraphGenerator.GenerateVertices(10);

            vertices[0].Neighbors = new[] { vertices[1], vertices[2] };

            graph.AddVertices(vertices);
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
            var graph = new BidirectionalGraphWithNeighbors<string>();
            var vertices = GraphGenerator.GenerateVertices(10);

            vertices[0].Neighbors = new[] { vertices[1], vertices[2] };
            vertices[2].Neighbors = new[] { vertices[2], vertices[3] };
            vertices[3].Neighbors = new[] { vertices[4], vertices[5] };

            graph.AddVertices(vertices);

            DFSWithStack<string> visitor = new DFSWithStack<string>();
            var visitedVertices = new List<Vertex<string>>();

            visitor.TraverseGraphFrom(graph, vertices[0], v =>
            {
                _output.WriteLine(v.Value);
                visitedVertices.Add(v);
            });

            Assert.Equal(6, visitedVertices.Count);

        }



        [Fact]
        public void TestFindComponents()
        {
            var graph = new BidirectionalGraphWithNeighbors<string>();
            var vertices = GraphGenerator.GenerateVertices(10);

            vertices[0].Neighbors = new[] { vertices[1], vertices[2] };
            vertices[2].Neighbors = new[] { vertices[3] };
            vertices[6].Neighbors = new[] { vertices[4], vertices[5] };
            vertices[8].Neighbors = new[] { vertices[7] };

            graph.AddVertices(vertices);

            ComponentFinder<string> componentFinder = new ComponentFinder<string>(new DFSRecursive<string>());
            List<GraphComponent<string>> graphComponents = componentFinder.FindComponents(graph);

            Assert.Equal(4, graphComponents.Count);

        }

        [Fact]
        public void TestFindShortestPath()
        {
            var graph = new BidirectionalGraphWithNeighbors<string>();
            var vertices = GraphGenerator.GenerateVertices(10);

            vertices[0].Neighbors = new[] { vertices[1], vertices[2] };
            vertices[2].Neighbors = new[] { vertices[3] };
            vertices[6].Neighbors = new[] { vertices[4], vertices[5] };
            vertices[3].Neighbors = new[] { vertices[5], vertices[6] };

            graph.AddVertices(vertices);
            var pathAlg = new ShortestPath<string>();
            var path = pathAlg.FindPath(graph, vertices[0], vertices[7]);
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
        }

        private IGraph<string> ReadDirectedGraphFromString(string graphString)
        {
            DirectedGraph<string> graph = new DirectedGraph<string>();
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
                    if(neighbour != "")
                        vertex.Neighbors.Add(graph.Vertices.First(v => v.Value == neighbour));
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
    }
}
