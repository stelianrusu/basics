using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graphs.Models
{
    public class Vertex
    {
        public string Label { get; internal set; }
        public IList<Vertex> Neighbors { get; set; } = new List<Vertex>();
    }
}
