using System;
namespace inheritanceProject
{
    public class Kedi : Hayvan
    {
       public void Hareket()
        {
            Console.WriteLine($"{Name},yürüyor");
        }
    }
}

