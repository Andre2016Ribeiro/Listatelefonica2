using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
        string[] lineOfContentstelemovel = File.ReadAllLines("telemoveis.txt");

        public void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader("favoritos.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {

                    string[] tokensdata = line.Split(',');
                    try
                    {
                        dataGridView1.Rows.Add(tokensdata[0], tokensdata[1], tokensdata[2], tokensdata[3], tokensdata[4]);

                    }
                    catch (Exception)
                    {


                    }



                }
            }

            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(',');
                comboBox1.Items.Add(tokens[2] + "  -  " + tokens[3]);
            }
            foreach (var line in lineOfContentstelemovel)
            {
                string[] tokenstelemovel = line.Split(',');
                comboBox2.Items.Add(tokenstelemovel[2] + "  -  " + tokenstelemovel[3]);

            }

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = comboBox1.SelectedIndex.ToString();
            var t = "";
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(',');
                if (tokens[0] == s)
                {
                    textBox1.Text = tokens[3];
                    textBox2.Text = tokens[1];
                    textBox3.Text = tokens[4];
                    textBox4.Text = tokens[2];
                    if (tokens[5] != "") { t = tokens[5]; }
                    else { t = "x"; }

                }
            }
            foreach (var line in lineOfContentstelemovel)
            {
                string[] tokenstelemovel = line.Split(',');
                if (tokenstelemovel[5] == t)
                {
                    textBox5.Text = tokenstelemovel[1];
                    break;

                }
                else { textBox5.Text = ""; }
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = comboBox2.SelectedIndex.ToString();
            var t = "";
            foreach (var line in lineOfContentstelemovel)
            {

                string[] tokenstelemovel = line.Split(',');
                if (tokenstelemovel[0] == s)
                {
                    textBox5.Text = tokenstelemovel[1];
                    textBox1.Text = tokenstelemovel[3];
                    textBox3.Text = tokenstelemovel[4];
                    textBox4.Text = tokenstelemovel[2];
                    if (tokenstelemovel[5] != "") { t = tokenstelemovel[5]; }
                    else { t = "x"; }
                }
            }
            foreach (var line in lineOfContents)
            {
                string[] tokens = line.Split(',');
                if (tokens[5] == t)
                {
                    textBox2.Text = tokens[1];
                    textBox3.Text = tokens[4];
                    break;

                }
                else { textBox2.Text = ""; }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextWriter tw = new StreamWriter("favoritos.txt", true);


            tw.WriteLine(textBox1.Text.ToString() + "," + textBox4.Text.ToString() + "," + textBox2.Text.ToString() + "," + textBox3.Text.ToString() + "," + textBox5.Text.ToString());


            tw.Close();
            dataGridView1.Rows.Clear();
            using (StreamReader sr = new StreamReader("favoritos.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] tokensdata = line.Split(',');
                    try
                    {
                        dataGridView1.Rows.Add(tokensdata[0], tokensdata[1], tokensdata[2], tokensdata[3], tokensdata[4]);
                    }
                    catch (Exception)
                    {


                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                TextWriter td = new StreamWriter("favoritos.txt");
                td.WriteLine("");
                td.Close();

                for (int Row = 0; Row < dataGridView1.RowCount - 1; Row++)
                {
                    TextWriter tw = new StreamWriter("favoritos.txt", true);

                    if (Row != e.RowIndex)
                    {
                        string a = dataGridView1.Rows[Row].Cells[0].Value.ToString() + "," + dataGridView1.Rows[Row].Cells[1].Value.ToString() + "," + dataGridView1.Rows[Row].Cells[2].Value.ToString() + "," + dataGridView1.Rows[Row].Cells[3].Value.ToString() + "," + dataGridView1.Rows[Row].Cells[4].Value.ToString();
                        tw.WriteLine(a);
                    }

                    tw.Close();
                }
                dataGridView1.Rows.Clear();
                using (StreamReader sr = new StreamReader("favoritos.txt"))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] tokensdata = line.Split(',');
                        try
                        {
                            dataGridView1.Rows.Add(tokensdata[0], tokensdata[1], tokensdata[2], tokensdata[3], tokensdata[4]);
                        }
                        catch (Exception)
                        {


                        }
                    }
                }
            }
        }
    }
}
