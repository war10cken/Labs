using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Laba18
{
    class Program
    {
        private static int _seed = Environment.TickCount;
        private static ThreadLocal<Random> _random = new(() => new Random(Interlocked.Increment(ref _seed)));


        private static void Main(string[] args)
        {
            Console.WriteLine("----Task 1----");
            Task1(15);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 2----");
            Task2(15);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 3----");
            Task3(15);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 4----");
            Task4(15);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 5----");
            Task5(15);
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
            List<int> a = new();
            List<int> b = new();

            for (int i = 0, j = n; i <= n; i++, j--)
            {
                a.Add(i);
                b.Add(j);
            }

            Console.WriteLine("Не преобразованный массив A");
            PrintList(a);
            Console.WriteLine();
            Console.WriteLine("Не преобразованный массив B");
            PrintList(b);
            
            (a, b) = (b, a);
            Console.WriteLine("\n");
            
            Console.WriteLine("Преобразованный массив A");
            PrintList(a);
            Console.WriteLine();
            Console.WriteLine("Преобразованный массив A");
            PrintList(b);
        }

        private static void Task2(in int n)
        {
            List<int> a = new();
            List<float> b = new();

            for (int i = 0; i < n; i++)
            {
                a.Add(i);
            }

            for (int i = 1; i < a.Count; i++)
            {
                float average = (float) a.Take(i).Average();
                b.Add(average);
            }

            Console.WriteLine("Массив средних арифметических значений");
            PrintList(b);
        }

        private static void Task3(in int n)
        {
            List<int> digits = new();
            List<int> oddDigits = new();

            for (int i = 0; i < n; i++)
            {
                digits.Add(i);
            }

            oddDigits = digits.Where(d => d % 2 != 0).ToList();
            digits = digits.Select(d => d + oddDigits.LastOrDefault()).ToList();

            Console.WriteLine("Массив нечётных чисел");
            PrintList(oddDigits);

            Console.WriteLine("\n");

            Console.WriteLine("Массив увеличенных чисел");
            PrintList(digits);
        }

        private static void Task4(in int n)
        {
            List<int> digits = new();

            for (int i = 0; i < n; i++)
            {
                digits.Add(_random.Value.Next(1, 100));
            }

            int minDigitIndex = digits.FindIndex(d => d == digits.Min());
            int maxDigitIndex = digits.FindIndex(d => d == digits.Max());

            Console.WriteLine("Массив с не обнулёнными элементами");
            PrintList(digits);
            Console.WriteLine("\n");

            if (minDigitIndex < maxDigitIndex)
            {
                for (int i = minDigitIndex + 1; i < maxDigitIndex; i++)
                {
                    digits[i] = 0;
                }    
            }

            if (minDigitIndex > maxDigitIndex)
            {
                for (int i = maxDigitIndex + 1; i < minDigitIndex; i++)
                {
                    digits[i] = 0;
                }   
            }

            Console.WriteLine("Массив с обнулёнными элементами");
            PrintList(digits);
        }

        private static void Task5(in int n)
        {
            List<int> digits = new();

            for (int i = 0; i < n; i++)
            {
                digits.Add(_random.Value.Next(1, 100));
            }

            Console.WriteLine("Исходный массив");
            PrintList(digits);

            Console.WriteLine("\n");
            
            int randomIndex = _random.Value.Next(0, n - 1);
            Console.WriteLine("Случайный индекс");
            Console.WriteLine(randomIndex);
            int firstElement = digits.FirstOrDefault();
            
            digits = digits.Skip(1).OrderBy(d => d).ToList();

            Console.WriteLine("Первый элемент массива");
            Console.WriteLine(firstElement);
            Console.WriteLine();
            
            digits.Remove(firstElement);
            digits.Insert(randomIndex, firstElement);

            Console.WriteLine("Отсортированный по возрастанию массив, где первый элемент на случайной позиции");
            PrintList(digits);
        }
    }
}