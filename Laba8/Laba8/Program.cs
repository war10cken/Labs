using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba8
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("----Task 1----");
            Task1();
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 2----");
            Task2();
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 3----");
            Task3();
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 4----");
            Task4();
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 5----");
            Task5();
            Console.WriteLine();
            Console.WriteLine("----End----");
        }

        private static void Task1()
        {
            Console.Write("Введите размер файла в байтах: ");
            if (!int.TryParse(Console.ReadLine(), out int bytes) || bytes < 0)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            int result = bytes < 1024 ? bytes / 1024 + 1 : bytes / 1024;

            Console.WriteLine($"Колчество полных килобайтов: {result}");
        }

        private static void Task2()
        {
            Console.Write("Введите A: ");
            if (!int.TryParse(Console.ReadLine(), out int a) || a < 0)
            {
                Console.WriteLine("Вы ввели некорректное число или A меньше 0");
                return;
            }
            
            Console.Write("Введите B: ");
            if (!int.TryParse(Console.ReadLine(), out int b) || b < 0 || a < b)
            {
                Console.WriteLine("Вы ввели некорректное число или B больше A, или B меньше 0");
                return;
            }

            int count = 0;
            
            for (int i = b; i < a; i += b)
            {
                count++;
            }

            Console.WriteLine($"Количество отрезков B: {count}");
        }

        private static void Task3()
        {
            Console.Write("Введите A: ");
            if (!int.TryParse(Console.ReadLine(), out int a) || a < 0)
            {
                Console.WriteLine("Вы ввели некорректное число или A меньше 0");
                return;
            }
            
            Console.Write("Введите B: ");
            if (!int.TryParse(Console.ReadLine(), out int b) || b < 0 || a < b)
            {
                Console.WriteLine("Вы ввели некорректное число или B больше A, или B меньше 0");
                return;
            }
            
            int count = 0;
            
            for (int i = b; i < a; i += b)
            {
                count++;
            }

            int result = a - b * count;

            Console.WriteLine($"Длина не занятой части: {result}");
        }

        private static void Task4()
        {
            Console.Write("Введите 2-х значное число: ");
            if (!int.TryParse(Console.ReadLine(), out int digit) || digit is < 10 or > 99)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            char firstDigit = digit.ToString()[0];
            char secondDigit = digit.ToString()[1];

            string stringReverseDigit = new string(new[] {secondDigit, firstDigit});

            Console.WriteLine($"Число, полученное при перестановке цифр исходного числа: {stringReverseDigit}");
        }

        private static void Task5()
        {
            Console.Write("Введите 3-х значное число: ");
            if (!int.TryParse(Console.ReadLine(), out int digit) || digit is < 100 or > 999)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            List<char> digits = digit.ToString().ToCharArray().ToList();
            char firstChar = digits.FirstOrDefault();
            digits.RemoveAt(0);
            digits.Insert(digits.Count, firstChar);

            string changedDigit = new string(digits.ToArray());

            Console.WriteLine($"Изменённое число: {changedDigit}");
        }
    }
}