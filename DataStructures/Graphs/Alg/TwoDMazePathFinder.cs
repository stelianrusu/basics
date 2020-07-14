using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures.Graphs.Models;
using DataStructures.Graphs.Models.Generics;
using DataStructures.Graphs.Utils;

namespace DataStructures.Graphs.Alg
{
    public class TwoDMazePathFinder
    {
        public List<MazeField> Find(TwoDMaze maze)
        {
            var shortestPath = new ShortestPath<MazeField>();

            MazeField start = null, end = null;

            foreach (var mazeField in maze.Fields)
            {
                if (mazeField.FieldType == FieldType.Start)
                    start = mazeField;
                if (mazeField.FieldType == FieldType.End)
                    end = mazeField;
            }

            var graph = BuildGraphFromMaze(maze);

            var startGraphNode = graph.Vertices.First(v => v.Value == start);
            var endGraphNode = graph.Vertices.First(v => v.Value == end);

            var shortestGraphPath = shortestPath.FindPath(graph, startGraphNode, endGraphNode);
            return shortestGraphPath.Select(p => p.Value).ToList();
        }

        private IGraph<MazeField> BuildGraphFromMaze(TwoDMaze maze)
        {
            BidirectionalGraphWithNeighbors<MazeField> graph = new BidirectionalGraphWithNeighbors<MazeField>();

            List<Vertex<MazeField>> vertices = new List<Vertex<MazeField>>();

            int W = maze.Fields.GetLength(0);
            int H = maze.Fields.GetLength(1);

            int[] ii = new[] { 0, 0, 1, -1 };
            int[] jj = new[] { 1, -1, 0, 0 };

            var verticeGrid = new Vertex<MazeField>[W, H];
            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    if (maze.Fields[i, j].FieldType == FieldType.Obstacle)
                        continue;
                    verticeGrid[i, j] = new Vertex<MazeField>() { Value = maze.Fields[i, j] };
                }
            }

            for (int i = 0; i < W; i++)
            {
                for (int j = 0; j < H; j++)
                {
                    if (maze.Fields[i, j].FieldType == FieldType.Obstacle)
                        continue;

                    for (int step = 0; step < 4; step++)
                    {
                        int nextX = i + ii[step];
                        int nextY = j + jj[step];

                        if (nextY >= H || nextY < 0) continue;
                        if (nextX >= W || nextX < 0) continue;

                        if (maze.Fields[nextX, nextY].FieldType == FieldType.Clear)
                            verticeGrid[i, j].Neighbors.Add(verticeGrid[nextX, nextY]);
                    }

                    vertices.Add(verticeGrid[i,j]);
                }
            }

            graph.AddVertices(vertices);
            return graph;
        }
    }
}
