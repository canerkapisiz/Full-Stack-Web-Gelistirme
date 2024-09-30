using System;
namespace inheritanceProject
{
    public class Kus : Hayvan
    {
        public void Uc()
        {
            Console.WriteLine($"{Name}, {Age} ve uçuyor");
        }
    }
}

