using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba10
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
            Console.WriteLine();
            Console.WriteLine("----Task 6----");
            Task6();
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 7----");
            Task7();
            Console.WriteLine();
            Console.WriteLine("----End----");
        }

        private static void Task1()
        {
            Console.Write("Введите целое число A: ");
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите целое число B: ");
            if (!int.TryParse(Console.ReadLine(), out int b))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            Console.WriteLine("Справедливы неравенства A > 2 и B ≤ 3");
            Console.WriteLine();
            
            string isAMoreThan2 = a > 2 ? "Да" : "Нет"; 
            string isBLessOrEqual3 = b <= 3 ? "Да" : "Нет";
            
            Console.WriteLine($"A > 2 - {isAMoreThan2}");
            Console.WriteLine($"B <= 3 - {isBLessOrEqual3}");
        }

        private static void Task2()
        {
            Console.Write("Введите целое число A: ");
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите целое число B: ");
            if (!int.TryParse(Console.ReadLine(), out int b))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите целое число C: ");
            if (!int.TryParse(Console.ReadLine(), out int c))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            Console.WriteLine("Справедливо двойное неравенство A < B < C");
            Console.WriteLine();
            
            if (b > a && b < c)
            {
                Console.WriteLine("Да");
                return;
            }

            Console.WriteLine("Нет");
        }

        private static void Task3()
        {
            Console.Write("Введите целое двухзначное положительное число: ");
            if (!int.TryParse(Console.ReadLine(), out int a) || a < 0 || a.ToString().Length is < 2 or > 2)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            Console.WriteLine("Данное число является четным двузначным");
            Console.WriteLine();
            if (a % 2 == 0 && a.ToString().Length == 2)
            {
                Console.WriteLine("Да");
                return;
            }

            Console.WriteLine("Нет");
        }

        private static void Task4()
        {
            Console.Write("Введите трёхзначное число: ");
            if (!int.TryParse(Console.ReadLine(), out int a) || a.ToString().Length < 3)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            Console.WriteLine("Цифры данного числа образуют возрастающую или убывающую последовательность");
            Console.WriteLine();
            
            List<int> digits = a.ToString().Select(Convert.ToInt32).ToList();

            if (digits[1] - digits[0] > 0 && digits[2] - digits[1] > 0)
            {
                Console.WriteLine("Числа образуют возрастающую последовательность");
                return;
            }

            if (digits[1] - digits[0] < 0 && digits[2] - digits[1] < 0)
            {
                Console.WriteLine("Числа образуют убывающую последовательность");
                return;
            }

            Console.WriteLine("Числа не образуют никакую последовательность");
        }

        private static void Task5()
        {
            Console.Write("Введите четырёхзначное число: ");
            if (!int.TryParse(Console.ReadLine(), out int a) || a.ToString().Length < 4)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            List<int> digits = a.ToString().Select(Convert.ToInt32).ToList();
            List<bool> answers = new();

            for (int i = 0; i < digits.Count; i++)
            {
                if (digits[i] == digits[digits.Count - i - 1])
                {
                    answers.Add(true);
                    continue;
                }
                
                answers.Add(false);
            }
            
            if (answers.All(a => a) && answers.Count != 0)
            {
                Console.WriteLine("Данное число читается одинаково слева направо и справа налево");
                return;
            }

            Console.WriteLine("Данное число не читается одинаково слева направо и справа налево");
        }

        private static void Task6()
        {
            Console.Write("Введите целое число A: ");
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите целое число B: ");
            if (!int.TryParse(Console.ReadLine(), out int b))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите целое число C: ");
            if (!int.TryParse(Console.ReadLine(), out int c))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            double sumOfTriangleSides = Math.Pow(a, 2) + Math.Pow(b, 2);

            if (Math.Pow(c, 2) == sumOfTriangleSides)
            {
                Console.WriteLine("Треугольник прямоугольный");
                return;
            }

            if (Math.Pow(c, 2) < sumOfTriangleSides)
            {
                Console.WriteLine("Треугольник остроугольный");
                return;
            }

            if (Math.Pow(c, 2) > sumOfTriangleSides)
            {
                Console.WriteLine("Треугольник тупоугольный");
            }
        }

        private static void Task7()
        {
            Console.Write("Введите целое число A: ");
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите целое число B: ");
            if (!int.TryParse(Console.ReadLine(), out int b))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите целое число C: ");
            if (!int.TryParse(Console.ReadLine(), out int c))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            if (a + b >= c && b + c >= a && a + c >= b)
            {
                Console.WriteLine("Треугольник существует");
                return;
            }
            
            Console.WriteLine("Треугольник не существует");
        }
    }
}