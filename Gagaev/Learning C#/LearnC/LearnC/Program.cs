using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LearnC
{
    class Program
    {
        static void Main(string[] args)
        {
            byte start_func = default;

            try
            {
                Console.WriteLine("Введите цифру от 1-3");
                start_func = checked((byte)int.Parse(Console.ReadLine()));
            }

            catch (OverflowException)
            {
                Console.WriteLine("Вы ввели недопустимый диапазон!");
            }

            catch (FormatException)
            {
                Console.WriteLine("Вы ввели не цифру!");
            }


            switch (start_func)
            {
                case 1:
                    Console.WriteLine("Вы перешли на Learn1");
                    Learn1();
                    break;
                case 2:
                    Console.WriteLine("Вы перешли на Learn2");
                    Learn2();
                    break;
                case 3:
                    Console.WriteLine("Вы перешли на Learn3");
                    Learn3();
                    break;
            }
            Console.ReadKey();
        }

        static void Learn1()
        {
            int bl_def = default;
            Console.WriteLine($"Int default: {bl_def}");

            string value = "2,12";

            if (float.TryParse(value, out float d))
            {
                Console.WriteLine($"{d}");
            }
            else
            {
                Console.WriteLine("gg");
            }
        }

        static void Learn2()
        {
            string spl = "12,3_4,56_7,89";
            string[] list1 = spl.Split('_');
            List<int> list3 = new List<int>();

            foreach(string i in list1)
            {
                string[] list2 = i.Split(',');
                for (int j=0; j<list2.Length; j++)
                {
                    list3.Add(int.Parse(list2[j]));
                }
            }
            foreach (int i in list3)
            {
                Console.WriteLine($"Numbers: {i}");
            }
        }

        static void Learn3()
        {
            StringBuilder remake_string = new StringBuilder("It's megasuper string");
            Console.WriteLine(remake_string.ToString());
            remake_string.Append(". Because stringbuilder text type");
            Console.WriteLine(remake_string.ToString());
            remake_string.Append(". New line oooh");
            Console.WriteLine(remake_string.ToString());
            Console.WriteLine("\a");
        }
    }
}
