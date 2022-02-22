using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FiveApp
{
    class Program
    {
        static void Main(string[] args)
        {
           // UseDateAndTimes();
        }

        static void UseDateAndTimes()
        {
            Console.WriteLine("=> Dates and Times: ");
            DateTime dt = new DateTime(2015, 10, 17); // Set date in dt
            Console.WriteLine($"The day of {dt.Date} is {dt.DayOfWeek}");
            TimeSpan ts = new TimeSpan(4, 30, 0);// H, M, S
            Console.WriteLine(ts);
            Console.WriteLine(ts.Subtract(new TimeSpan(0, 20, 0))); // 30m-20m
        }

        static void UseStringMethod()
        {
            Console.WriteLine("=> Using String Method (QWERTYUIOPASDFGHJKLZXCVBNM | mnbvcxzlkjhgfdsapoiuytrewq): ");
            string text = "QWERTYUIOPASDFGHJKLZXCVBNM";
            Console.WriteLine($"'Length' word: {text.Length}");

        }

        static void UseChecked()
        {
            byte b1 = 100;
            byte b2 = 250;
            byte sum = unchecked((byte)(b1 + b2));
        }

    }
}
