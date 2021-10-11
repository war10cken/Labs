using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Laba21
{
    class Program
    {
        private static int _seed = Environment.TickCount;
        private static ThreadLocal<Random> _random = new(() => new Random(Interlocked.Increment(ref _seed)));

        private static void Main(string[] args)
        {
            Console.WriteLine("----Task 1----");
            Task1(5);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 2----");
            Task2(5, 4, 3);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 3----");
            Task3(3, 2);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 4----");
            Task4(3, 2);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 5----");
            Task5(3, 2);
            Console.WriteLine();
            Console.WriteLine("----End----");
        }
        
        private static void Task1(in int m)
        {
            if (m % 2 == 0)
            {
                Console.WriteLine("M должна быть нечётной.");
                return;
            }

            int[,] array = new int[m, m];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = _random.Value.Next(0, 9);
                }
            }
            
            Console.WriteLine("Матрица:");

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }
            
            for (int i = 0; i < m; i++)
            {
                if(m - i <= 2 || m - i - 1 <= i + 1)
                    break;
                
                Console.WriteLine("\n");

                Console.WriteLine($"Первый столбик матрицы {m - i - i}x{m - i - i}");
                for (int j = i; j < m - i; j++)
                {
                    Console.Write($"{array[j, i]} | ");
                }

                Console.WriteLine("\n");

                Console.WriteLine($"Последняя строчка матрицы {m - i - i}x{m - i - i}");
                for (int j = i, k = m - i - 1; j < m - i; j++)
                {
                    Console.Write($"{array[k, j]} | ");
                }
                
                Console.WriteLine("\n");

                Console.WriteLine($"Последний столбик в обратном порядке матрицы {m - i - i}x{m - i - i}");
                for (int j = m - i - 1, k = m - i - 1; j >= i; j--)
                {
                    Console.Write($"{array[j, k]} | ");
                }
                
                Console.WriteLine("\n");

                Console.WriteLine($"Первая строчка в обратном порядке матрицы {m - i - i}x{m - i - i}");
                for (int j = m - i - 1; j >= i; j--)
                {
                    Console.Write($"{array[i, j]} | ");
                }
            }
            
            Console.WriteLine("\n");

            Console.WriteLine($"Центральный элемент матрицы {m}x{m}");
            Console.WriteLine(array[m / 2, m / 2]);
        }

        private static void Task2(in int m, in int n, in int k)
        {
            if (k < 1)
            {
                Console.WriteLine("k не может быть меньше 1");
                return;
            }

            if (k > m)
            {
                Console.WriteLine("k не может быть больше m");
                return;
            }

            int[,] array = new int[m, n];
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[j, i] = _random.Value.Next(-10, 10);
                }
            }

            Console.WriteLine("Матрица:");
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{array[j, i]} ");
                }
            
                Console.WriteLine();
            }

            int sum = 0, multiply = 1;

            for (int i = 0; i < n; i++)
            {
                sum += array[k - 1, i];
                multiply *= array[k - 1, i];
            }

            Console.WriteLine($"Сумма {k} строки равна: {sum}");
            Console.WriteLine($"Произведение {k} строки равно: {multiply}");
        }

        private static void Task3(in int m, in int n)
        {
            int[,] array = new int[m, n];
            Dictionary<int, int> dictionary = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[j, i] = _random.Value.Next(-10, 10);
                }
            }

            int multiply = 1;
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    multiply *= array[j, i];
                }
                
                dictionary.Add(i, multiply);
                multiply = 1;
            }

            var value = dictionary.OrderBy(d => d.Value).FirstOrDefault();

            Console.WriteLine($"Номер столбца с наименьшим произведением: {value.Key}");
            Console.WriteLine($"Произведение равно: {value.Value}");
        }

        private static void Task4(in int m, in int n)
        {
            int[,] array = new int[m, n];
            Dictionary<int, int> dictionary = new();
            List<int> elemnts = new();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[j, i] = _random.Value.Next(-10, 10);
                }
            }

            int sum = 0, average;
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sum += array[j, i];
                }

                average = sum / m;

                Console.WriteLine($"Среднее арифметическое {i + 1} столбца: {average}");
                Console.WriteLine();
                
                for (int j = 0; j < m; j++)
                {
                    if (array[j, i] > average)
                    {
                        dictionary.TryGetValue(i, out int count);
                        dictionary[i] = ++count;
                    }
                }
                
                sum = 0;
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            
            foreach (var item in dictionary)
            {
                Console.WriteLine($"Номер столбца: {item.Key + 1}");
                Console.WriteLine($"Количество элементов: {item.Value}");
                Console.WriteLine();
            }
        }

        private static void Task5(in int m, in int n)
        {
            int[,] array = new int[m, n];
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[j, i] = _random.Value.Next(-10, 10);
                }
            }

            Console.WriteLine("Матрица");
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }
            
            int count = 0;
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (array[j, i] % 2 != 0)
                    {
                        count++;
                    }
                }
                
                if (count == m)
                {
                    Console.WriteLine($"Номер столбца, где все числа нечётные {i}");
                    break;
                }
                
                count = 0;
            }

            Console.WriteLine();
            
            if (count != m)
            {
                Console.WriteLine("0");
            }
        }
    }
}