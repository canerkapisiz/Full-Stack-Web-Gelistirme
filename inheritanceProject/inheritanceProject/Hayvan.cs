using System;
namespace inheritanceProject
{
    public class Hayvan
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Beslenme()
        {
            Console.WriteLine($"{Name},besleniyor");
        }
    }
}

