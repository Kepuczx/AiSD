using System.ComponentModel;

public class Node
{
    public int Data;
    public Node Next;
    public Node Prev;

    public Node(int data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}
    public class DoublyLinkedList
    {
        private Node head;
        private Node tail;

        public void AddLast(int data)
        {
            Node newNode = new Node(data);

            if(head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }
        public void addFirst(int data)
    {
        Node newNode = new Node(data);

        if(head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            head.Prev = newNode;
            newNode.Next = head;
            head = newNode;
        }
    }

    public void addAfter(int after, int data)
    {
        Node afterNode = szukaj(after);

        if(afterNode == null)
        {
            AddLast(data);
            return;
        }
        Node newNode = new Node(data);
       
        newNode.Next = afterNode.Next;
        newNode.Prev = afterNode;
        if(afterNode.Next != null)
        {
            afterNode.Next.Prev = newNode;
        }
        else
        {
            tail = newNode;
        }
        afterNode.Next = newNode;
        
    }

    public Node szukaj(int data)
    {
        Node current = head;
        while(current != null)
        {
            if(current.Data == data)
            {
                return current;
            }
            current = current.Next;
        }
        return null;
    }


        public void DisplayForward()
        {
            Node current = head;
            while(current != null)
            {
                Console.Write(current.Data + " <-> ");
                current = current.Next;
            }
            Console.WriteLine("NULL");
        }
    }





class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList lista = new DoublyLinkedList();

        lista.AddLast(10);
        lista.AddLast(5);

        lista.DisplayForward();
    }
}