using System;
using System.Threading;

namespace Laba7
{
    class Program
    {
        private static int _seed = Environment.TickCount;
        private static ThreadLocal<Random> _random = new(() => new Random(Interlocked.Increment(ref _seed)));

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
            Console.Write("Введите значение угла в градусах: ");
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            if (a is < 0 or > 360)
            {
                Console.WriteLine("Угол меньше 0 или больше 360");
                return;
            }

            Console.WriteLine($"Радиан в угле {a}°: {Math.Round(a * Math.PI / 180, 4)}");
        }

        private static void Task2()
        {
            Console.Write("Введите значение угла в радианах: ");
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            if (a is < 0 or > (int) (2 * Math.PI))
            {
                Console.WriteLine("Угол меньше 0 или больше 2*π");
                return;
            }

            Console.WriteLine($"° в {a} радиан: {a * 180 / Math.PI}");
        }

        private static void Task3()
        {
            Console.Write("Введите 1 значение киллограмм: ");
            if (!int.TryParse(Console.ReadLine(), out int kg))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите цену: ");
            if (!int.TryParse(Console.ReadLine(), out int price))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите 2 значение киллограмм: ");
            if (!int.TryParse(Console.ReadLine(), out int kg1))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.WriteLine($"{kg} кг конфет стоит {price} рублей");
            Console.WriteLine($"1 кг конфет стоит {Math.Round((double) (1 * price / kg), 2)} рублей");
            Console.WriteLine($"{kg1} кг конфет стоит {Math.Round((double) (kg1 * price / kg), 2)} рублей");
        }

        private static void Task4()
        {
            Console.Write("Введите скорость 1 автомобиля: ");
            if (!int.TryParse(Console.ReadLine(), out int v1))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите скорость 2 автомобиля: ");
            if (!int.TryParse(Console.ReadLine(), out int v2))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите расстояние между ними: ");
            if (!int.TryParse(Console.ReadLine(), out int s))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите прошедшее время: ");
            if (!int.TryParse(Console.ReadLine(), out int t))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            int result = s + v1 * t + v2 * t;

            Console.WriteLine($"Между автомобилями {result} км");
        }

        private static void Task5()
        {
            Console.Write("Введите A: ");
            if (!int.TryParse(Console.ReadLine(), out int a) || a == 0)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите B: ");
            if (!int.TryParse(Console.ReadLine(), out int b))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            Console.WriteLine($"Уравнение: {a}x + {b} = 0");
            Console.WriteLine("Решение:");
            Console.WriteLine($"x = {Math.Round((double) (-b / a), 4)}");
        }

        private static void Task6()
        {
            Console.Write("Введите коэфициент A1: ");
            if (!int.TryParse(Console.ReadLine(), out int a1))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите коэфициент A2: ");
            if (!int.TryParse(Console.ReadLine(), out int a2))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите коэфициент B1: ");
            if (!int.TryParse(Console.ReadLine(), out int b1))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите коэфициент B2: ");
            if (!int.TryParse(Console.ReadLine(), out int b2))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите коэфициент C1: ");
            if (!int.TryParse(Console.ReadLine(), out int c1))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите коэфициент C2: ");
            if (!int.TryParse(Console.ReadLine(), out int c2))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            int d = a1 * b2 - a2 * b1;
            float x = (float) (c1 * b2 - c2 * b1) / d;
            float y = (float) (a1 * c2 - a2 * c1) / d;

            if (d == 0)
            {
                Console.WriteLine("X: 0");
                Console.WriteLine("Y: 0");
                return;
            }
            
            Console.WriteLine($"X: {Math.Round(x, 4)}");
            Console.WriteLine($"Y: {Math.Round(y, 4)}");

        }
    }
}