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
            IGraph graph = new BidirectionalGraphWithNeighbors();
            var vertices = GraphGenerator.GenerateVertices(10);

            vertices[0].Neighbors = new [] { vertices[1], vertices[2]};

            graph.AddVertices(vertices);
            var visitedVertices = new List<Vertex>();

            DFSRecursive visitor = new DFSRecursive();
            visitor.TraverseGraphFrom(graph, graph.Vertices[0], v =>
            {
                _output.WriteLine(v.Label);
                visitedVertices.Add(v);
            });

            Assert.Equal(3,visitedVertices.Count);

        }


        [Fact]
        public void TestDFSWithStack()
        {
            IGraph graph = new BidirectionalGraphWithNeighbors();
            var vertices = GraphGenerator.GenerateVertices(10);

            vertices[0].Neighbors = new[] { vertices[1], vertices[2] };
            vertices[2].Neighbors = new[] { vertices[2], vertices[3] };
            vertices[3].Neighbors = new[] { vertices[4], vertices[5] };

            graph.AddVertices(vertices);

            DFSWithStack visitor = new DFSWithStack();
            var visitedVertices = new List<Vertex>();

            visitor.TraverseGraphFrom(graph, vertices[0], v =>
            {
                _output.WriteLine(v.Label);
                visitedVertices.Add(v);
            });

            Assert.Equal(6, visitedVertices.Count);

        }



        [Fact]
        public void TestFindComponents()
        {
            IGraph graph = new BidirectionalGraphWithNeighbors();
            var vertices = GraphGenerator.GenerateVertices(10);

            vertices[0].Neighbors = new[] { vertices[1], vertices[2] };
            vertices[2].Neighbors = new[] {  vertices[3] };
            vertices[6].Neighbors = new[] { vertices[4], vertices[5] };
            vertices[8].Neighbors = new[] { vertices[7] };

            graph.AddVertices(vertices);

            ComponentFinder componentFinder = new ComponentFinder(new DFSRecursive());
            List<GraphComponent> graphComponents = componentFinder.FindComponents(graph);

            Assert.Equal(4, graphComponents.Count);

        }
    }
}
