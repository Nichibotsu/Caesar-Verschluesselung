using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Cäsar_Verschlüsselung
{
    public partial class Bruteforce : Form
    {
        public Bruteforce()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form1().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string output = string.Empty;

            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Geheimtext eingeben");
            }
            else
            {
                char[] Groß = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                char[] klein = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
                string geheim = richTextBox1.Text;
                string Möglicheausgabe = string.Empty;
                dataGridView1.ClearSelection();

                for (int n = 1; n < 26; n++)
                {
                    string output2 = string.Empty;
                    string klartextversuch = string.Empty;
                    foreach (char x in geheim)//Wandle in Großbuchstaben um
                    {
                        if (Groß.Contains(x))//Wenn x im Array ist tue das
                        {
                            int position = Array.IndexOf(Groß, x);
                            int position2 = position - n;
                            if (1 <= position2 && position2 <= 26)
                            {
                                int rest = position2 % 26;
                                klartextversuch += Groß[rest];
                            }
                            else
                            {
                                int rest = 26 + position2;
                                if (rest == 26)
                                {
                                    rest = 0;
                                }
                                klartextversuch += Groß[rest];

                            }

                        }
                        else if (klein.Contains(x))
                        {
                            int position = Array.IndexOf(klein, x);
                            int position2 = position - n;
                            if (1 <= position2 && position2 <= 26)
                            {
                                int rest = position2 % 26;
                                klartextversuch += klein[rest];
                            }
                            else
                            {
                                int rest = 26 + position2;
                                if (rest == 26)
                                {
                                    rest = 0;
                                }
                                klartextversuch += klein[rest];

                            }
                        }
                        else
                        {
                            klartextversuch += x;
                        }
                        
                    }

                    dataGridView1.Rows.Add(Convert.ToString(n), klartextversuch);

                }
            }

        }
    }
}
