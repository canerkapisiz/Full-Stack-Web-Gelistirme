using System;

namespace AbstractProject
{
    abstract class Sekil
    {
        public abstract double alanHesapla();
    }

    internal class Dikdortgen : Sekil
    {
        private double uzunluk;
            private double genislik;

        public Dikdortgen(double uzunluk, double genislik)
        {
            this.uzunluk = uzunluk;
            this.genislik = genislik;
        }

        public override double alanHesapla()
        {
            return uzunluk * genislik;
        }
    }
}

