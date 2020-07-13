using DataStructures.Graphs.Models;
using DataStructures.Graphs.Utils;
using System;
using System.Collections.Generic;
using DataStructures.Graphs.Alg;
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
            IGraph graph = new GraphWithNeighbors();
            var vertices = GraphGenerator.GenerateVertices(10);

            vertices[0].Neighbors = new [] { vertices[1], vertices[2]};

            graph.AddVertices(vertices);
            var visitedVertices = new List<Vertex>();

            DFSRecursive visitor = new DFSRecursive();
            visitor.OnVertexVisited += (sender, v) => {
                _output.WriteLine(v.Label);
                visitedVertices.Add(v);
            };
            visitor.TraverseGraphFrom(graph, graph.Vertices[0]);


            Assert.Equal(3,visitedVertices.Count);

        }


        [Fact]
        public void TestDFSWithStack()
        {
            IGraph graph = new GraphWithNeighbors();
            var vertices = GraphGenerator.GenerateVertices(10);

            vertices[0].Neighbors = new[] { vertices[1], vertices[2] };
            vertices[2].Neighbors = new[] { vertices[2], vertices[3] };
            vertices[3].Neighbors = new[] { vertices[4], vertices[5] };

            graph.AddVertices(vertices);

            DFSWithStack visitor = new DFSWithStack();
            var visitedVertices = new List<Vertex>();

            visitor.OnVertexVisited += (sender, v) => {
                _output.WriteLine(v.Label);
                visitedVertices.Add(v);
            };

            visitor.TraverseGraphFrom(graph, vertices[0]);

            Assert.Equal(6, visitedVertices.Count);

        }
    }
}
