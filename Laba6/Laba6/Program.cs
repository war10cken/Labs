using System;
using static System.Math;

namespace Laba6
{
    class Program
    {
        private static int _a;
        private static int _b;
        private static int _c;
        private static float _x;

        private static void Main(string[] args)
        {
            bool isWorking = true;

            while (isWorking)
            {
                Console.Write("Введите A: ");
                if (!int.TryParse(Console.ReadLine(), out int a))
                {
                    Console.WriteLine("Неверный формат!");
                    continue;
                }

                _a = a;
                
                Console.Write("Введите B: ");
                if (!int.TryParse(Console.ReadLine(), out int b))
                {
                    Console.WriteLine("Неверный формат!");
                    continue;
                }

                _b = b;
                
                Console.Write("Введите C: ");
                if (!int.TryParse(Console.ReadLine(), out int c))
                {
                    Console.WriteLine("Неверный формат!");
                    continue;
                }

                _c = c;
                
                Console.Write("Введите X: ");
                if (!float.TryParse(Console.ReadLine(), out float x))
                {
                    Console.WriteLine("Неверный формат!");
                    continue;
                }

                _x = x;

                isWorking = false;
            }
            
            Console.WriteLine("----Task 1----");
            Task1();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 2----");
            Task2();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 3----");
            Task3();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 4----");
            Task4();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 5----");
            Task5();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 6----");
            Task6();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 7----");
            Task7();
            Console.WriteLine("----End----");
            Console.WriteLine();
        }

        private static void Task1()
        {
            int a = _a;
            int b = _b;
            
            Console.WriteLine($"A: {a}\nB: {b}");
            Console.WriteLine();
            
            (a, b) = (b, a);
            Console.WriteLine($"A: {a}\nB: {b}");
        }

        private static void Task2()
        {
            int a = _a;
            int b = _b;
            int c = _c;
            
            Console.WriteLine($"A: {a}\nB: {b}\nC: {c}");
            Console.WriteLine();

            a = b;
            b = c;
            c = _a;

            Console.WriteLine($"A: {a}\nB: {b}\nC: {c}");
        }

        private static void Task3()
        {
            int a = _a;
            int b = _b;
            int c = _c;

            Console.WriteLine($"A: {a}\nB: {b}\nC: {c}");
            Console.WriteLine();
            
            a = c;
            c = b;
            b = _a;
            
            Console.WriteLine($"A: {a}\nB: {b}\nC: {c}");
        }

        private static void Task4()
        {
            float y = 3 * (float) Pow(_x, 6) - 6 * (float) Pow(_x, 2) - 7;
            Console.WriteLine($"Y: {y}");
        }

        private static void Task5()
        {
            float y = 4 * (float) Pow(_x - 3, 6) - 7 * (float) Pow(_x - 3, 3) + 2;
            Console.WriteLine($"Y: {y}");
        }

        private static void Task6()
        {
            //Использование доп локальных переменных не имеет смысла при наличии метода Pow()
            Console.WriteLine($"A^8: {Pow(_a, 8)}");
        }

        private static void Task7()
        {
            //Использование доп локальных переменных не имеет смысла при наличии метода Pow()
            Console.WriteLine($"A^15: {Pow(_a, 15)}");
        }
    }
}