using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_guide
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Employee worker = new Employee { Name = "Xyesos Ebani", Age = 228 };
             worker.getName();*/
            Employee huesosEbani = new Employee("Xyu", "Ebain", 10);

            huesosEbani.getName();
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)//CONSTRUCTOR
        {
            Name = name;
            Age = age;
        }
        public void Info()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }
    }

    class Employee: Person // Наследование классов, sealed не дает наследоваться
    {   
        public string Company { get; set; }
        public Employee(string name, string company,int age)//CONSTRUCTOR
        
            :base(name, age)
            {
                Company = company;
            }
        
        public void getName()
        {
            Console.WriteLine(Name);
        }
    }

    class Client : Person
    {
        public string Bank { get; set; }
        public Client(string name, int age, string bank): base(name, age)
        {
            Bank = bank;
        }
    }

}
