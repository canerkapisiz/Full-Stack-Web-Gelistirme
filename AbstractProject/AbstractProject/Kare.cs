using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractProject
{
	internal class Kare : Sekil
	{
		private double kenarUzunlugu;

		public Kare(double kenarUzunlugu)
		{
			this.kenarUzunlugu = kenarUzunlugu;
		}

        public override double alanHesapla()
        {
			return kenarUzunlugu * kenarUzunlugu;
        }
    }
}

