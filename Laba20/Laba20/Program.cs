using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualBasic;

namespace Laba20
{
    internal class Program
    {
        private static int _seed = Environment.TickCount;
        private static ThreadLocal<Random> _random = new(() => new Random(Interlocked.Increment(ref _seed)));

        private static void Main(string[] args)
        {
            Console.WriteLine("----Task 1----");
            Task1(25);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 2----");
            Task2(25, 2);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 3----");
            Task3(25, _random.Value.Next(0, 15));
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 4----");
            Task4(25);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 5----");
            Task5(25);
            Console.WriteLine();
            Console.WriteLine("----End----");
        }

        private static void PrintList<T>(List<T> list)
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
                digits.Add(_random.Value.Next(0, 15));
            }

            Console.WriteLine("Исходный массив");
            PrintList(digits);

            Console.WriteLine("\n");

            int count = 0, current, next, previous;

            List<Pair<int, int>> pairs = new();
            
            for (int i = 1; i < digits.Count; i++)
            {
                current = digits[i];
                previous = digits[i - 1];

                if (current == previous)
                {
                    pairs.Add(new Pair<int, int>(current, count += 2));
                }

                if (i + 1 < digits.Count)
                {
                    next = digits[i + 1];

                    if (current == next && current == previous)
                    {
                        var pair = pairs.Find(p => p.Key == current);
                        
                        var entityPropertyInfo = pair.GetType().GetProperty(nameof(pair.Entity));
                        entityPropertyInfo?.SetValue(pair, ++count);
                        
                        int index = pairs.FindIndex(p => p.Key == pair.Key);
                        
                        pairs.RemoveAt(index);
                        pairs.Insert(index, pair);
                        count = 0;
                    }
                    
                    if (current != next && current != previous)
                    {
                        pairs.Add(new Pair<int, int>(current, ++count));
                    }

                    count = 0;
                    continue;
                }
                
                pairs.Add(new Pair<int, int>(digits[i], 1));
            }

            if (digits[0] != digits[1])
            {
                pairs.Insert(0, new Pair<int, int>(digits[0], 1));
            }
            
            List<int> entities = pairs.Select(p => p.Key).Select(key => pairs.Find(p => p.Key == key))
                                      .Select(pair => pair?.Entity ?? default).ToList();
            
            
            if (entities.All(entity => entity == 1))
            {
                Console.WriteLine($"Числа: {string.Join(' ', pairs.Select(p => p.Key))}\n" +
                                  $"Кол-ов повторений: {string.Join(' ', entities)}");
                return;
            }

            Console.WriteLine($"Числа: {string.Join(' ', pairs.Select(p => p.Key))}\n" +
                              $"Кол-ов повторений: {string.Join(' ', pairs.Select(p => p.Entity))}");

        }

        private static void Task2(in int n, int l)
        {
            if (l < 0)
            {
                Console.WriteLine("L < 0");
                return;
            }

            List<int> digits = new();

            for (int i = 0; i < n; i++)
            {
                digits.Add(_random.Value.Next(0, 20));
            }

            Console.WriteLine("Исходный массив");
            PrintList(digits);

            Console.WriteLine("\n");

            List<int> duplicateIndexes = digits.Select((d, i) => new { Index = i, Digit = d })
            .GroupBy(d => d.Digit)
            .Where(d => d.Count() > l)
            .SelectMany(d => d, (d, x) => x.Index).ToList();

            Console.WriteLine("Индексы дубликатов");

            PrintList(duplicateIndexes);

            Console.WriteLine("\n");

            foreach (int index in duplicateIndexes)
            {
                digits[index] = 0;
            }

            Console.WriteLine("Массив после изменения на 0");

            PrintList(digits);

            Console.WriteLine("\n");
        }

        private static void Task3(in int n, in int k)
        {
            if (k < 0)
            {
                Console.WriteLine("k не может быть < 0");
                return;
            }

            List<int> digits = new();
            List<Pair<int, int>> pairs = new();

            for (int i = 0; i < n; i++)
            {
                digits.Add(_random.Value.Next(-15, 15));
            }

            Console.WriteLine($"Число k: {k}");

            Console.WriteLine("Исходный массив");
            PrintList(digits);

            Console.WriteLine("\n");

            for (int i = 0; i < digits.Count; i++)
            {
                if (i + 1 < digits.Count)
                {
                    if (digits[i] == digits[i + 1])
                    {
                        pairs.Add(new Pair<int, int>(i, digits[i]));
                        pairs.Add(new Pair<int, int>(i + 1, digits[i + 1]));
                    }
                }
            }

            pairs.Reverse();

            for (int i = 0; i < pairs.Count; i++)
            {
                if (i + 1 < pairs.Count)
                {
                    if (pairs[i].Entity == pairs[i + 1].Entity)
                    {
                        digits[pairs[i].Key] = k;
                        digits[pairs[i + 1].Key] = k;
                    }
                }
            }

            Console.WriteLine("Массив с заменёнными числами на число k");
            PrintList(digits);
        }

        private static void Task4(in int n)
        {
            List<Point> a = new();

            for (int i = 0; i < n; i++)
            {
                a.Add(new Point(_random.Value.Next(-10, 10), _random.Value.Next(-10, 10)));
            }

            for (int i = 0; i < a.Count(); i++)
            {
                Console.WriteLine($"Точка {i + 1}");
                Console.WriteLine($"Y: {a[i].Y}");
                Console.WriteLine($"X: {a[i].X}");                
            }
            
            a = a.Where(point => point.X < 0)
                .Where(point => point.Y > 0)
                .OrderBy(point => point.X)
                .ThenBy(point => point.Y).ToList();

            if (a.Any())
            {
                Point farPoint = a.LastOrDefault();

                Console.WriteLine($"X: {farPoint.X}");
                Console.WriteLine($"Y: {farPoint.Y}");

                return;
            }

            Console.WriteLine("X: 0");
            Console.WriteLine("Y: 0");
        }

        private static void Task5(in int n)
        {
            if (n < 2)
            {
                Console.WriteLine("n не может быть < 2");
                return;
            }

            List<Point> a = new();
            List<Point> trianglePoints = new();

            for (int i = 0; i < n; i++)
            {
                a.Add(new Point(_random.Value.Next(-15, 15), _random.Value.Next(-15, 15)));
            }

            for (int i = 0; i < 3; i++)
            {
                trianglePoints.Add(a[_random.Value.Next(0, a.Count)]);
            }

            float CalculateTriangleSide(int firstCoordinateIndex, int secondCoordinateIndex)
            {
                return (float)Math.Sqrt(Math.Pow(trianglePoints[firstCoordinateIndex].X + trianglePoints[secondCoordinateIndex].X, 2) +
                Math.Pow(trianglePoints[firstCoordinateIndex].Y + trianglePoints[secondCoordinateIndex].Y, 2));
            }

            float ab = CalculateTriangleSide(0, 1);

            float ac = CalculateTriangleSide(0, 2);

            float bc = CalculateTriangleSide(1, 2);

            float P = ab + ac + bc;

            Console.WriteLine($"Периметр равен: {P}");

            Console.WriteLine();

            for (int i = 0; i < trianglePoints.Count; i++)
            {
                Console.WriteLine($"Точка {i + 1}");
                Console.WriteLine($"X: {trianglePoints[i].X}");
                Console.WriteLine($"Y: {trianglePoints[i].Y}");
            }
        }
    }
}
