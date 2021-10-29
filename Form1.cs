using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cäsar_Verschlüsselung
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Auswählen")
            {
                MessageBox.Show("Verschiebung auswählen");
            }
            else if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Geben Sie etwas in die Eingabe ein");
            }
            else
            {
                char[] Groß = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                char[] klein = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
                string klartext = Convert.ToString(richTextBox1.Text);
                int verschiebung = Convert.ToInt32(comboBox1.Text);
                string geheimtext = string.Empty;

                foreach(char x in klartext)//Wandle in Großbuchstaben um
                {
                    if (Groß.Contains(x))//Wenn x im Array ist tue das
                    {
                        int position = Array.IndexOf(Groß, x);
                        int position2 = position +verschiebung;
                        int rest = position2 % 26;
                        geheimtext += Groß[rest];

                    }
                    else if (klein.Contains(x))
                    {
                        int position = Array.IndexOf(klein, x);
                        int position2 = position + verschiebung;
                        int rest = position2 % 26;
                        geheimtext += klein[rest];
                    }
                    else//Übernimm unbekannte Zeichen die nicht enthalten sind
                    {
                        geheimtext += x;
                    }
                }
                richTextBox2.Text = geheimtext;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Auswählen")
            {
                MessageBox.Show("Verschiebung auswählen");
            }
            else if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Geben Sie etwas in die Eingabe ein");
            }
            else
            {
                char[] Groß = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                char[] klein = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
                string klartext = Convert.ToString(richTextBox1.Text);
                int verschiebung = Convert.ToInt32(comboBox1.Text);
                string geheimtext = string.Empty;

                foreach (char x in klartext)//Wandle in Großbuchstaben um
                {
                    if (Groß.Contains(x))//Wenn x im Array ist tue das
                    {
                        int position = Array.IndexOf(Groß, x);
                        int position2 = position - verschiebung;
                        if (1 <= position2 && position2 <= 26)
                        {
                            int rest = position2 % 26;
                            geheimtext += Groß[rest];
                        }
                        else 
                        {
                            int rest = 26 +position2;
                            if (rest == 26)
                            {
                                rest = 0;
                            }
                            geheimtext += Groß[rest];
                            
                        }

                    }
                    else if (klein.Contains(x))
                    {
                        int position = Array.IndexOf(klein, x);
                        int position2 = position - verschiebung;
                        if (1 <= position2 && position2 <= 26)
                        {
                            int rest = position2 % 26;
                            geheimtext += klein[rest];
                        }
                        else
                        {
                            int rest = 26 + position2;
                            if (rest == 26)
                            {
                                rest = 0;
                            }
                            geheimtext += klein[rest];

                        }
                    }
                    else//Übernimm unbekannte Zeichen die nicht enthalten sind
                    {
                        geheimtext += x;
                    }
                }
                richTextBox2.Text = geheimtext;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox2.Text;
            richTextBox2.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Bruteforce().Show();
        }
    }
}
