using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Laba24
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("----Task 1----");
            Console.WriteLine();
            Task1();
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 2----");
            Console.WriteLine();
            Task2();
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 3----");
            Console.WriteLine();
            Task3();
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 4----");
            Console.WriteLine();
            Task4();
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 5----");
            Console.WriteLine();
            Task5();
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 6----");
            Console.WriteLine();
            Task6();
            Console.WriteLine();
            Console.WriteLine("----End----");
            Console.WriteLine();
            Console.WriteLine("----Task 7----");
            Console.WriteLine();
            Task7();
            Console.WriteLine();
            Console.WriteLine("----End----");
        }

        private static void Task1()
        {
            string str =
                "Коллайдер — ускоритель частиц на встречных пучках, предназначенный для изучения продуктов их соударений";

            Console.WriteLine($"Строка: {str}");
            
            int countOfWord = Regex.Matches(str, "([а-яА-Я]+)").Count;

            Console.WriteLine($"Количество слов в строке: {countOfWord}");
        }

        private static void Task2()
        {
            string str =
                "Коллайдер — ускоритель частиц на встречных пучках, предназначенный для изучения продуктов их соударений";

            Console.WriteLine($"Строка: {str}");
            
            var matches = Regex.Matches(str, "([а-яА-Я]+)").ToList();

            int length = matches.Select(match => match.Value.Length).ToList().Min();

            Console.WriteLine($"Минимальная длина слова: {length}");
        }

        private static void Task3()
        {
            string str = "ПЫВП УРЕКЕ ЫААРВР ВА Р   РРАПР ЧМЧСМФЫК  ";

            Console.WriteLine($"Исходная строка: {str}");
            
            var matches = Regex.Matches(str, "([а-яА-Я]+)").ToList();

            char firstChar;

            foreach (var match in matches)
            {
                firstChar = match.Value[0];

                string value = new(match.Value.Skip(1).ToArray());
                
                for (int j = 0; j < match.Value.Skip(1).Count(); j++)
                {
                    if (firstChar == match.Value.Skip(1).ToList()[j])
                    {
                        value = value.Replace(firstChar, '.');
                    }
                }

                value = value.Insert(0, match.Value[0].ToString());

                str = str.Replace(match.Value, value);
            }

            Console.WriteLine($"Строка после замены: {str}");
        }

        private static void Task4()
        {
            string str =
                "Коллайдер — ускоритель частиц на встречных пучках, предназначенный для изучения продуктов их соударений";

            Console.WriteLine($"Предложение: {str}");
            
            int countOfVowels = Regex.Matches(str, "[ауоыиэяюёе]").Count;

            Console.WriteLine($"Количество гласных в предложении: {countOfVowels}");
        }

        private static void Task5()
        {
            string path = @"C:\Users\User1\Desktop\text.txt";
            string fileName = "";

            Console.WriteLine($"Путь: {path}");
            
            var matches = Regex.Matches(path, @"[a-zA-Z0-9_-а-яА-Я]+[.][a-zA-Z0-9_а-яА-Я]+");

            foreach (Match match in matches)
            {
                fileName = new string(match.Value.TakeWhile(ch => ch != '.').ToArray());
            }

            Console.WriteLine($"Название файла: {fileName}");
        }

        private static void Task6()
        {
            string path = @"C:\Users\User1\Desktop\text.txt";
            string catalogName = "";
            
            Console.WriteLine($"Путь: {path}");

            var matches = Regex.Matches(path,
                                        @"[a-zA-Z0-9_-а-яА-Я]+.[a-zA-Z0-9_-а-яА-Я]+[.][a-zA-Z0-9_а-яА-Я]+");

            foreach (Match match in matches)
            {
                if (!match.Value.Contains('\\'))
                {
                    catalogName = @"\";
                    break;
                }
                
                catalogName = new string(match.Value.TakeWhile(ch => ch != '\\').ToArray());
            }

            Console.WriteLine($"Наименование каталога: {catalogName}");
        }

        private static void Task7()
        {
            string str =
                "Коллайдер — ускоритель частиц на встречных пучках, предназначенный для изучения продуктов их соударений";

            Console.WriteLine($"Исходное предложение: {str}");
            
            var matches = Regex.Matches(str, "[а-яА-Я]+");

            foreach (Match match in matches)
            {
                string value = match.Value;
                string oddLetters = "";
                string evenLetters = "";

                for (int i = 1; i < value.Length + 1; i++)
                {
                    if (i % 2 == 0)
                    {
                        evenLetters = evenLetters.Insert(0, value[i - 1].ToString());
                        continue;
                    }

                    oddLetters = oddLetters.Insert(0, value[i - 1].ToString());
                }

                str = str.Replace(match.Value,
                                  string.Join("", new string(evenLetters.Reverse().ToArray()), oddLetters));
            }

            Console.WriteLine($"Предложение после шифровки: {str}");
        }
    }
}