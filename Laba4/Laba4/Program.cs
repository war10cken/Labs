using System;

namespace Laba4
{
    class Program
    {
        private static void Main(string[] args)
        {
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine("Дробные числа вводить через запятую");
                Console.Write("Введите a: ");
                if (!float.TryParse(Console.ReadLine(), out float a))
                {
                    Console.WriteLine("Неверный формат! Попробуйте ещё раз");
                    continue;
                }

                Console.Write("Введите b: ");
                if (!float.TryParse(Console.ReadLine(), out float b))
                {
                    Console.WriteLine("Неверный формат! Попробуйте ещё раз");
                    continue;
                }

                Console.Write("Введите d: ");
                if (!float.TryParse(Console.ReadLine(), out float d))
                {
                    Console.WriteLine("Неверный формат! Попробуйте ещё раз");
                    continue;
                }
                
                Console.WriteLine("----Task 1----");
                Task1(a, b);
                Console.WriteLine("----End----");
                Console.WriteLine();
                Console.WriteLine("----Task 2----");
                Task2(d);
                Console.WriteLine("----End----");
                Console.WriteLine();
                Console.WriteLine("----Task 3----");
                Task3(a, b);
                Console.WriteLine("----End----");
                Console.WriteLine();
                Console.WriteLine("----Task 4----");
                Task4(a, b);
                Console.WriteLine("----End----");
                Console.WriteLine();
                Console.WriteLine("----Task 5----");
                Task5(a, b);

                isWorking = false;
            }
           
        }

        private static void Task1(in float a, in float b)
        {
            float s = a * b;
            float p = 2 * (a + b);

            Console.WriteLine($"Периметр равен: {s}");
            Console.WriteLine($"Площадь равна: {p}");
        }

        private static void Task2(in float d)
        {
            float l = (float) Math.PI * d;

            Console.WriteLine($"Длина окружности: {l}");
        }

        private static void Task3(in float a, in float b)
        {
            float simpleAverage = (a + b) / 2;

            Console.WriteLine($"Среднее арифметическое равно: {simpleAverage}");
        }

        private static void Task4(in float a, in float b)
        {
            if (a == 0 || b == 0)
            {
                Console.WriteLine("Вы ввели 0!");
                return;
            }

            float sum = (float) (Math.Pow(a, 2) + Math.Pow(b, 2));
            float differenceAB = (float) (Math.Pow(a, 2) - Math.Pow(b, 2));
            float differenceBA = (float) (Math.Pow(b, 2) - Math.Pow(a, 2));
            float multiply = (float) (Math.Pow(a, 2) * Math.Pow(b, 2));
            float devideAB = (float) (Math.Pow(a, 2) / Math.Pow(b, 2));
            float devideBA = (float) (Math.Pow(b, 2) / Math.Pow(a, 2));

            Console.WriteLine($"Сумма: {sum}");
            Console.WriteLine($"Разность a - b: {differenceAB}");
            Console.WriteLine($"Разность b - a: {differenceBA}");
            Console.WriteLine($"Умножение: {multiply}");
            Console.WriteLine($"Деление a / b: {devideAB}");
            Console.WriteLine($"Деление b / a: {devideBA}");
        }

        private static void Task5(in float a, in float b)
        {
            if (a == 0 || b == 0)
            {
                Console.WriteLine("Вы ввели 0!");
                return;
            }

            float sum = Math.Abs(a) + Math.Abs(b);
            float differenceAB = Math.Abs(a) - Math.Abs(b);
            float differenceBA = Math.Abs(b) - Math.Abs(a);
            float multiply = Math.Abs(a) * Math.Abs(b);
            float devideAB = Math.Abs(a) / Math.Abs(b);
            float devideBA = Math.Abs(b) / Math.Abs(a);

            Console.WriteLine($"Сумма: {sum}");
            Console.WriteLine($"Разность a - b: {differenceAB}");
            Console.WriteLine($"Разность b - a: {differenceBA}");
            Console.WriteLine($"Умножение: {multiply}");
            Console.WriteLine($"Деление a / b: {devideAB}");
            Console.WriteLine($"Деление b / a: {devideBA}");
        }
    }
}