namespace carClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Araç Ekleme
            Araçları Listeleme
            Araçları Güncelleme
            Çıkış
            */

            AracYonetim aracYonetim = new AracYonetim();

            while (true)
            {
                Console.WriteLine("Araç Yönetim Sistemi");
                Console.WriteLine("1 - Araç Ekleme");
                Console.WriteLine("2 - Araç Listele");
                Console.WriteLine("3 - Araç Güncelle");
                Console.WriteLine("4 - Çıkış");

                Console.WriteLine("Lütfen Seçiminizi Yapınız:");

                int secim;
                secim = int.Parse(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        aracYonetim.AracEkle();
                        break;
                    case 2:
                        aracYonetim.TumAraclar();
                        break;
                    case 3:
                        aracYonetim.AracGuncelle();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
