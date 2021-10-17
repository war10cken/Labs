using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Laba22
{
    class Program
    {
        private static int _seed = Environment.TickCount;
        private static ThreadLocal<Random> _random = new(() => new Random(Interlocked.Increment(ref _seed)));

        private static void Main(string[] args)
        {
            Console.WriteLine("----Task 1----");
            Task1(3, 4);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 2----");
            Task2(3, 2);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 3----");
            Task3(2, 6);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 4----");
            Task4(3, 5);
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 5----");
            Task5(3);
            Console.WriteLine();
            Console.WriteLine("----End----");
        }

        private static void Task1(in int m, in int n)
        {
            int[,] array = new int[m, n];
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = _random.Value.Next(0, 9);
                }
            }

            Console.WriteLine("Исходная матрица:");
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            
            Dictionary<int, int> dictionary = new();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dictionary.Add(j, array[i, j]);
                }

                int max = dictionary.Select(d => d.Value).Max();
                int min = dictionary.Select(d => d.Value).Min();
                int maxElementIndex = 0, minElementIndex = 0;

                foreach (var item in dictionary)
                {
                    if (max == item.Value)
                        maxElementIndex = item.Key;

                    if (min == item.Value)
                        minElementIndex = item.Key;
                }

                Console.WriteLine($"В {i + 1} строке максимальный элемент: {max}");
                Console.WriteLine($"В {i + 1} строке минимальный элемент: {min}");
                Console.WriteLine();
                
                (array[i, maxElementIndex], array[i, minElementIndex]) =
                    (array[i, minElementIndex], array[i, maxElementIndex]);
                
                dictionary.Clear();
            }

            Console.WriteLine("Матрица после перестановки максимального и минимального элемента в строках");
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        private static void Task2(in int m, in int n)
        {
            int[,] array = new int[m, n];
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = _random.Value.Next(0, 19);
                }
            }

            Console.WriteLine("Исходная матрица:");
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }

            List<Pair<int, int>> pairs = new();
            List<int> digits = new();

            int min, max, columnMaxNumber, columnMinNumber;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    pairs.Add(new Pair<int, int>(i, array[j, i]));
                }
            }

            min = pairs.Select(d => d.Entity).Min();
            max = pairs.Select(d => d.Entity).Max();

            columnMinNumber = pairs.FirstOrDefault(pair => pair.Entity == min).Id;
            columnMaxNumber = pairs.FirstOrDefault(pair => pair.Entity == max).Id;

            if (columnMaxNumber == columnMinNumber)
            {
                Console.WriteLine("Максимальный и минимальный элементы находятся в одном столбце.");
                return;
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    digits.Add(array[j, i - 1]);
                }

                for (int j = 0; j < m; j++)
                {
                    array[j, i - 1] = array[j, i];
                }

                for (int j = 0; j < m; j++)
                {
                    array[j, i] = digits[j];
                }
            }

            Console.WriteLine("Матрица после перестановки столбцов");
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        private static void Task3(in int m, in int n)
        {
            if (m % 2 != 0 || n % 2 != 0)
            {
                Console.WriteLine("M и N должны быть чётными");
                return;
            }
            
            int[,] array = new int[m, n];
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = _random.Value.Next(0, 9);
                }
            }

            Console.WriteLine("Исходная матрица:");
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }

            List<int> firstQuarter = new();
            List<int> fouthQuarter = new();

            for (int i = 0; i < m / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    firstQuarter.Add(array[i, j]);
                }
            }

            for (int i = m / 2; i < m; i++)
            {
                for (int j = n / 2; j < n; j++)
                {
                    fouthQuarter.Add(array[i, j]);
                }
            }
            
            for (int i = 0, k = 0; i < m / 2; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    array[i, j] = fouthQuarter[k++];
                }
            }

            for (int i = m / 2, k = 0; i < m; i++)
            {
                for (int j = n / 2; j < n; j++)
                {
                    array[i, j] = firstQuarter[k++];
                }
            }

            Console.WriteLine("Матрица после перестановки 1 и 4 четвертей");
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        private static void Task4(in int m, in int n)
        {
            int[,] array = new int[m, n];
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = _random.Value.Next(0, 9);
                }
            }

            Console.WriteLine("Исходная матрица:");
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }

            List<Pair<int, int>> pairs = new();

            for (int i = 0; i < m; i++)
            {
                pairs.Add(new Pair<int, int>(i, array[i, 0]));
            }

            List<int> values = pairs.Select(pair => pair.Entity).ToList();
            
            values = values.OrderBy(d => d).ToList();
            List<int> indexes = new();

            pairs = pairs.OrderBy(p => p.Entity).ToList();
            
            for (int i = 0; i < values.Count; i++)
            {
                if (values[i] == pairs[i].Entity)
                {
                    indexes.Add(pairs[i].Id);
                }
            }

            int[,] tempArray = new int[m, n];
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tempArray[i, j] = array[indexes[i], j];
                }
            }

            array = tempArray;

            Console.WriteLine("Матрица после перестановки строк");
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }
        }

        private static void Task5(in int m)
        {
            int[,] array = new int[m, m];
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = _random.Value.Next(0, 9);
                }
            }

            Console.WriteLine("Исходная матрица:");
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }

                Console.WriteLine();
            }

            List<int> sums = new();
            int sum = 0;

            if (m == 2)
            {
                sums.Add(array[0, m - 1]);
                sums.Add(array[m - 1, 0]);

                Console.WriteLine("Суммы диагоналей параллельных главной");

                foreach (int item in sums)
                {
                    Console.Write($"{item} | ");
                }
                
                return;
            }
            
            int elementsInDiagonal = m - 1;
            
            for (int i = 0, k = 1; i <= elementsInDiagonal;)
            {
                if (i == elementsInDiagonal)
                {
                    int temp = i;
                    i = 0;
                    k = k - temp + 1;
                    elementsInDiagonal -= 1;
                    
                    sums.Add(sum);
                    sum = 0;
                    
                    if(elementsInDiagonal == 0)
                        break;

                    continue;
                }
                
                for (int j = k; j <= k; j++)
                {
                    sum += array[i, j];
                }
                
                i++;
                k++;
            }

            elementsInDiagonal = m - 1;
            
            for (int i = 1, k = 0; k <= elementsInDiagonal;)
            {
                if (k == elementsInDiagonal)
                {
                    int temp = k;
                    k = 0;
                    i = i - temp + 1;
                    elementsInDiagonal -= 1;
                    
                    sums.Add(sum);
                    sum = 0;
                    
                    if(elementsInDiagonal == 0)
                        break;

                    continue;
                }
                
                for (int j = k; j <= k; j++)
                {
                    sum += array[i, j];
                }
                
                i++;
                k++;
            }

            Console.WriteLine("Суммы диагоналей параллельных главной диагонали, которые находятся выше главной диагонали");

            foreach (int item in sums.Take(m - 1))
            {
                Console.Write($"{item} | ");
            }

            Console.WriteLine();
            
            Console.WriteLine("Суммы диагоналей параллельных главной диагонали, которые находятся ниже главной диагонали");
            
            foreach (int item in sums.Skip(m - 1))
            {
                Console.Write($"{item} | ");
            }
        }
    }
}