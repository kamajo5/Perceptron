using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron
{
    public partial class Form1 : Form
    {
        //tablica y; y=1 dla e>0; y=0 dla e<=0;
        List<int> YList = new List<int>();
        //tablica d - oczekiwanych wyjść 
        List<int> DList = new List<int>();                  
        RadioButton[] opcja;
        TextBox[,] x;
        TextBox[,] w;
        TextBox[] b;
        TextBox[] d;
        TextBox[] e;
        TextBox[] y;
        //wspulczynik nauki
        int n = 1;
        //liczba krokow
        int kroki = 0;

        public Form1()
        {
            InitializeComponent();
            start();
            ustaw_opcje();
            btnDalej.Enabled = false;
            btnRysuj.Enabled = false;
            btnUcz.Enabled = false;
            ustaw_x();
        }
        public void start()
        {
            int odleglosc = 25;
            //wybor opcji
            opcja = new RadioButton[5];
            for (int i = 0; i < 5; i++)
            {
                opcja[i] = new RadioButton();
                opcja[i].Left = 5;
                opcja[i].Top = 10 + (i * odleglosc);
                opcja[i].Tag = i;
                opcja[i].Width = 60;
                opcja[i].Click += new System.EventHandler(this.ustaw_dane_wejsciowe);
                this.Controls.Add(opcja[i]);
            }
            //wejscia x
            x = new TextBox[2, 4];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    x[i, j] = new TextBox();
                    x[i, j].Width = 20;
                    x[i, j].Height = 50;
                    x[i, j].Left = 80 + (i * Form1.ActiveForm.Width) / 10;
                    x[i, j].Top = 30 + (j * Form1.ActiveForm.Height) / 10;
                    x[i, j].Enabled = true;
                    this.Controls.Add(x[i, j]);
                }
            }
            //wagi
            w = new TextBox[2, 4];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    w[i, j] = new TextBox();
                    w[i, j].Width = 20;
                    w[i, j].Height = 50;
                    w[i, j].Left = 145 + (i * Form1.ActiveForm.Width) / 10;
                    w[i, j].Top = 30 + (j * Form1.ActiveForm.Height) / 10;
                    w[i, j].Enabled = true;
                    this.Controls.Add(w[i, j]);
                }
            }
            ////bias dla sieci 2-input/2-output domyslnie 1; pozwala zmienić funkcję aktywacji
            b = new TextBox[4];
            odleglosc = 30;
            for (int i = 0; i < 4; i++)
            {
                b[i] = new TextBox();
                b[i].Left = 205;
                b[i].Top = 30 + (i * odleglosc);
                b[i].Width = 20;
                b[i].Height = 50;
                b[i].Text = "1";
                this.Controls.Add(b[i]);
            }
            //wspolczynik nauki
            e = new TextBox[4];
            for (int i = 0; i < 4; i++)
            {
                e[i] = new TextBox();
                e[i].Left = 240;
                e[i].Top = 30 + (i * odleglosc);
                e[i].Width = 20;
                e[i].Height = 50;
                this.Controls.Add(e[i]);
            }
            //oczekiwane wyjscie
            d = new TextBox[4];

            for (int i = 0; i < 4; i++)
            {
                d[i] = new TextBox();
                d[i].Left = 270;
                d[i].Top = 30 + (i * odleglosc);
                d[i].Width = 20;
                d[i].Height = 50;
                this.Controls.Add(d[i]);
            }
            // wyjscie
            y = new TextBox[4];
            odleglosc = 30;
            for (int i = 0; i < 4; i++)
            {
                y[i] = new TextBox();
                y[i].Left = 305;
                y[i].Top = 30 + (i * odleglosc);
                y[i].Width = 20;
                y[i].Height = 50;
                this.Controls.Add(y[i]);
            }
        }
        public void ustaw_opcje()
        {
            opcja[0].Text = "AND";
            opcja[1].Text = "OR";
            opcja[2].Text = "NAND";
            opcja[3].Text = "NOR";
            opcja[4].Text = "IMPL";
        }
        public void ustaw_x()
        {
            int[] tab = { 0, 0, 1, 1, 0, 1, 0, 1 };
            int k = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    x[i, j].Text = tab[k].ToString();
                    k++;
                }
            }
        }
        private void ustaw_dane_wejsciowe(object sender, EventArgs e)
        {
            int[] AND = { 0, 0, 0, 1 };
            int[] OR = { 0, 1, 1, 1 };
            int[] NAND = { 1, 1, 1, 0 };
            int[] NOR = { 1, 0, 0, 0 };
            int[] IMPL = { 1, 1, 0, 1 };
            RadioButton opcja = (sender as RadioButton);
            btnUcz.Enabled = true;
            if ((int)opcja.Tag == 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    d[i].Text = AND[i].ToString();
                }
            }
            if ((int)opcja.Tag == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    d[i].Text = OR[i].ToString();
                }
            }
            if ((int)opcja.Tag == 2)
            {
                for (int i = 0; i < 4; i++)
                {
                    d[i].Text = NAND[i].ToString();
                }
            }
            if ((int)opcja.Tag == 3)
            {
                for (int i = 0; i < 4; i++)
                {
                    d[i].Text = NOR[i].ToString();
                }
            }
            if ((int)opcja.Tag == 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    d[i].Text = IMPL[i].ToString();
                }
            }
        }
        public void generuj_dane_testowe()
        {
            Random random = new Random();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    w[i, j].Text = random.Next(0, 2).ToString();
                }
            }
        }
        public void funkcja_bi_polar()
        {
            int pom;
            int pom2;
            for (int i = 0; i < 4; i++)
            {
                int.TryParse(e[i].Text, out pom);
                int.TryParse(d[i].Text, out pom2);
                if (pom > 0)
                {
                    y[i].Text = "1";
                    YList.Add(1);
                    DList.Add(pom2);
                }
                else
                {
                    y[i].Text = "0";
                    YList.Add(0);
                    DList.Add(pom2);
                }
            }
        }
        private void LearningStep()
        {
            if (sprawdz())
            {
                MessageBox.Show("Siec nauczona w liczbie " + kroki.ToString() + " kroków");
                btnDalej.Enabled = false;
                btnRysuj.Enabled = true;
            }
            else
            {
                kroki++;
                int wartosc1 = 0;
                int wartosc2 = 0;
                int wartosc3 = 0;
                int wartosc4 = 0;
                int wynik = 0;
                for (int i = 0; i < 4; i++)
                {
                    int.TryParse(w[0, i].Text, out wartosc1);
                    int.TryParse(d[i].Text, out wartosc2);
                    int.TryParse(y[i].Text, out wartosc3);
                    int.TryParse(x[0, i].Text, out wartosc3);
                    wynik = wartosc1 + n * (wartosc2 - wartosc3) * wartosc4;
                    w[0, i].Text = wynik.ToString();
                }
                for (int i = 0; i < 4; i++)
                {
                    int.TryParse(w[1, i].Text, out wartosc1);
                    int.TryParse(d[i].Text, out wartosc2);
                    int.TryParse(y[i].Text, out wartosc3);
                    int.TryParse(x[1, i].Text, out wartosc4);
                    wynik = wartosc1 + n * (wartosc2 - wartosc3) * wartosc4;
                    w[1, i].Text = wynik.ToString();
                }
                for (int i = 0; i < 4; i++)
                {
                    int.TryParse(b[i].Text, out wartosc1);
                    int.TryParse(d[i].Text, out wartosc2);
                    int.TryParse(y[i].Text, out wartosc3);
                    wynik = wartosc1 + n * (wartosc2 - wartosc3) * 1;
                    b[i].Text = wynik.ToString();
                }
                for (int i = 0; i < 4; i++)
                {
                    int.TryParse(w[0, i].Text, out wartosc1);
                    int.TryParse(w[1, i].Text, out wartosc2);
                    int.TryParse(b[i].Text, out wartosc3);
                    wynik = wartosc1 * wartosc1 + wartosc2 * wartosc2 + wartosc2 + wartosc3;
                    e[i].Text = wynik.ToString();
                }
                funkcja_bi_polar();
            }
        }
        private bool sprawdz()
        {
            if (d[0].Text != y[0].Text || d[1].Text != y[1].Text || d[1].Text != y[2].Text || d[3].Text != y[3].Text)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnUcz_Click(object sender, EventArgs p)
        {
            chart1.Series["y"].Points.Clear();
            chart1.Series["d"].Points.Clear();
            for (int i = 0; i < 4; i++)
            {
                b[i].Text = "1";
                e[i].Clear();
            }
            kroki = 0;
            kroki = 0;
            generuj_dane_testowe();
            btnDalej.Enabled = true;
            int wynik = 0;
            int wartosc1 = 0;
            int wartosc2 = 0;
            int wartoscb = 0;
            btnUcz.Enabled = false;
            for (int i = 0; i < 4; i++)
            {
                int.TryParse(w[0, i].Text, out wartosc1);
                int.TryParse(w[1, i].Text, out wartosc2);
                int.TryParse(b[i].Text, out wartoscb);
                wynik = wartosc1 * wartosc1 + wartosc2 * wartosc2 + wartoscb;
                e[i].Text = wynik.ToString();
            }
            funkcja_bi_polar();
            kroki++;
        }
        private void btnDalej_Click(object sender, EventArgs p)
        {
            LearningStep();
        }
        private void btnRysuj_Click_1(object sender, EventArgs e)
        {
            int check = 0;
            for (int i = 0; check < kroki; i++)
            {
                chart1.Series["y"].Points.AddXY(i + 0, YList[i + 0]);
                chart1.Series["y"].Points.AddXY(i + 1, YList[i + 1]);
                chart1.Series["y"].Points.AddXY(i + 2, YList[i + 2]);
                chart1.Series["y"].Points.AddXY(i + 3, YList[i + 3]);

                chart1.Series["d"].Points.AddXY(i + 0, DList[0]);
                chart1.Series["d"].Points.AddXY(i + 1, DList[1]);
                chart1.Series["d"].Points.AddXY(i + 2, DList[2]);
                chart1.Series["d"].Points.AddXY(i + 3, DList[3]);

                check++;
            }
        }
    }
}
