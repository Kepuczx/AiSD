using System;
using System.Data;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Serialization; // Wystarczy tylko to

public class Node
{
    public int Data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
    public int Height {get; set; }

    public Node(int data)
    {
        Data = data;
        Height = 1;
    }
}

public class BinaryTree
{
    public Node Root { get; set; }

    public void Insert(int data)
    {
        if (Root == null)
        {
            Root = new Node(data);
            return;
        }
        Root = InsertRec(Root, data);
    }

    private Node InsertRec(Node current, int data)
    {
        if (data < current.Data)
        {
            if (current.Left == null)
                current.Left = new Node(data);
            else
                InsertRec(current.Left, data);
        }
        else if(data > current.Data)
        {
            if (current.Right == null)
                current.Right = new Node(data);
            else
                InsertRec(current.Right, data);
        }
        else
        {
            return current;
        }

        current.Height = 1 + Math.Max(treeHeight(current.Left), treeHeight(current.Right));

        int balance = treeHeight(current.Left) - treeHeight(current.Right);

        if(balance > 1 && data < current.Left.Data)
        {
            return rotateRight(current);
        }
        if(balance < -1 && data > current.Right.Data)
        {
            return rotateLeft(current);
        }
        if(balance > 1 && data > current.Left.Data)
        {
            current.Left = rotateLeft(current.Left);
            return rotateRight(current);

        }
        if(balance < -1 && data < current.Right.Data)
        {
            current.Right = rotateRight(current.Right);
            return rotateLeft(current);
        }
        return current;
    }

    public Node Delete(Node current, int data)
    {
        if (current == null) return null;

        if (data < current.Data)
        {
            current.Left = Delete(current.Left, data);
        }
        else if (data > current.Data)
        {
            current.Right = Delete(current.Right, data);
        }
        else // Znaleziono węzeł do usunięcia
        {
            // Przypadek 0: Brak dzieci (Liść)
            if (current.Left == null && current.Right == null)
            {
                return null;
            }
            else
            {
                int ile = ileDzieci(current);

                // Przypadek 1: Jedno dziecko
                if (ile == 1)
                {
                    if (current.Left != null)
                        return current.Left;
                    else
                        return current.Right;
                }
                // Przypadek 2: Dwoje dzieci
                else if (ile == 2)
                {
                    int minVal = MinValue(current.Right);
                    current.Data = minVal;
                    
                    // POPRAWKA: Usunięto zdublowaną linię. Zostało tylko poprawne przypisanie:
                    current.Right = Delete(current.Right, minVal);
                }
            }
        }
        return current;
    }

    private int ileDzieci(Node current)
    {
        int ile = 0;
        if (current.Left != null) ile++;
        if (current.Right != null) ile++;
        return ile;
    }

    private int MinValue(Node node)
    {
        int minv = node.Data;
        while (node.Left != null)
        {
            minv = node.Left.Data;
            node = node.Left;
        }
        return minv;
    }

    //zig zag
    
    static int treeHeight(Node root)
    {
        if(root == null) return 0;
        int lHeight = treeHeight(root.Left);
        int rHeight = treeHeight(root.Right);
        return Math.Max(lHeight, rHeight) + 1;
    }
    private void PrintLevel(Node node, int level, bool ltr)
    {
        if (node == null)
        {
            return;
        }
        if(level == 1)
        {
            Console.Write(node.Data + " ");
        }else if (level > 1)
        {
            if (ltr)
            {
                PrintLevel(node.Left, level - 1, ltr);
                PrintLevel(node.Right, level - 1, ltr);
            }
            else
            {
                PrintLevel(node.Right, level - 1, ltr);
                PrintLevel(node.Left, level - 1, ltr);
            }
        }
    }

    public void ZigZag()
    {
        int h = treeHeight(Root);
        bool direction = true;

        for(int i = 1; i <= h; i++)
        {
            PrintLevel(Root, i , direction);
            direction = !direction;
        }
    }



    public Node rotateRight(Node root)
    {
        Node x = root.Left;
        Node B = x.Right;

        x.Right = root;
        root.Left = B;

        root.Height = Math.Max(treeHeight(root.Left), treeHeight(root.Right)) + 1;
        x.Height = Math.Max(treeHeight(x.Left), treeHeight(x.Right)) + 1;

        return x;
    }

    public Node rotateLeft(Node x)
    {
        Node y = x.Right;
        Node B = y.Left;

        y.Left = x;
        x.Right = B;

        x.Height = Math.Max(treeHeight(x.Left), treeHeight(x.Right)) + 1;
        y.Height = Math.Max(treeHeight(y.Left), treeHeight(y.Right)) + 1;

        return y;
    }

    public Node rotateLeftRight(Node z)
    {
        z.Left = rotateLeft(z.Left);
        return rotateRight(z);
    }
    public Node rotateRightLeft(Node x)
    {
        x.Right = rotateRight(x.Right);
        return rotateLeft(x);
    }

}


class Program
{
    static void Main(string[] args)
    {
        var tree = new BinaryTree();
        
        // Budujemy drzewo
        // 1. Korzeń
        tree.Insert(50);

        // 2. Pierwszy poziom
        tree.Insert(25);
        tree.Insert(75);

        // 3. Drugi poziom
        tree.Insert(15);
        tree.Insert(35);
        tree.Insert(65);
        tree.Insert(85);

        // 4. Trzeci poziom i liście (trochę chaosu)
        tree.Insert(5);
        tree.Insert(20);
        tree.Insert(30);
        tree.Insert(40);
        tree.Insert(60);
        tree.Insert(70);
        tree.Insert(80);
        tree.Insert(90);

        // 5. Dodatkowe węzły, żeby zrobić głębię
        tree.Insert(2);
        tree.Insert(8);
        tree.Insert(95);
        tree.Insert(100);
        tree.Insert(45);

        tree.Root = tree.Delete(tree.Root, 15);
        tree.Root = tree.Delete(tree.Root, 5);
        tree.Insert(5);
        tree.Insert(1);

        tree.ZigZag();
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        PrintTree(tree.Root, "", true);
    }

    static void PrintTree(Node node, string indent, bool isLast)
    {
        if (node == null) return;

        Console.Write(indent);

        if (isLast)
        {
            Console.Write("└─");
            indent += "  ";
        }
        else
        {
            Console.Write("├─");
            indent += "│ ";
        }

        Console.WriteLine(node.Data);

        bool leftIsLast = (node.Right == null);
        PrintTree(node.Left, indent, leftIsLast);
        PrintTree(node.Right, indent, true);
    }
}