using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private DoublyLinkedList<string> elements;
        public Form1()
        {
            InitializeComponent();
            elements = new DoublyLinkedList<string>();
            UpdateListInfo();
        }

        private void buttonAddFirst_Click(object sender, EventArgs e)
        {
            elements.AddFirst("Element " + (elements.Count + 1));
            UpdateListBox();
            UpdateListInfo();

        }

        private void buttonAddLast_Click(object sender, EventArgs e)
        {
            elements.AddLast("Element " + (elements.Count + 1));
            UpdateListBox();
            UpdateListInfo();
        }

        private void buttonRemoveFirst_Click(object sender, EventArgs e)
        {
            elements.RemoveFirst();
            UpdateListBox();
            UpdateListInfo();
        }

        private void buttonRemoveLast_Click(object sender, EventArgs e)
        {
            elements.RemoveLast();
            UpdateListBox();
            UpdateListInfo();
        }
        private void UpdateListBox()
        {
            listBoxElements.Items.Clear();
            var current = elements.First;
            while (current != null)
            {
                listBoxElements.Items.Add(current.Data);
                current = current.Next;
            }
        }

        private void UpdateListInfo()
        {
            string head = elements.First != null ? elements.First.Data : "Brak";
            string tail = elements.Last != null ? elements.Last.Data : "Brak";
            int count = elements.Count;

            label1.Text = $"Head: {head}, Tail: {tail}, Count: {count}";
        }
    }
}
