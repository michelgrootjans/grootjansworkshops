using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Domain;

namespace WinApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var names = new List<string> {"Albert Einstein", "John Cleese", "George W. Bush"};
            var namePrinter = new NamePrinter(AddToTextBox);
            namePrinter.Print(names);
        }

        private void AddToTextBox(string name)
        {
            textBox1.Text += name;
            textBox1.Text += Environment.NewLine;
        }
    }
}