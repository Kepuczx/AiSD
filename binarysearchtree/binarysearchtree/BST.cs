using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarysearchtree
{
    public class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
    public class BST
    {
            public Node Root { get; private set; }
            public void Insert(int value)
        {
            Root = InsertRecursively(Root, value);
        }
        private Node InsertRecursively(Node root, int value)
        {
            if(root == null)
            {
                return new Node(value);
            }

            if(value < root.Value)
            {
                root.Left = InsertRecursively(root.Left, value);
            }
            else if(value > root.Value)
            {
                root.Right = InsertRecursively(root.Right, value);
            }
            return root;
        }
        public bool Search(int value)
        {
            return SearchRecursively(Root, value);
        }
        private bool SearchRecursively(Node root, int value)
        {
            if (root == null)
            {
                return false;
            }
            if(value == root.Value)
            {
                return true;
            }
            else if(value < root.Value)
            {
                return SearchRecursively(root.Left, value);
            }
            else
            {
                return SearchRecursively(root.Right, value);
            }
        }
        public void Delete(int value) 
        { 
            Root = DeleteRecursively(Root, value);
        }
        private Node DeleteRecursively(Node root, int value)
        {
            if(root == null)
            {
                return root;
            }
            if(value < root.Value)
            {
                root.Left = DeleteRecursively(root.Left, value);
            }
            else if(value > root.Value)
            {
                root.Right = DeleteRecursively(root.Right, value);
            }
            else
            {
                if(root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }
                root.Value = MinValue(root.Right);
                root.Right = DeleteRecursively(root.Right, root.Value);
            }
            return root;
        }

        private int MinValue(Node node)
        {
            int minValue = node.Value;
            while(node.Left != null)
            {
                node = node.Left;
                minValue = node.Value;
            }
            return minValue;
        }

    }
}
