namespace AbstractProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sekil dikdortgen = new Dikdortgen(5,5);
            Sekil kare = new Kare(3);

            Console.WriteLine(kare.alanHesapla());
            Console.WriteLine(dikdortgen.alanHesapla());

            Console.ReadLine();
        }
    }
}