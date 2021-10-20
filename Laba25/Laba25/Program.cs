using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static ImprovedRandom.ImprovedRandom;

namespace Laba25
{
    class Program
    {
        private static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            Console.WriteLine("----Task 1----");
            Console.WriteLine();
            await Task1();
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 2----");
            Console.WriteLine();
            await Task2("file.txt", GetRandomNumber(1, 10), GetRandomNumber(1, 10));
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 3----");
            Console.WriteLine();
            await Task3();
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 4----");
            Console.WriteLine();
            await Task4();
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 5----");
            Console.WriteLine();
            await Task5();
            Console.WriteLine();
            Console.WriteLine("----End----");
        }
        
        private static async Task Task1()
        {
            string path = "symbols.txt";
            
            string text = await File.ReadAllTextAsync(path);

            Console.WriteLine($"Исходный текст: \n{text}");

            text = new string(text.SkipWhile(ch => ch != ' ').ToArray()
                                  .Skip(1).ToArray());

            Console.WriteLine($"Изменённый текст: \n{text}");
            
            await File.WriteAllTextAsync(path, text);
        }

        private static async Task Task2(string fileName, int n, int k)
        {
            string str = "";

            for (int i = 0; i < n; i++)
            {
                str = str.Insert(str.Length, new string('*', k));
                str = str.Insert(str.Length, "\n");
            }

            Console.WriteLine($"Текст файла: \n{str}");
            
            await File.WriteAllTextAsync(fileName, str);
        }

        private static async Task Task3()
        {
            string filePath1 = "file1.txt";
            string filePath2 = "file2.txt";

            string file1Text = await File.ReadAllTextAsync(filePath1);
            string file2Text = await File.ReadAllTextAsync(filePath2);

            Console.WriteLine($"Содержимое файла 1: \n{file1Text}");
            Console.WriteLine();
            
            Console.WriteLine($"Содержимое файла 2: \n{file2Text}");
            Console.WriteLine();
            
            file1Text = file1Text.Insert(0, file2Text);

            await File.WriteAllTextAsync(filePath1, file1Text);

            Console.WriteLine($"Изменённый текст файла 1: \n{file1Text}");
        }

        private static async Task Task4()
        {
            string path = "text.txt";

            string text = await File.ReadAllTextAsync(path);

            Console.WriteLine($"Исходный текст: \n{text}");

            var matches = Regex.Matches(text, @"\s{2,}");

            foreach (Match match in matches)
            {
                text = text.Replace(match.Value, " ");
            }

            Console.WriteLine();
            
            Console.WriteLine($"Изменённый текст: \n{text}");

            await File.WriteAllTextAsync(path, text);

        }

        private static async Task Task5()
        {
            string path = "diftext.txt";

            string text = await File.ReadAllTextAsync(path);

            Console.WriteLine($"Текст: \n{text}");
            
            int paragraphCount = text.Count(ch => ch == '\n');

            Console.WriteLine();
            Console.WriteLine($"Количество абзацев: {paragraphCount}");
        }
    }
}