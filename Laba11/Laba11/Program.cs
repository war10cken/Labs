using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba11
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

            if (a == b)
            {
                (a, b) = (0, 0);

                Console.WriteLine($"A: {a}");
                Console.WriteLine($"B: {b}");
                return;
            }

            if (a > b)
            {
                (a, b) = (a, a);
                
                Console.WriteLine($"A: {a}");
                Console.WriteLine($"B: {b}");
                return;
            }

            (a, b) = (b, b);
            
            Console.WriteLine($"A: {a}");
            Console.WriteLine($"B: {b}");
        }

        private static void Task2()
        {
            Console.Write("Введите первое число: ");
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите второе число: ");
            if (!int.TryParse(Console.ReadLine(), out int b))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите третье число: ");
            if (!int.TryParse(Console.ReadLine(), out int c))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            List<int> digits = new() {a, b, c};
            int maxDigit1 = digits.Max();
            digits.Remove(maxDigit1);
            int maxDigit2 = digits.Max();

            Console.WriteLine($"Сумма: {maxDigit1 + maxDigit2}");
        }

        private static void Task3()
        {
            var random = new Random();
            Point a = new Point(random.Next(-100, 100), random.Next(-100, 100));
            Point b = new Point(random.Next(-100, 100), random.Next(-100, 100));
            Point c = new Point(random.Next(-100, 100), random.Next(-100, 100));

            static float CalculateDistance(Point a, Point b) =>
                (float) Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));

            float ab = CalculateDistance(a, b);
            float ac = CalculateDistance(a, c);

            if (ab < ac)
            {
                Console.WriteLine("Точка B ближе к A");
                Console.WriteLine($"BX: {b.X}");
                Console.WriteLine($"BY: {b.Y}");
                Console.WriteLine($"Расстояние: {ab}");
                return;
            }

            if (ab > ac)
            {
                Console.WriteLine("Точка C ближе к A");
                Console.WriteLine($"CX: {c.X}");
                Console.WriteLine($"CY: {c.Y}");
                Console.WriteLine($"Расстояние: {ac}");
                return;
            }

            if (ab == ac)
            {
                Console.WriteLine("Точки B и C равноудаленны от точки A");
                Console.WriteLine($"BX: {b.X}");
                Console.WriteLine($"BY: {b.Y}");
                Console.WriteLine();
                Console.WriteLine($"CX: {c.X}");
                Console.WriteLine($"CY: {c.Y}");
                Console.WriteLine($"Расстояние: {ab}");
            }
        }

        private static void Task4()
        {
            Console.Write("Введите координату X: ");
            if (!int.TryParse(Console.ReadLine(), out int x) || x == 0)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите координату Y: ");
            if (!int.TryParse(Console.ReadLine(), out int y) || y == 0)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            Point point = new Point(x, y);

            if (point.X > 0 && point.Y > 0)
            {
                Console.WriteLine("Точка находится в 1 четверти");
                return;
            }

            if (point.X < 0 && point.Y > 0)
            {
                Console.WriteLine("Точка находится в 2 четверти");
                return;
            }

            if (point.X < 0 && point.Y < 0)
            {
                Console.WriteLine("Точка находится в 3 четверти");
                return;
            }
            
            Console.WriteLine("Точка находится в 4 четверти");
        }

        private static void Task5()
        {
            Console.Write("Введите целое число: ");
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            if (a < 0 && a % 2 == 0)
            {
                Console.WriteLine("Отрицательное чётное число");
                return;
            }

            if (a < 0 && a % 2 != 0)
            {
                Console.WriteLine("Отрицательное нечётное число");
                return;
            }
            
            if (a > 0 && a % 2 == 0)
            {
                Console.WriteLine("Положительное чётное число");
                return;
            }

            if (a > 0 && a % 2 != 0)
            {
                Console.WriteLine("Положительное нечётное число");
                return;
            }

            if (a == 0)
            {
                Console.WriteLine("Нулевое число");
            }
        }

        private static void Task6()
        {
            Console.Write("Введите целое число 1-999: ");
            if (!int.TryParse(Console.ReadLine(), out int a) || a is < 0 or > 999)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            if (a.ToString().Length == 2)
            {
                if (a % 2 == 0)
                {
                    Console.WriteLine("Чётное двузначное число");
                    return;
                }
                
                Console.WriteLine("Нечётное двузначное число");
                return;
            }

            if (a % 2 == 0)
            {
                Console.WriteLine("Чётное трёхзначное число");
                return;
            }
            
            Console.WriteLine("Нечётное трёхзначное число");
        }
    }
}