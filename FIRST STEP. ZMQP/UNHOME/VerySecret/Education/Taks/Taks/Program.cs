using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taks
{
    
    class Program
    {
        static int LenWord(string text)
        {
            char[] letters = text.ToCharArray();
            int len = 0;
            foreach (char letter in letters)
            {
                len++;
            }
            return len;
        }

        static bool isChetnoe(string text)
        {
            int len = LenWord(text);
            if (len % 2 == 0) return true;
            else return false;
        }
        static void Main(string[] args)
        {
            /* Person folk = new Person();
             folk.setName();
             folk.HelloMan();*/
            Console.WriteLine("Введи слово");
            string value = Console.ReadLine();
            LenWord(value);
            Console.WriteLine($"Количество символов в слове равно: {LenWord(value)}");
            if (isChetnoe(value))
            {
                Console.WriteLine("Количество символов в слове четно");

            }
            else
            {
                Console.WriteLine("Количество символов с слове нихуя не четно");
            }
        }   
    }
    /*class Person
    {
        public string Name { get; set; }
        public void setName()
        {
            Console.Write("Введи имя: ");
            Name = Console.ReadLine();
        }
        public void JN()
        {
            Console.WriteLine(Name);
        }

        public void HelloMan()
        {
            Console.WriteLine($"Hello, {Name}");
        }
    }*/
 

}
