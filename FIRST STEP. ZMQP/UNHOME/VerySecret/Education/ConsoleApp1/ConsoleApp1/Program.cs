using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
       /* static int Factorial(int a)
        {
            if (a == 1) return 1;

            return a*Factorial(a - 1);
        }*/
        static void Main(string[] args)
        {
            /*Console.Write("Введите число: ");
            int value = int.Parse(Console.ReadLine());
            Console.WriteLine($"Факториал числа {value} равен {Factorial(value)}");*/
            Person Tom; // May run within constructor
            Tom.Name = "Tom";
            Tom.Age = 30;
            Tom.Info();
            ModuleInto mi = new ModuleInto();
            string a = mi.input();
            Console.WriteLine(a);
        }
    }

    struct Person
    {
        public string Name;
        public int Age;


        public void Create(string name, int age)
        {
            Console.WriteLine($"Создан чилипиздрик {name} с возрастом {age}");
            Name = name;
            Age = age;
        }
        public void Info()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }

    class ModuleInto
    {
        public void print(string text = "")
        {
            Console.WriteLine($"{text}");
        }

        public string input(string text = "")
        {
            Console.Write($"{text}");
            string value = Console.ReadLine();
            return value;
        }
    }
}
