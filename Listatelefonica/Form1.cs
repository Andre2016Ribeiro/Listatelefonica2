using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listatelefonica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] lineOfContents = File.ReadAllLines("lista telefonica.txt");

        public void Form1_Load(object sender, EventArgs e)
        {
            
            
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(',');
                comboBox1.Items.Add(tokens[2] +"  -  "+ tokens[3]);
            }

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           var s= comboBox1.SelectedIndex.ToString();
            
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(',');
                if (tokens[0]==s)
                {
                    textBox1.Text= tokens[3];
                    textBox2.Text = tokens[1];
                    textBox3.Text = tokens[4];
                }      
            }

        }

       
    }
}
