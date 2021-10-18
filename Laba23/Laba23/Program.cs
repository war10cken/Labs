using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Laba23
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
        }

        private static void Task1()
        {
            byte[] codeOfSymbol = Encoding.ASCII.GetBytes("C");
            
            codeOfSymbol[0] += 1;
            string previousSymbol = Encoding.ASCII.GetString(codeOfSymbol);
            
            codeOfSymbol[0] -= 2;
            string nextSymbol = Encoding.ASCII.GetString(codeOfSymbol);

            Console.WriteLine($"Символ, который предшествует символу \'C\' - {previousSymbol} ");
            Console.WriteLine($"Символ, который следует после символа \'C\' - {nextSymbol} ");
        }

        private static void Task2()
        {
            string str = "qwe re dfh tyt  erye";
            string newStr = "";
            char current, next;

            Console.WriteLine($"Исходная строка: {str}");
            
            for (int i = 0; i < str.Length; i++)
            {
                current = str[i];

                if (i + 1 < str.Length)
                {
                    next = str[i + 1];

                    if (current == ' ' && next != current)
                    {
                        int index = str.ToList().FindIndex(c => c == current);

                        if (index == 0)
                        {
                            newStr = newStr.Insert(newStr.Length, str[index + 1].ToString());
                            continue;
                        }

                        if (index == str.Length - 1)
                        {
                            newStr = newStr.Insert(newStr.Length, str[index - 1].ToString());
                        }

                        newStr = newStr.Insert(newStr.Length, str[index - 1].ToString());
                        newStr = newStr.Insert(newStr.Length, str[index + 1].ToString());

                        str = new string(str.Skip(index + 1).ToArray());
                    }
                }
            }

            Console.WriteLine($"Символы, между которыми стоит пробел: {string.Join(" ", newStr)}");
        }

        private static void Task3()
        {
            string str = "qweRasSzxV";

            Console.WriteLine($"Строка: {str}");
            
            int countOfUpperCaseLetter = str.Count(char.IsUpper);

            Console.WriteLine($"Количество прописных латинских букв: {countOfUpperCaseLetter}");
        }

        private static void Task4()
        {
            char ch = 'C';
            string str = "qweCasfcasgfhC";

            Console.WriteLine($"Исходная строка: {str}");
            
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ch)
                {
                    str = str.Insert(i, ch.ToString());
                    i++;
                }
            }

            Console.WriteLine($"Строка после удвоения символа \'C\': {str}");
        }

        private static void Task5()
        {
            string s = "qwefgttqweyjuycqvqwe";
            string s0 = "qwe";

            int occurrence = Regex.Matches(s, s0).Count;

            Console.WriteLine($"Количество вхождений: {occurrence}");
        }
    }
}