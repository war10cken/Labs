using System;

namespace Laba9
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
            Console.Write("Введите количество секунд: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n < 0)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            int seconds = n - n / 60 * 60;

            if (n < 60)
            {
                Console.WriteLine("Количество секунд, прошедших с начала последней минуты: 0");
                return;
            }
            
            Console.WriteLine($"Количество секунд, прошедших с начала последней минуты: {seconds}");

        }

        private static void Task2()
        {
            Console.Write("Введите порядковый номер дня в году от 1 до 365 K: ");
            if (!int.TryParse(Console.ReadLine(), out int k) || k is < 1 or > 365)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            Console.WriteLine($"Номер дня недели {k % 7}");
        }

        private static void Task3()
        {
            Console.Write("Введите порядковый номер дня в году от 1 до 365 K: ");
            if (!int.TryParse(Console.ReadLine(), out int k) || k is < 1 or > 365)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите порядковый номер дня в неделе от 1 до 7 N: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n is < 1 or > 7)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            Console.WriteLine($"День недели: {(n + k - 1) % 7}");
        }

        private static void Task4()
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

            int n = (a / c) * (b / c);
            int k = a * b - n * c * c;

            Console.WriteLine($"Количество квадратов: {k}");
        }

        private static void Task5()
        {
            Console.Write("Введите номер года: ");
            if (!int.TryParse(Console.ReadLine(), out int year) || year < 0)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            int cent = year / 100;
            year %= 100;

            if (year > 0)
            {
                cent++;
            }

            Console.WriteLine($"Номер столетия: {cent}");
        }
    }
}