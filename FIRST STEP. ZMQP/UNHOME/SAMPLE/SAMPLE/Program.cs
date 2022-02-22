using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAMPLE
{
    class Program
    {
        static void Main(string[] args)
        {
            //CharFunctionality();
            ParseFromStrings();
        }

        static void CharFunctionality()
        {
            Console.WriteLine("=> char type Functionality: "); //Just a output
            char myChar = 'a';
            Console.WriteLine($"Char isDigit('a'): {char.IsDigit(myChar)}"); //Check type, if true, return true
            Console.WriteLine($"char.IsLetter('a'): {char.IsLetter(myChar)}"); //Check type, if true, return true
            Console.WriteLine("char.IsWhiteSpace('Hello There'): {0}", char.IsWhiteSpace("Hello there", 5));// Find Space
            
        }

        static void ParseFromStrings()
        {
            Console.WriteLine("=> Data type parsing:");
            bool b = bool.Parse("True");
            Console.WriteLine($"Value of b: {b}");
            double d = double.Parse("99,884");
            Console.WriteLine($"Value of d: {d}");
            int i = int.Parse("8");
            Console.WriteLine($"Value of i: {i}");
            char c = Char.Parse("W");
            Console.WriteLine($"Value of c: {c}");
        }
    }
}
