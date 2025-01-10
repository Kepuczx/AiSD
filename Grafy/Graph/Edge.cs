using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    internal class Edge<T>
    {
        public NodeG<T> Prev { get; set; }
        public NodeG<T> Next { get; set; }
        public int Weight { get; set; }

        public Edge(NodeG<T> prev, NodeG<T> next, int weight)
        {
            Prev = prev;
            Next = next;
            Weight = weight;
        }
    }
}
