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

namespace BINGO
{
    public partial class Form1 : Form
    {
        int ukupno_kugli = 48;
        int[] kuglice = new int[35];
        //int[] kuglice = { 1, 2, 3, 4, 5, 6, 7 };
        int izvucenih = 0;
        int br_pogodjenih = 0;
        TextBox[] tb_moji_brojevi = new TextBox[6];
        int dobitak = 0;
        bool dobitnik = false;
        int brojac_kugli = 0;

        int[] plave = { 3, 10, 17, 24, 31, 38, 45 };
        int[] zute = { 2, 9, 16, 23, 30, 37, 44 };
        int[] narandzaste = { 4, 11, 18, 25, 32, 39, 46 };
        int[] zelene = { 5, 12, 19, 26, 33, 40, 47 };
        int[] roze = { 6, 13, 20, 27, 34, 41, 48 };
        int[] ljubicaste = { 7, 14, 21, 28, 35, 42, 49 };

        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void btn_kuglica_Click(object sender, EventArgs e)
        {
            reset();
            if (checkMyNumbers())
            {
                izvuciKugle();
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Morate unijeti svih 7 brojeva!");
            }

        }

        
        void timer_Tick(object sender, EventArgs e)
        {
            /*
            izvucenih++;
            lbl_rb_izvl.Text = izvucenih.ToString();
            int kugla = izvuciKuglu();
            
            btn_kuglica.ForeColor = Color.Black;
            if (izvucena(kugla))
            {
                br_pogodjenih++;
                lbl_br_pogodjenih.Text = br_pogodjenih.ToString();
                btn_kuglica.ForeColor = Color.Red;
            }
            if (br_pogodjenih == 7)
            {
                dobitak = izvucenih;
                dobitnik = true;
            }
            btn_kuglica.Text = kugla.ToString();
            richTextBox1.Text += kugla + ", ";
            if (izvucenih == 34)
            {
                timer1.Stop();
                if (dobitnik == true)
                {
                    int KM = pogodjeno(dobitak);
                    lbl_dobitan.Text = "Listic je DOBITAN (" + KM + "KM)";
                }
                MessageBox.Show("Izvlacenje je zavrseno.");
            }
            */
            izvucenih++;
            btn_kuglica.ForeColor = Color.Black;
            btn_kuglica.Text = kuglice[izvucenih-1].ToString();
            btn_kuglica.BackgroundImage = bojaKugle(btn_kuglica);
            richTextBox1.Text += kuglice[izvucenih-1] + ", ";
            lbl_rb_izvl.Text = (izvucenih).ToString();
            if (izvucena(kuglice[izvucenih-1]))
            {
                br_pogodjenih++;
                lbl_br_pogodjenih.Text = br_pogodjenih.ToString();
                btn_kuglica.ForeColor = Color.Red;
            }
            if (br_pogodjenih == 7 && dobitnik == false)
            {
                dobitak = izvucenih; 
                dobitnik = true;
            }
            if (izvucenih == 35)
            {
                timer1.Stop();
                if (dobitnik == true)
                {
                    int KM = pogodjeno(dobitak);
                    lbl_dobitan.Text = "Listic je DOBITAN (" + KM + "KM)";
                }
                else
                {
                    lbl_dobitan.Text = "Listic nije DOBITAN";
                    MessageBox.Show("Izvlacenje je zavrseno.");
                }
            }
            
        }

        public Image bojaKugle(Button b)
        {
            if(plave.Contains(int.Parse(b.Text)))
            {
                return Properties.Resources.plava;
            }
            if (zute.Contains(int.Parse(b.Text)))
            {
                return Properties.Resources.zuta;
            }
            if (narandzaste.Contains(int.Parse(b.Text)))
            {
                return Properties.Resources.narandzasta;
            }
            if (ljubicaste.Contains(int.Parse(b.Text)))
            {
                return Properties.Resources.ljubicasta;
            }
            if (zelene.Contains(int.Parse(b.Text)))
            {
                return Properties.Resources.zelena;
            }
            if (roze.Contains(int.Parse(b.Text)))
            {
                return Properties.Resources.roza;
            }
            return Properties.Resources.plava;
        }

        public bool checkMyNumbers()
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" ) 
                return true; // ne smije se unijeti isti broj, mora biti u opsegu 1..49
            return false;
        }
        
        //public int izvuciKuglu()
        //{
            //int broj, broj2;
            //Random r = new Random();
            //broj = r.Next(49) + 1;
            //if (kuglice.Contains(broj))
            //{
            //    broj2 = r.Next(49) + 1;
            //    kuglice[brojac_kugli++] = broj2;
            //    return broj2;
            //} 
            //kuglice[brojac_kugli++] = broj;
            //return broj;   
        //}

        public void izvuciKugle()
        {
            var rnd = new Random();
            var randomNumbers = Enumerable.Range(1, 49).OrderBy(x => rnd.Next()).Take(35).ToList();
            
            for (int i = 0; i < 35; i++)
            {
                kuglice[i] = randomNumbers[i];
            }
        }

        public bool izvucena(int kugla)
        {
            if (textBox1.Text == kugla.ToString() || textBox2.Text == kugla.ToString() || textBox3.Text == kugla.ToString() || textBox4.Text == kugla.ToString() || textBox5.Text == kugla.ToString() || textBox6.Text == kugla.ToString() || textBox7.Text == kugla.ToString())
                return true;
            return false;
        }
        
        public void reset()
        {
            richTextBox1.Text = "";
            izvucenih = 0;
            br_pogodjenih = 0;
            dobitak = 0;
            dobitnik = false;
            lbl_br_pogodjenih.Text = "0";
            lbl_rb_izvl.Text = "";
            lbl_dobitan.Text = "";
            //textBox1.Text = "";
            //textBox2.Text = "";
            //textBox3.Text = "";
            //textBox4.Text = "";
            //textBox5.Text = "";
            //textBox6.Text = "";
            //textBox7.Text = "";
            btn_kuglica.Text = "";
        }
        public int pogodjeno(int dobitak)
        {
            switch (dobitak)
            {
                case 7: return 10000;
                case 8: return 7500;
                case 9: return 5000;
                case 10: return 2500;
                case 11: return 1000;
                case 12: return 500;
                case 13: return 300;
                case 14: return 200;
                case 15: return 100;
                case 16: return 90;
                case 17: return 80;
                case 18: return 70;
                case 19: return 60;
                case 20: return 50;
                case 21: return 40;
                case 22: return 30;
                case 23: return 25;
                case 24: return 20;
                case 25: return 15;
                case 26: return 10;
                case 27: return 9;
                case 28: return 8;
                case 29: return 7;
                case 30: return 6;
                case 31: return 5;
                case 32: return 4;
                case 33: return 3;
                case 34: return 2;
                case 35: return 1;
                default:
                    return 0;
            }
        }

        private void validacija(object sender, EventArgs e)
        {
            int brojKuglice;
            TextBox t = (TextBox) sender;
            if (!int.TryParse(t.Text, out brojKuglice))
            {
                //MessageBox.Show("Greska prilikom unosa!");
                t.Text = "";
            }
            TextBox[] kugle = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7 };
            
        }
    }
}
