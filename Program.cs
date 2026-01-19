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

    public void addLast(int data)
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
        Node current = head;
        while(current !=null && current.Data != after)
        {
            current = current.Next;
        }
        if(current == null)
        {
            return;
        }
        Node newNode = new Node(data);

        if(current.Next != null)
        {
            current.Next.Prev = newNode;
            newNode.Next = current.Next;
            current.Next = newNode;
            newNode.Prev = current;
        }
        else
        {
            addLast(data);
        }
    }

    public void printList()
    {
        Node current = head;
        while(current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
    }
}




class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList lista = new DoublyLinkedList();

        lista.addFirst(5);

        lista.addFirst(1);
        lista.addLast(4);
        lista.addAfter(5, 3);

        lista.printList();

    }
}