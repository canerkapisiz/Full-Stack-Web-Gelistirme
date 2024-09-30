namespace inheritanceProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
             Kedi kedi = new Kedi();

            Console.Write("Kedinin Adını Yazınız:");
            kedi.Name = Console.ReadLine();
            kedi.Beslenme();

            Kus kus = new Kus();
            Console.Write("Kuşun Adını Yazınız:");
            kus.Name = Console.ReadLine();
            kus.Age = int.Parse(Console.ReadLine());

            kus.Uc();
            kedi.Hareket();

            Console.ReadLine();
        }
    }
}
