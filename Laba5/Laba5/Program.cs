using System;

namespace Laba5
{
    class Program
    {
        private static Point _a;
        private static Point _b;
        private static Point _c;

        private static void Main(string[] args)
        {
            bool isWorking = true;

            while (isWorking)
            {
                Console.Write("Введите координату X точки A: ");
                if (!float.TryParse(Console.ReadLine(), out float aX))
                {
                    Console.WriteLine("Неверный формат!");
                    continue;
                }
                
                Console.Write("Введите координату Y точки A: ");
                if (!float.TryParse(Console.ReadLine(), out float aY))
                {
                    Console.WriteLine("Неверный формат!");
                    continue;
                }

                _a = new Point(aX, aY);
                
                Console.Write("Введите координату X точки B: ");
                if (!float.TryParse(Console.ReadLine(), out float bX))
                {
                    Console.WriteLine("Неверный формат!");
                    continue;
                }
                
                Console.Write("Введите координату Y точки B: ");
                if (!float.TryParse(Console.ReadLine(), out float bY))
                {
                    Console.WriteLine("Неверный формат!");
                    continue;
                }

                _b = new Point(bX, bY);
                
                Console.Write("Введите координату X точки C: ");
                if (!float.TryParse(Console.ReadLine(), out float cX))
                {
                    Console.WriteLine("Неверный формат!");
                    continue;
                }
                
                Console.Write("Введите координату Y точки C: ");
                if (!float.TryParse(Console.ReadLine(), out float cY))
                {
                    Console.WriteLine("Неверный формат!");
                    continue;
                }

                _c = new Point(cX, cY);

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
        }

        private static float CalculateDistance(Point a, Point b)
        {
            return (float) Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }
        
        private static float CalculateDistanceWithoutY(Point a, Point b)
        {
            return (float) Math.Sqrt(Math.Pow(b.X - a.X, 2));
        }
        
        private static void Task1()
        {
            float ab = CalculateDistance(_a, _b);
            Console.WriteLine($"Расстояние между A и B: {ab}");
        }

        private static void Task2()
        {
            float ac = CalculateDistanceWithoutY(_a, _c);
            float bc = CalculateDistanceWithoutY(_b, _c);
            float sum = ac + bc;

            Console.WriteLine($"Расстояние между A и C: {ac}");
            Console.WriteLine($"Расстояние между B и C: {bc}");
            Console.WriteLine($"Сумма AC и BC равна: {sum}");
        }

        private static void Task3()
        {
            if (_c.X > _a.X && _c.X < _b.X)
            {
                float ac = CalculateDistanceWithoutY(_a, _c);
                float bc = CalculateDistanceWithoutY(_b, _c);
                float multiply = ac * bc;
            
                Console.WriteLine($"Произведение отрезков AC и BC равно: {multiply}");
                return;
            }

            Console.WriteLine("C не находиться между A и B!");
        }

        private static void Task4()
        {
            float p = 2 * (Math.Abs(_a.X - _b.X) + Math.Abs(_a.Y - _b.Y));
            float s = Math.Abs(_a.X - _b.X) * Math.Abs(_a.Y - _b.Y);

            Console.WriteLine($"Периметр равен: {p}");
            Console.WriteLine($"Площадь равна: {s}");
        }

        private static void Task5()
        {
            float ab = CalculateDistance(_a, _b);
            float bc = CalculateDistance(_b, _c);
            float ca = CalculateDistance(_c, _a);
            float P = ab + bc + ca;
            float p = P / 2;
            float S = (float) Math.Sqrt(p * (p - ab) * (p - bc) * (p - ca));
            
            Console.WriteLine($"Периметр равен: {P}");
            Console.WriteLine($"Площадь равна: {S}");
        }
    }
}