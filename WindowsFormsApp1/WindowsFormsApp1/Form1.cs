using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int[] randomNumbers;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int count = (int)numericUpDown1.Value;
            randomNumbers = new int[count];
            for (int i = 0; i < count; i++)
            {
                randomNumbers[i] = random.Next(0, 101);
            }

            textBox2.Text = string.Join(", ", randomNumbers);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //bubble

            if(randomNumbers == null || randomNumbers.Length == 0)
            {
                MessageBox.Show("Najpierw wygeneruj liczby!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();


            for (int i = 0;i < randomNumbers.Length - 1;i++)
            {
                for (int j = 0; j < randomNumbers.Length - 1 - i; j++)
                {
                    if (randomNumbers[j] > randomNumbers[j + 1])
                    {
                        int temp = randomNumbers[j];
                        randomNumbers[j] = randomNumbers[j + 1];
                        randomNumbers[j + 1] = temp;
                    }
                }
            }
            stopwatch.Stop();
            textBox2.Text = string.Join(", ", randomNumbers);
            textBox3.Text = $"{stopwatch.ElapsedMilliseconds} ms\n";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string userInput = textBox1.Text;
                randomNumbers = userInput
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                textBox2.Text = string.Join(", ", randomNumbers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wprowadz prawidłowe liczby oddzielone przecinkami lub spacjami.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (randomNumbers == null || randomNumbers.Length == 0)
            {
                MessageBox.Show("Najpierw wygeneruj liczby lub wprowadź swoje!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            for (int i = 1; i < randomNumbers.Length; i++)
            {
                int key = randomNumbers[i];
                int j = i - 1;

                // Przesuwanie elementów większych od key na ich właściwe miejsce
                while (j >= 0 && randomNumbers[j] > key)
                {
                    randomNumbers[j + 1] = randomNumbers[j];
                    j--;
                }
                randomNumbers[j + 1] = key;
            }

            // Wyświetlanie posortowanych liczb w TextBox
            textBox2.Text = string.Join(", ", randomNumbers);
        
    }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
