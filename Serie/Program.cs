using System;
using System.Collections.Generic;
using System.Linq;

namespace Serie
{
    class Program
    {
        static List<int> GetDigits(int num)
        {
            var digitsList = new List<int>();

            while (num > 0)
            {
                digitsList.Add(num % 10);
                num /= 10;
            }

            digitsList.Reverse();
            return digitsList;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Presiona ESC para terminar");

            var series = new List<int>();
            series.Add(1);

            var digits = new Queue<int>();
            digits.Enqueue(1);

            Console.Write($"{series.Last()}");
            
            do
            {
                while (!Console.KeyAvailable)
                {
                    int currentNumber = series.Last();
                    int nextNumber = currentNumber + digits.Dequeue();
                    series.Add(nextNumber);
                    Console.Write($", {nextNumber}");

                    foreach (var digit in GetDigits(nextNumber))
                    {
                        digits.Enqueue(digit);
                    }

                    System.Threading.Thread.Sleep(1000);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
