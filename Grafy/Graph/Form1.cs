using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Graph
{
    public partial class Form1 : Form
    {
        Graph<string> Graph = new Graph<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Graph.AddNode(textBox1.Text);
            label3.Text = "Dodano " + textBox1.Text;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddEgde_Click(object sender, EventArgs e)
        {
            Graph.AddEdge(A.Text, textBox3.Text,(int)numericUpDown1.Value);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Display_Click(object sender, EventArgs e)
        {
            label1.Text=Graph.GetGraphRepresentation();
        }

        private void Dijkstra_Click(object sender, EventArgs e)
        {
            string startNodeValue = textBox2.Text;
            var distances = Graph.Dijkstra(startNodeValue);

            string result = $"Wyniki algorytmu od punktu {startNodeValue}:\n";
            foreach (var  i in distances)
            {
                result += $"{i.Key.Value}: {i.Value}\n";
            }

            label2.Text = result; 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
