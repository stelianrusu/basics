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

            RecursiveDFS recursiveDFS = new RecursiveDFS();

            var visitedVertices = new List<Vertex>();
            recursiveDFS.TraverseFrom(graph, vertices[0], v =>
            {
                _output.WriteLine(v.Label);
                visitedVertices.Add(v);
            });

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

            DFSWithStack recursiveDFS = new DFSWithStack();

            var visitedVertices = new List<Vertex>();
            recursiveDFS.TraverseFrom(graph, vertices[0], v =>
            {
                _output.WriteLine(v.Label);
                visitedVertices.Add(v);
            });

            Assert.Equal(6, visitedVertices.Count);

        }
    }
}
