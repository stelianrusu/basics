using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs.Utils
{
    public class TwoDMaze
    {
        public MazeField[,] Fields { get; set; }

    }

    public enum FieldType
    {
        Clear,
        Obstacle,
        Start,
        End
    }

    public class MazeField
    {
        public FieldType FieldType { get; set; }
        public string Label { get; set; }
    }
}
