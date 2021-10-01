using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Laba19
{
    class Program
    {
        private static int _seed = Environment.TickCount;
        private static ThreadLocal<Random> _random = new(() => new Random(Interlocked.Increment(ref _seed)));


        private static void Main(string[] args)
        {
            Console.WriteLine("----Task 1----");
            Task1(40);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 2----");
            Task2(40);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 3----");
            Task3(10);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 4----");
            Task4(10);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 5----");
            Task5(10);
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
        
        private static void Task1(in int n)
        {
            List<int> digits = new();

            for (int i = 0; i < n; i++)
            {
                digits.Add(_random.Value.Next(1, 101));
            }

            List<int> indexes = new();
            List<int> firstEntries = new();
            List<int> duplicatedElements = new();

            for (int i = 0; i < digits.Count; i++)
            {
                if (i + 1 != digits.Count)
                {
                    if (digits[i] == digits[i + 1])
                    {
                        indexes.Add(digits.FindIndex(d => d == digits[i + 1]));
                        firstEntries.Add(digits.FindIndex(d => d == digits[i]));
                        duplicatedElements.Add(digits[i]);
                    }
                }
            }

            if (indexes.Any())
            {
                Console.WriteLine("Исходный массив");
                PrintList(digits);
                
                Console.WriteLine("\n");
                
                foreach (int index in indexes)
                {
                    digits.RemoveAt(index);
                }

                Console.WriteLine("Индексы первых вхождений дубликатов");
                PrintList(firstEntries);

                Console.WriteLine("\n");

                Console.WriteLine("Дублированные эелементы");
                PrintList(duplicatedElements);
                
                Console.WriteLine("\n");
                
                Console.WriteLine("Массив с удалёнными дубликатами, оставив их первые вхождения");
                PrintList(digits);
                
                return;
            }

            Console.WriteLine("\nВ массиве не оказалось дубликатов");
        }

        private static void Task2(in int n)
        {
            List<int> digits = new();
            Dictionary<int, int> dict = new();

            for (int i = 0; i < n; i++)
            {
                digits.Add(_random.Value.Next(1, 101));
            }

            foreach(int value in digits)
            {
                dict.TryGetValue(value, out int count);
                dict[value] = count + 1;
            }

            List<int> sourceList = new(digits);
            List<int> duplicateDigits = new();

            Console.WriteLine("Исходный массив");
            PrintList(digits);
            Console.WriteLine("\n");
            
            foreach (var pair in dict.Where(pair => pair.Value == 2))
            {
                digits.RemoveAll(d => d == pair.Key);
                duplicateDigits.Add(pair.Key);
            }

            if (sourceList != digits)
            {
                Console.WriteLine("Дублированные элементы 2 раза");
                PrintList(duplicateDigits);

                Console.WriteLine("\n");
                
                Console.WriteLine("Массив с удалёнными дубликатами, которые встречаются 2 раза");
                PrintList(digits);
                return;
            }

            Console.WriteLine("В данном массиве нет дубликатов, которые встечаются 2 раза");
        }

        private static void Task3(in int n)
        {
            List<int> digits = new();

            for (int i = 0; i < n; i++)
            {
                digits.Add(_random.Value.Next(1, 101));
            }

            Console.WriteLine("Исходный массив");
            PrintList(digits);

            Console.WriteLine("\n");
            
            int minDigitIndex = digits.FindIndex(d => d == digits.Min());

            digits.Insert(minDigitIndex, 0);

            int maxDigitIndex = digits.FindIndex(d => d == digits.Max());
            
            digits.Insert(maxDigitIndex + 1, 0);

            Console.WriteLine("Массив с вставленными 0");
            PrintList(digits);
        }

        private static void Task4(in int n)
        {
            List<int> digits = new();

            for (int i = 0; i < n; i++)
            {
                digits.Add(_random.Value.Next(-100, 100));
            }
            
            Console.WriteLine("Исходный массив");
            PrintList(digits);

            Console.WriteLine("\n");
            
            for (int i = 0; i < digits.Count; i++)
            {
                if (digits[i] < 0)
                {
                    digits.Insert(i + 1, 0);
                }
            }

            Console.WriteLine("Массив с вставленными 0");
            PrintList(digits);
        }

        private static void Task5(in int n)
        {
            List<int> digits = new();

            for (int i = 0; i < n; i++)
            {
                digits.Add(_random.Value.Next(-100, 100));
            }
            
            Console.WriteLine("Исходный массив");
            PrintList(digits);

            Console.WriteLine("\n");
            
            for (int i = 0; i < digits.Count; i++)
            {
                if (digits[i] > 0)
                {
                    digits.Insert(i, 0);
                    i++;
                }
            }

            Console.WriteLine("Массив с вставленными 0");
            PrintList(digits);
        }
    }
}