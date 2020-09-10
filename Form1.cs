using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace skocko
{
    public partial class Form1 : Form
    {

        public Button[,] polja = new Button[8, 4];
        public static int jj;
        public Button[,] krugovi = new Button[8, 4];
        public int brojac;
        Color[] boje = new Color[6];
        Random r = new Random();
        public int brPoteza;
        Color[] kombinacija = new Color[4];
        public bool pogodjenPrvi;
        public bool pogodjenDrugi;
        public bool pogodjenTreci;
        public bool pogodjenCetvrti;

        public Form1()
        {
            InitializeComponent();
            brPoteza = 8;
            brojac = 0;
            jj = 0;
            pogodjenPrvi = false;
            pogodjenDrugi = false;
            pogodjenTreci = false;
            pogodjenCetvrti = false;

            boje[0] = Color.Black;
            boje[1] = Color.Blue;
            boje[2] = Color.Yellow;
            boje[3] = Color.Green;
            boje[4] = Color.Red;
            boje[5] = Color.LightGray;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    polja[i, j] = new Button();
                    polja[i, j].Dock = System.Windows.Forms.DockStyle.Fill;
                    polja[i, j].Location = new System.Drawing.Point(3, 3);
                    polja[i, j].Size = new System.Drawing.Size(26, 42);
                    polja[i, j].Name = i.ToString() + " " + j.ToString();
                    polja[i, j].TabIndex = 0;
                    
                    polja[i, j].UseVisualStyleBackColor = true;
                    this.tableLayoutPanel2.Controls.Add(polja[i, j], j, i);
                    polja[i, j].Click += new System.EventHandler(this.dugme_Click);
                }
            }


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    krugovi[i, j] = new Button();
                    krugovi[i, j].Dock = System.Windows.Forms.DockStyle.Fill;
                    krugovi[i, j].Location = new System.Drawing.Point(3, 3);
                    krugovi[i, j].Size = new System.Drawing.Size(26, 42);
                    krugovi[i, j].Name = i.ToString() + " " + j.ToString();
                    krugovi[i, j].TabIndex = 0;

                    krugovi[i, j].UseVisualStyleBackColor = true;
                    this.tableLayoutPanel3.Controls.Add(krugovi[i, j], j, i);
                    //polja[i, j].Click += new System.EventHandler(this.dugme_Click);
                }
            }

        }

        private void dugme_Click(object sender, EventArgs e)
        {
            

            Button dugme = sender as Button;
            string s = dugme.Name;
            string[] sar = s.Split(' ');
            int i = Convert.ToInt32(sar[0]);
            int j = Convert.ToInt32(sar[1]);
            polja[i, j].BackColor = boje[brojac];
            if (brojac == 5)
            {
                brojac = 0;
            }
            else
            {
                brojac++;
            }

        }

        public Color [] generisiKombinaciju()
        {
            Color[] kominacija = new Color[4];
            int p1 = r.Next(0, 6);
            kominacija[0] = boje[p1];
            int p2 = r.Next(0, 6);
            kominacija[1] = boje[p2];
            int p3 = r.Next(0, 6);
            kominacija[2] = boje[p3];
            int p4 = r.Next(0, 6);
            kominacija[3] = boje[p4];

            return kominacija;
        }
         
        

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = brPoteza.ToString();
            kombinacija = generisiKombinaciju();
        }

        public void updateLabelu()
        {
            label3.Text = brPoteza.ToString();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (brPoteza > 0 && jj<=7)
            {
            for(int ii = 0; ii < 4; ii++)
                {
                    if (ii == 0)
                    {
                        if (kombinacija[ii] == polja[jj, ii].BackColor)
                        {
                            pogodjenPrvi = true;
                        }
                    }
                    else if (ii == 1)
                    {
                        if (kombinacija[ii] == polja[jj, ii].BackColor)
                        {
                            pogodjenDrugi = true;
                        }
                    }
                    else if (ii == 2)
                    {
                        if (kombinacija[ii] == polja[jj, ii].BackColor)
                        {
                            pogodjenTreci = true;
                        }
                    }
                    else if (ii == 3)
                    {
                        if (kombinacija[ii] == polja[jj, ii].BackColor)
                        {
                            pogodjenCetvrti = true;
                        }
                    }
                }
                

            }
            else
            {
                MessageBox.Show("Nemate vise pokusaja!");
                Close();
            }

            for(int p = 0; p < 4; p++)
            {
                if (p == 0)
                {
                    if (pogodjenPrvi)
                    {
                        krugovi[jj, p].BackColor = Color.Red;
                    }
                    else
                    {
                        krugovi[jj, p].BackColor = Color.Gray;
                    }
                }
                else if (p== 1)
                {
                    if (pogodjenDrugi)
                    {
                        krugovi[jj, p].BackColor = Color.Red;
                    }
                    else
                    {
                        krugovi[jj, p].BackColor = Color.Gray;
                    }
                }
                else if (p == 2)
                {
                    if (pogodjenTreci)
                    {
                        krugovi[jj, p].BackColor = Color.Red;
                    }
                    else
                    {
                        krugovi[jj, p].BackColor = Color.Gray;
                    }
                }
                else if (p == 3)
                {
                    if (pogodjenCetvrti)
                    {
                        krugovi[jj, p].BackColor = Color.Red;
                    }
                    else
                    {
                        krugovi[jj, p].BackColor = Color.Gray;
                    }
                }
            }

            if(pogodjenPrvi && pogodjenDrugi && pogodjenTreci && pogodjenCetvrti)
            {
                MessageBox.Show("Uspesno ste pogodili kombinaciju!");
            }

            brPoteza--;
            updateLabelu();

            pogodjenPrvi = false;
            pogodjenDrugi = false;
            pogodjenTreci = false;
            pogodjenCetvrti = false;
            jj = jj + 1;
        }
    }
}
