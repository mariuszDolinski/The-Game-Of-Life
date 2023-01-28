using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace GraWZycie
{
    class Pole : Label
    {
        int x;
        int y;
        int rozmiar;
        bool komorka;

        public Pole()
        {
            x = y = 0;
            rozmiar = 10;
            this.Location = new Point(x * rozmiar, y * rozmiar);
            this.Size = new Size(rozmiar, rozmiar);
            this.BorderStyle = BorderStyle.None;
            this.BackColor = Color.White;
            this.Tag = new PozycjaPola() { X = x, Y = y };
            komorka = false;
        }

        public Pole(int x, int y, int r)
        {
            this.x = x;
            this.y = y;
            this.rozmiar = r;
            this.Location = new Point(x * rozmiar + 8, y * rozmiar + 32);
            this.Size = new Size(rozmiar, rozmiar);
            this.BorderStyle = BorderStyle.Fixed3D;
            this.BackColor = Color.White;
            this.Tag = new PozycjaPola() { X = x, Y = y };
            komorka = false;


            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        public bool czyKomorka()
        {
            return komorka;
        }

        public void ustawKomorke(bool b)
        {
            this.komorka = b;
        }

        public int pobierzRozmiar()
        {
            return this.rozmiar;
        }

        public void ozyw()
        {
            Image im = Image.FromFile("kolko2.jpg");
            this.Image = im;
            komorka = true;
        }

        public void zabij()
        {
            this.Image = null;
            komorka = false;
        }
    }
}
