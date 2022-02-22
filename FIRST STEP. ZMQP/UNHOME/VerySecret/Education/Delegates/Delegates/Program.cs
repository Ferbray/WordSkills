using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
          

            
        }
    }
    class Account
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler Notify;              // 1.Определение события
        public Account(int sum) => Sum = sum;
        public int Sum { get; private set; }
        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke($"На счет поступило: {sum}");   // 2.Вызов события 
        }
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                Notify?.Invoke($"Со счета снято: {sum}");   // 2.Вызов события
            }
            else
            {
                Notify?.Invoke($"Недостаточно денег на счете. Текущий баланс: {Sum}"); ;
            }
        }
    }
}
