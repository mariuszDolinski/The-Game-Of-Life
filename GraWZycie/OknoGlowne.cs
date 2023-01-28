using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/////////////////////////////////////
/// Implementacja GRY W ŻYCIE
/// Autor: Mariusz Doliński
/// /////////////////////////////////

namespace GraWZycie
{
    public partial class OknoGlowne : Form
    {
        Pole[,] plansza;
        int[,] nast;
        const int rozmiarPola = 16;
        const int szerokoscPlanszy = 75;
        const int wysokoscPlanszy = 41;
        //Graphics g;

        public OknoGlowne()
        {
            InitializeComponent();
            plansza = new Pole[szerokoscPlanszy, wysokoscPlanszy];
            nast = new int[szerokoscPlanszy, wysokoscPlanszy];
            for (int i = 0; i < szerokoscPlanszy; i++)
                for (int j = 0; j < wysokoscPlanszy; j++)
                {
                    plansza[i, j] = new Pole(i, j, rozmiarPola);
                    plansza[i, j].Click += new EventHandler(this.Label_Click);
                    this.Controls.Add(plansza[i, j]);
                    nast[i, j] = 0;
                }
            timer1.Interval = 300;

            this.Size = new Size(rozmiarPola * szerokoscPlanszy + 23, rozmiarPola * wysokoscPlanszy + 67);

            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }


        private int[,] labelNaInt(Pole[,] tab)
        {
            int[,] wynik;
            wynik = new int[szerokoscPlanszy,wysokoscPlanszy];
            for (int i = 0; i < szerokoscPlanszy; i++)
                for (int j = 0; j < wysokoscPlanszy; j++)
                    wynik[i, j] = 0;
            for (int i = 0; i < szerokoscPlanszy; i++)
                for (int j = 0; j < wysokoscPlanszy; j++)
                    if (tab[i, j].czyKomorka()) wynik[i, j] = 1;

            return wynik;
        }

        private int liczSasiadow(int i, int j)
        {
            int ile = 0;

                    if (i - 1 > 0)
                        if (plansza[i - 1, j].czyKomorka()) ile++;
                    if (i + 1 < szerokoscPlanszy - 1)
                        if (plansza[i + 1, j].czyKomorka()) ile++;
                    if (j - 1 > 0)
                        if (plansza[i, j - 1].czyKomorka()) ile++;
                    if (j + 1 < wysokoscPlanszy - 1)
                        if (plansza[i, j + 1].czyKomorka()) ile++;
                    if (i - 1 > 0 && j - 1 > 0)
                        if (plansza[i - 1, j - 1].czyKomorka()) ile++;
                    if (i + 1 < szerokoscPlanszy && j - 1 > 0)
                        if (plansza[i + 1, j - 1].czyKomorka()) ile++;
                    if (i + 1 < szerokoscPlanszy && j + 1 < wysokoscPlanszy)
                        if (plansza[i + 1, j + 1].czyKomorka()) ile++;
                    if (i - 1 > 0 && j + 1 < wysokoscPlanszy)
                        if (plansza[i - 1, j + 1].czyKomorka()) ile++;

            return ile;
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label aktualna = (Label)sender;
            PozycjaPola poz = (PozycjaPola)aktualna.Tag;
            if (plansza[poz.X, poz.Y].czyKomorka())
            {
                plansza[poz.X, poz.Y].zabij();
                nast[poz.X, poz.Y] = 0;
            }
            else
            {
                plansza[poz.X, poz.Y].ozyw();
                nast[poz.X, poz.Y] = 1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void wyszyscToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < szerokoscPlanszy; i++)
                for (int j = 0; j < wysokoscPlanszy; j++)
                    plansza[i, j].zabij();
        }

        private void timer_Tick(object sender, EventArgs e)
        {

            nast = labelNaInt(plansza);

            for (int i = 0; i < szerokoscPlanszy; i++)
                for (int j = 0; j < wysokoscPlanszy; j++)
                    if (plansza[i, j].czyKomorka())
                    {
                        if (liczSasiadow(i, j) != 2 && liczSasiadow(i, j) != 3)
                        {
                            nast[i, j] = 0;
                        }
                        else
                            nast[i, j] = 1;
                    }
                    else
                    {
                        if (liczSasiadow(i, j) == 3)
                            nast[i, j] = 1;
                        else
                            nast[i, j] = 0;
                    }

            for (int i = 0; i < szerokoscPlanszy; i++)
                for (int j = 0; j < wysokoscPlanszy; j++)
                    if (nast[i, j] == 1)
                        plansza[i, j].ozyw();
                    else
                        plansza[i, j].zabij();

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void koniecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void działoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < szerokoscPlanszy; i++)
                for (int j = 0; j < wysokoscPlanszy; j++)
                    plansza[i, j].zabij();
            plansza[26, 1].ozyw();
            plansza[26, 2].ozyw();
            plansza[24, 2].ozyw();
            plansza[23, 3].ozyw();
            plansza[22, 3].ozyw();
            plansza[23, 3].ozyw();
            plansza[15, 3].ozyw();
            plansza[14, 3].ozyw();
            plansza[36, 3].ozyw();
            plansza[37, 3].ozyw();
            plansza[22, 4].ozyw();
            plansza[23, 4].ozyw();
            plansza[17, 4].ozyw();
            plansza[13, 4].ozyw();
            plansza[36, 4].ozyw();
            plansza[37, 4].ozyw();
            plansza[22, 5].ozyw();
            plansza[23, 5].ozyw();
            plansza[18, 5].ozyw();
            plansza[12, 5].ozyw();
            plansza[3, 5].ozyw();
            plansza[2, 5].ozyw();
            plansza[24, 6].ozyw();
            plansza[26, 6].ozyw();
            plansza[19, 6].ozyw();
            plansza[18, 6].ozyw();
            plansza[16, 6].ozyw();
            plansza[12, 6].ozyw();
            plansza[3, 6].ozyw();
            plansza[2, 6].ozyw();
            plansza[26, 7].ozyw();
            plansza[18, 7].ozyw();
            plansza[12, 7].ozyw();
            plansza[17, 8].ozyw();
            plansza[13, 8].ozyw();
            plansza[14, 9].ozyw();
            plansza[15, 9].ozyw();
            plansza[46, 30].ozyw();
            plansza[46, 31].ozyw();
            plansza[47, 30].ozyw();
            plansza[47, 31].ozyw();
            plansza[49, 30].ozyw();
            plansza[49, 31].ozyw();
            plansza[46, 33].ozyw();
            plansza[47, 33].ozyw();
            plansza[47, 34].ozyw();
            plansza[47, 35].ozyw();
            plansza[48, 36].ozyw();
            plansza[49, 35].ozyw();
            plansza[49, 34].ozyw();
            plansza[49, 33].ozyw();
            plansza[50, 33].ozyw();
            plansza[51, 33].ozyw();
            plansza[52, 32].ozyw();
            plansza[51, 31].ozyw();
            plansza[50, 31].ozyw();



        }
    }
}
