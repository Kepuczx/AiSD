using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace binarysearchtree
{
    public partial class Form1 : Form
    {
        private BST bst;
        public Form1()
        {
            InitializeComponent();
            bst = new BST();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(int.TryParse(txtValue.Text, out int value)){
                bst.Insert(value);
                txtValue.Clear();
                UpdateTreeView();
            }
            else
            {
                MessageBox.Show("Podaj poprawna liczbe!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(int.TryParse(txtValue.Text, out int value)){
                bool found = bst.Search(value);
                lblResult.Text = found ? $"Wartość {value} istnieje w drzewie." : $"Wartość {value} nie istnieje.";

            }
            else
            {
                MessageBox.Show("Podaj poprawna liczbe!");
            }
        }

        private void UpdateTreeView()
        {
            treeView1.Nodes.Clear();
            if(bst.Root != null)
            {
                TreeNode rootNode = new TreeNode(bst.Root.Value.ToString());
                AddNodesToTreeView(bst.Root, rootNode);
                treeView1.Nodes.Add(rootNode);
                treeView1.ExpandAll();
            }
        }
        private void AddNodesToTreeView(Node node, TreeNode treeNode)
        {
            if(node.Left != null)
            {
                TreeNode leftNode = new TreeNode(node.Left.Value.ToString());
                treeNode.Nodes.Add(leftNode);
                AddNodesToTreeView(node.Left, leftNode);
            }
            if(node.Right != null)
            {
                TreeNode rightNode = new TreeNode(node.Right.Value.ToString());
                treeNode.Nodes.Add(rightNode);
                AddNodesToTreeView(node.Right, rightNode);
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(int.TryParse(txtValue.Text, out int value)){
                bst.Delete(value);
                UpdateTreeView();
                txtValue.Clear();
            }
            else{
                MessageBox.Show("Podaj poprawna liczbe!");
            }
        }
    }
}
