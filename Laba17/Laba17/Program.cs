using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Laba17
{
    class Program
    {
        private static int _seed = Environment.TickCount;
        private static ThreadLocal<Random> _random = new(() => new Random(Interlocked.Increment(ref _seed)));

        private static void Main(string[] args)
        {
            Console.WriteLine("----Task 1----");
            Task1(_random.Value.Next(1, 100), _random.Value.Next(1, 100), _random.Value.Next(1, 100));
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 2----");
            Task2(_random.Value.Next(4, 20));
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 3----");
            Task3(_random.Value.Next(1, 100));
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 4----");
            Task4(_random.Value.Next(1, 100));
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 5----");
            Task5(_random.Value.Next(1, 100));
            Console.WriteLine();
            Console.WriteLine("----End----");
        }

        private static void PrintList<T>(List<T> list)
            where T : struct
        {
            foreach (T item in list)
            {
                Console.Write($"{item} | ");
            }
        }

        private static void FillingList(ref List<int> list, in int count)
        {
            for (int i = 0; i <= count; i++)
            {
                list.Add(_random.Value.Next(1, 100));
            }
        }

        private static void Task1(in int n, in int k, in int l)
        {
            if (k < 1)
            {
                Console.WriteLine("k не может быть < 1");
                return;
            }

            if (l < k)
            {
                Console.WriteLine("l не может быть < k");
                return;
            }

            if (l > n)
            {
                Console.WriteLine("l не может быть > n");
                return;
            }

            if (n < l)
            {
                Console.WriteLine("n не может быть < l");
                return;
            }
            
            List<int> digits = new();

            FillingList(ref digits, n);

            float average = (float) digits.Skip(k - 1).SkipLast(n - l - 1).Average();

            Console.WriteLine($"Среднее арифметическое: {average}");
        }

        private static void Task2(in int n)
        {
            List<int> digits = new();

            FillingList(ref digits, n);

            digits = digits.Distinct().ToList();

            int d = digits[1] - digits[0]; 
            
            if (d == digits[3] - digits[2])
            {
                Console.WriteLine($"Разность арифметической прогрессии: {d}");
                return;
            }
            
            Console.WriteLine("Разность арифметической прогрессии: 0");
        }

        private static void Task3(in int n)
        {
            List<int> digits = new();
            
            FillingList(ref digits, n);

            int min = digits.Where(d => d % 2 == 0).Min();

            Console.WriteLine($"Минимальный элемент массива: {min}");
        }

        private static List<int> FindPeaks(List<int> list)
        {
            List<int> peaks = new();
            int current;
            IEnumerable<int> range;

            int checksOnEachSide = 5 / 2;

            for (int i = 0; i < list.Count; i++)
            {
                current = list[i];
                range = list;

                if (i > checksOnEachSide)
                {
                    range = range.Skip(i - checksOnEachSide);
                }

                range = range.Take(5);
                
                if(range.Any() && current == range.Max())
                {
                    peaks.Add(list[i]);
                }
            }

            return peaks;
        }

        private static void Task4(in int n)
        {
            List<int> digits = new();
            
            FillingList(ref digits, n);

            List<int> peaks = FindPeaks(digits);

            int index = digits.FindIndex(d => d == peaks.Max());

            Console.WriteLine($"Номер локального максимума: {index}");
        }

        private static void Task5(in int n)
        {
            int number = _random.Value.Next(1, 101);
            List<int> digits = new();

            FillingList(ref digits, n);
            
            digits.Insert(_random.Value.Next(0, digits.Count), number);
            digits.Insert(_random.Value.Next(0, digits.Count), number);

            List<int> indexes = new();
            List<int> tempDigits = new(digits);

            foreach (int digit in digits)
            {
                if (digit == number)
                {
                    int index = tempDigits.FindIndex(d => d == digit);
                    indexes.Add(index);
                    tempDigits[index] = 0;
                }
            }

            Console.WriteLine("Номера одинаковых чисел в порядке возрастания");
            PrintList(indexes.OrderBy(d => d).ToList());
        }
    }
}