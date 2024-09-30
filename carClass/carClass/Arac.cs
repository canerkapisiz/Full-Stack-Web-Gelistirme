using System;
namespace carClass
{
    public class Arac
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Plaka { get; set; }

        public void AracListele()
        {
            Console.WriteLine($"Marka: {Marka}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Plaka: {Plaka}");
        }
    }
}

