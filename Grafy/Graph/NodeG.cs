using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    internal class NodeG<T>
    {
        public T Value { get; set; }
        public List<Edge<T>> Edges { get; set; }

        public NodeG(T value)
        {
            Value = value;
            Edges = new List<Edge<T>>();
        }

        public void AddEdge(NodeG<T> next, int weight)
        {
            var edge = new Edge<T>(this, next, weight);
            Edges.Add(edge);
        }
    }

}
