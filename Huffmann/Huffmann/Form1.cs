using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huffmann
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            if (string.IsNullOrEmpty(inputText))
            {
                MessageBox.Show("Please enter some text to encode.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            HuffmanTree huffmanTree = new HuffmanTree();
            huffmanTree.Build(inputText);
            string encoded = huffmanTree.Encode(inputText);
            textBox2.Text = encoded;

            string decoded = huffmanTree.Decode(encoded);
            textBox3.Text = decoded;

            MessageBox.Show("Encoding completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public class HuffmanTree
        {
            private class Node
            {
                public char? Character;
                public int Frequency;
                public Node Left;
                public Node Right;
            }

            private Node root;
            private Dictionary<char, string> codes;

            public void Build(string input)
            {
                var frequency = new Dictionary<char, int>();
                foreach (char c in input)
                {
                    if (!frequency.ContainsKey(c))
                        frequency[c] = 0;
                    frequency[c]++;
                }

                var priorityQueue = new SortedSet<(int, Node)>(Comparer<(int, Node)>.Create((a, b) => a.Item1 != b.Item1 ? a.Item1.CompareTo(b.Item1) : a.GetHashCode().CompareTo(b.GetHashCode())));

                foreach (var kvp in frequency)
                {
                    priorityQueue.Add((kvp.Value, new Node { Character = kvp.Key, Frequency = kvp.Value }));
                }

                while (priorityQueue.Count > 1)
                {
                    var left = priorityQueue.Min;
                    priorityQueue.Remove(left);

                    var right = priorityQueue.Min;
                    priorityQueue.Remove(right);

                    var parent = new Node
                    {
                        Frequency = left.Item1 + right.Item1,
                        Left = left.Item2,
                        Right = right.Item2
                    };

                    priorityQueue.Add((parent.Frequency, parent));
                }

                root = priorityQueue.Min.Item2;
                codes = new Dictionary<char, string>();
                BuildCodes(root, "");
            }

            private void BuildCodes(Node node, string code)
            {
                if (node == null) return;

                if (node.Character.HasValue)
                {
                    codes[node.Character.Value] = code;
                }

                BuildCodes(node.Left, code + "0");
                BuildCodes(node.Right, code + "1");
            }

            public string Encode(string input)
            {
                var sb = new StringBuilder();
                foreach (char c in input)
                {
                    sb.Append(codes[c]);
                }
                return sb.ToString();
            }

            public string Decode(string encoded)
            {
                var sb = new StringBuilder();
                var node = root;
                foreach (char bit in encoded)
                {
                    node = bit == '0' ? node.Left : node.Right;

                    if (node.Character.HasValue)
                    {
                        sb.Append(node.Character.Value);
                        node = root;
                    }
                }
                return sb.ToString();
            }
        }
    }
}
