using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public class DoublyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public int Count { get; private set; }

        public DoublyLinkedList()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
            Count++;
        }

        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Prev = tail;
                tail.Next = newNode;
                tail = newNode;
            }
            Count++;
        }

        public void RemoveFirst()
        {
            if (head != null)
            {
                if (head == tail)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    head = head.Next;
                    head.Prev = null;
                }
                Count--;
            }
        }

        public void RemoveLast()
        {
            if (tail != null)
            {
                if (head == tail)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    tail = tail.Prev;
                    tail.Next = null;
                }
                Count--;
            }
        }

        public Node<T> First => head;
        public Node<T> Last => tail;
    }
}
