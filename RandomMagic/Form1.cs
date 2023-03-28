using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RandomMagic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool IsPrime(int number)
        {
            for (int i = 2; i <= number/2; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsMagicNumber(int number)
        {
            int sum = 0;
            int temp = number;
            while (temp > 0)
            {
                int digit = temp % 10;
                sum += Factorial(digit);
                temp /= 10;
            }
            return sum == number;
        }
        public int Factorial(int number)
        {
            int fact = 1;
            while(number > 0)
            {
                fact *= number;
                number--;
            }
            return fact;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num;
            if (int.TryParse(textBox1.Text, out num))
            {
                Thread t1 = new Thread(() =>
                {
                    List<int> magicNumbers = new List<int>();
                    for (int i = 1; i <= num; i++)
                    {
                        if (IsMagicNumber(i))
                        {
                            magicNumbers.Add(i);
                        }
                    }
                    listBox1.Invoke(new Action(() =>
                    {
                        listBox1.Items.Clear();
                        foreach (int magicNumber in magicNumbers)
                        {
                            listBox1.Items.Add(magicNumber);
                        }
                    }));
                });
                t1.Start();
            }
            else
            {
                MessageBox.Show("Please enter correct number!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num;
            if (int.TryParse(textBox2.Text, out num))
            {
                Thread t2 = new Thread(() =>
                {
                    List<int> primeNumbers = new List<int>();
                    for (int i = 2; i <= num; i++)
                    {
                        if (IsPrime(i))
                        {
                            primeNumbers.Add(i);
                        }
                    }

                    listBox1.Invoke(new Action(() =>
                    {
                        listBox1.Items.Clear();
                        foreach (int primeNumber in primeNumbers)
                        {
                            listBox1.Items.Add(primeNumber);
                        }
                    }));
                });
                t2.Start();
            }
            else
            {
                MessageBox.Show("Please enter correct number!");
            }

        }

        
    }
}
