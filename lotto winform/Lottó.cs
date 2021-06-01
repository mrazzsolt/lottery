using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lotto_winform
{
    public partial class Lottó : Form
    {
        
        Random r;
        Label[] cimkek;
        const int max = 90;
        int kijelol = 0;
        System.Media.SoundPlayer sp = new System.Media.SoundPlayer("drama.wav");
        System.Media.SoundPlayer yay = new System.Media.SoundPlayer("yay.wav");
        System.Media.SoundPlayer fail = new System.Media.SoundPlayer("fal.wav");
        public Lottó()
        {
            r = new Random();
            cimkek = new Label[max];
            InitializeComponent();
            this.Activated += AfterLoading;
            
            
            sp.Play();

        }
        private void AfterLoading(object sender, EventArgs e)
        {

           
            for (int i = 0; i < max; i++)
            {
                cimkek[i] = new Label();
            }
            int x = 0;
            int y = 0;
            
            for (int i = 0; i < max; i++)
            {
                cimkek[i].Parent = Lottó.ActiveForm;
                cimkek[i].Text = (i + 1).ToString();
                cimkek[i].Width = 35;
                cimkek[i].Height = 35;
                cimkek[i].Font = new Font("Arial",12, FontStyle.Bold);
                cimkek[i].TextAlign = ContentAlignment.MiddleCenter;
                cimkek[i].AutoSize = false;
                cimkek[i].BackColor = Color.CadetBlue;
                cimkek[i].Left = 125 + x * 35;
                x++;
                cimkek[i].Top = 125 + y * 35;
                if (i % 15 == 14)
                {
                    x = 0;
                    y += 1;
                }
                cimkek[i].Click += klikk;
            }
        }
        
        private void Form1_Load(object sender, System.EventArgs e)
        {
            BackColor = Color.White;
        }
        
        private void klikk(object sender, EventArgs e)
        {
            if ((sender as Label).BackColor != Color.Red)
            {
                if (kijelol < 5)
                {
                    (sender as Label).BackColor = Color.Red;
                    kijelol++;
                }
            }
            else
            {
                (sender as Label).BackColor = Color.CadetBlue;
                kijelol--;
            }
        }

       /* private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < max; i++)
            {
                cimkek[i] = new Label();
            }
            int x = 0;
            int y = 0;
            for (int i = 0; i < max; i++)
            {
                cimkek[i].Parent = Form1.ActiveForm;
                cimkek[i].Text = (i + 1).ToString();
                cimkek[i].Width = 20;
                cimkek[i].Height = 20;
                cimkek[i].AutoSize = false;
                cimkek[i].BackColor = Color.CadetBlue;
                cimkek[i].Left = 50 + x * 20;
                x++;
                cimkek[i].Top = 50 + y * 20;
                if (i % 15 == 14)
                {
                    x = 0;
                    y += 1;
                }
                cimkek[i].Click += klikk;
            }
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            if (kijelol == 5)
            {
                sp.Stop();
                Random r = new Random();
                List<int> kihuzott_szamok = new List<int>();
                while (kihuzott_szamok.Count != 5)
                {
                    int szam = r.Next(1, 91);
                    if (kihuzott_szamok.Contains(szam) == false)
                    {
                        kihuzott_szamok.Add(szam);
                        //MessageBox.Show(szam.ToString());
                    }
                }
                int talalatok_szama = 0;
                for (int i = 0; i < kihuzott_szamok.Count; i++)
                {
                    if ((cimkek[kihuzott_szamok[i] - 1].BackColor == Color.Red) == true)
                    {
                        talalatok_szama++;
                        cimkek[kihuzott_szamok[i] - 1].BackColor = Color.Green;
                    }
                    else
                    {
                        cimkek[kihuzott_szamok[i] - 1].BackColor = Color.Orange;
                    }
                }
                if (talalatok_szama == 0)
                {
                    fail.Play();
                    MessageBox.Show("Nem nyertél");


                }
                else if (talalatok_szama == 1)
                {
                    yay.Play();
                    MessageBox.Show("Gratulálunk,Egyesed van a lottón!");

                }
                else if (talalatok_szama == 2)
                {
                    yay.Play();
                    MessageBox.Show("Gratulálunk,Kettesed van a lottón!");

                }
                else if (talalatok_szama == 3)
                {
                    yay.Play();
                    MessageBox.Show("Gratulálunk,Hármasod van a lottón!");

                }
                else if (talalatok_szama == 4)
                {
                    yay.Play();
                    MessageBox.Show("Gratulálunk,Negyesed van a lottón!");

                }
                else if (talalatok_szama == 4)
                {
                    yay.Play();
                    MessageBox.Show("Gratulálunk,Megnyerted a főnyereményt!");

                }
            }
            else
            {
                MessageBox.Show("Nem tippeltél öt számot.");
                this.Refresh();
                Refresh();
                this.Hide();
                Lottó ss = new Lottó();
                ss.ShowDialog();

                DialogResult = DialogResult.OK;
                Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Újra szeretnéd indítani?", "Reset", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Refresh();
                Refresh();
                this.Hide();
                Lottó ss = new Lottó();
                ss.ShowDialog();
                
                DialogResult = DialogResult.OK;
                Close();


            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
           
            
        }
    }
}
