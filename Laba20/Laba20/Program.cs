﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
            Task3(25, _random.Value.Next(-15, 15));
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
            List<int> c = new();
            Dictionary<int, int> dictionary = new();

            for (int i = 0; i < n; i++)
            {
                digits.Add(_random.Value.Next(0, 15));
            }

            Console.WriteLine("Исходный массив");
            PrintList(digits);

            Console.WriteLine("\n");

            int count, current, next, previous;

            for (int i = 1; i < digits.Count; i++)
            {
                current = digits[i];
                previous = digits[i - 1];
                dictionary.TryGetValue(current, out count);

                if (i + 1 < digits.Count)
                {
                    next = digits[i + 1];

                    if (current == previous)
                    {
                        if (c.Count(d => d == current) == 1)
                        {
                            dictionary[current] = ++count;
                            continue;
                        }

                        c.Add(current);
                        dictionary[current] = ++count;
                    }

                    if (current == next && current != previous)
                    {
                        count = 0;
                        c.Add(current);
                        dictionary[current] = ++count;
                    }
                }
            }

            List<int> b = dictionary.Select(item => item.Value).ToList();

            if (c.Any() && b.Any())
            {
                Console.WriteLine("Значения элементов, образующих серию");
                PrintList(c);

                Console.WriteLine("\n");

                Console.WriteLine("Длины серий");

                PrintList(b);

                return;
            }

            Console.WriteLine("Серий чисел не оказалось в массиве");
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
            List<Pair<int>> pairs = new();

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
                        pairs.Add(new Pair<int>(i, digits[i]));
                        pairs.Add(new Pair<int>(i + 1, digits[i + 1]));
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
                        digits[pairs[i].Index] = k;
                        digits[pairs[i + 1].Index] = k;
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
                Console.WriteLine();
            }
        }
    }
}