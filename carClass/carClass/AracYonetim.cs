using System;
using System.Numerics;
using System.Reflection;

namespace carClass
{
	public class AracYonetim
	{
		private List<Arac> araclar = new List<Arac>();

		public void AracEkle()
		{
            Arac arac = new Arac();
            Console.Write("Araç Markası:");
            arac.Marka = Console.ReadLine();
            Console.Write("Araç Modeli:");
            arac.Model = Console.ReadLine();
            Console.Write("Araç Plakası:");
            arac.Plaka = Console.ReadLine();
            Console.WriteLine("Araç Başarılı Bir Şekilde Eklendi");

            araclar.Add(arac);
        }

        public void TumAraclar()
        {
            Console.WriteLine("Tüm Araçlarınız");
            foreach(var arac in araclar)
            {
                arac.AracListele();
            }
        }

        public void AracGuncelle()
        {
            Console.WriteLine("Araç Plakası:");
            string plaka = Console.ReadLine();

            Arac arac = araclar.FirstOrDefault(a => a.Plaka == plaka);

            if (arac != null)
            {
                Console.WriteLine("Yeni Araç Markası:");
                arac.Marka = Console.ReadLine();
                Console.WriteLine("Yeni Araç Modeli");
                arac.Model = Console.ReadLine();
                Console.WriteLine("Güncelleme Başarılı");
            }
            else
            {
                Console.WriteLine("Eşleşen Plaka Bulunamadı");
            }
        }
	}
}

