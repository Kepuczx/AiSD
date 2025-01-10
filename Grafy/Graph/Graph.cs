using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graph
{
    internal class Graph<T>
    {
        private List<NodeG<T>> nodes;

        public Graph()
        {
            nodes = new List<NodeG<T>>();
        }

        public void AddNode(T value)
        {
            var placeHolder = new NodeG<T>(value);
            nodes.Add(placeHolder);
        }

        public NodeG<T> FindNode(T value)
        {
            return nodes.Find(n => n.Value.Equals(value));
        }

        public void AddEdge(T from, T to, int weight)
        {
            var fromNode = FindNode(from);
            var toNode = FindNode(to);
            if (fromNode == null || toNode == null)
            {
                MessageBox.Show("Podane wierzchołki nie istnieją!");
            }
            else
            {
                fromNode.AddEdge(toNode, weight);
            }
        }
        public string GetGraphRepresentation()
        {
            string representation = "Graph:\n";
            foreach (var node in nodes)
            {
                representation += $"{node.Value}: ";
                foreach (var edge in node.Edges)
                {
                    representation += $"({edge.Next.Value}, {edge.Weight}) ";
                }
                representation += "\n";
            }
            return representation;
        }

        public Dictionary<NodeG<T>, int> Dijkstra(T startValue)
        {
            var startNode = FindNode(startValue);
           
            var distances = new Dictionary<NodeG<T>, int>();
            var previousNodes = new Dictionary<NodeG<T>, NodeG<T>>();
            var unvisitedNodes = new List<NodeG<T>>(nodes);

            foreach (var node in nodes)
            {
                distances[node] = int.MaxValue;
            }
            distances[startNode] = 0; 

            while (unvisitedNodes.Count > 0)
            { 
                NodeG<T> currentNode = null;
                int smallestDistance = int.MaxValue;

                foreach (var node in unvisitedNodes)
                {
                    if (distances[node] < smallestDistance)
                    {
                        smallestDistance = distances[node];
                        currentNode = node;
                    }
                }

                if (currentNode == null || smallestDistance == int.MaxValue)
                    break; 

                unvisitedNodes.Remove(currentNode);

                foreach (var edge in currentNode.Edges)
                {
                    var newDistance = distances[currentNode] + edge.Weight;
                    if (newDistance < distances[edge.Next])
                    {
                        distances[edge.Next] = newDistance;
                    }
                }
            }

            return distances;
        }
    }
    }
