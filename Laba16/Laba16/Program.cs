using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Laba16
{
    class Program
    {
        private static int _seed = Environment.TickCount;
        private static ThreadLocal<Random> _random = new(() => new Random(Interlocked.Increment(ref _seed)));

        private static void Main(string[] args)
        {
            Console.WriteLine("----Task 1----");
            Task1(_random.Value.Next(1, 21));
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 2----");
            Task2(_random.Value.Next(2, 21), 2.53f, 0.5f);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 3----");
            Task3(_random.Value.Next(3, 21), _random.Value.Next(-100, 100), _random.Value.Next(-100, 100));
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 4----");
            Task4(_random.Value.Next(1, 21));
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 5----");
            Task5(_random.Value.Next(1, 21));
            Console.WriteLine();
            Console.WriteLine("----End----");
            
        }

        private static void Print<T>(List<T> list)
            where T : struct
        {
            foreach (T item in list)
            {
                Console.Write($"{item} | ");
            }
        }
        
        private static void Task1(in int n)
        {
            if (n <= 0)
            {
                Console.WriteLine("N должна быть больше 0!");
                return;
            }
            
            List<int> digits = new();

            for (int i = 0; i <= n; i++)
            {
                if (i % 2 != 0)
                {
                    digits.Add(i);
                }
            }
            
            Print(digits);
        }

        private static void Task2(in int n, in float a, in float d)
        {
            if (n < 1)
            {
                Console.WriteLine("N должна быть больше 1!");
                return;
            }

            List<float> digits = new() {a};

            for (int i = 1; i <= n; i++)
            {
                float result = (float) Math.Round(a * (float) Math.Pow(d, i), 6);
                digits.Add(result);
            }

            Print(digits);
        }

        private static void Task3(in int n, in float a, in float b)
        {
            if (n < 2)
            {
                Console.WriteLine("N должна быть больше 2!");
                return;
            }

            List<float> digits = new() {a, b};

            for (int i = 0; i <= n; i++)
            {
                digits.Add(digits.Sum());
            }
            
            Print(digits);
        }

        private static void Task4(in int n)
        {
            if (n <= 0)
            {
                Console.WriteLine("N должна быть больше 0!");
                return;
            }

            List<int> digits = new();

            for (int i = 0; i <= n; i++)
            {
                digits.Add(_random.Value.Next(0, 100));
            }

            for (int i = 0, j = 0; i < digits.Count;)
            {
                if (i % 2 != 0 && i != 0)
                {
                    Console.Write($"{digits[n - j]} | ");
                    j++;
                    i++;
                }
                else
                {
                    if (i != 0)
                    {
                        Console.Write($"{digits[i - j]} | ");
                        i++;
                        continue;
                    }
                    
                    Console.Write($"{digits[i]} | ");
                    i++;
                }
            }

        }

        private static void Task5(in int n)
        {
            if (n <= 0)
            {
                Console.WriteLine("N должна быть больше 0!");
                return;
            }

            List<int> digits = new();

            for (int i = 0; i <= n; i++)
            {
                digits.Add(_random.Value.Next(0, 100));
            }

            foreach (int digit in digits.Where(d => d % 2 != 0).OrderBy(d => d).ToList())
            {
                Console.Write($"{digit} | ");
            }

            Console.WriteLine();
            
            foreach (int digit in digits.Where(d => d % 2 == 0).OrderByDescending(d => d).ToList())
            {
                Console.Write($"{digit} | ");
            }
        }
    }
}