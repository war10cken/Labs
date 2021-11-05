using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba12
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
            Dictionary<int, string> days = new Dictionary<int, string>
            {
                {1, "первое"},
                {2, "второе"},
                {3, "третье"},
                {4, "четвёртое"},
                {5, "пятое"},
                {6, "шестое"},
                {7, "седьмое"},
                {8, "восьмое"},
                {9, "девятое"},
                {10, "десятое"},
                {11, "одиннадцатое"},
                {12, "двенадцатое"},
                {13, "тринадцатое"},
                {14, "четырнадцатое"},
                {15, "пятнадцатое"},
                {16, "шестнадцатое"},
                {17, "семнадцатое"},
                {18, "восемнадцатое"},
                {19, "девятнадцатое"},
                {20, "двадцатое"},
                {21, "двадцать первое"},
                {22, "двадцать второе"},
                {23, "двадцать третье"},
                {24, "двадцать четвёртое"},
                {25, "двадцать пятое"},
                {26, "двадцать шестое"},
                {27, "двадцать седьмое"},
                {28, "двадцать восьмое"},
                {29, "двадцать девятое"},
                {30, "тридцатое"},
                {31, "тридцать первое"},
            };

            Dictionary<int, string> months = new Dictionary<int, string>
            {
                {1, "января"},
                {2, "февраля"},
                {3, "марта"},
                {4, "апреля"},
                {5, "мая"},
                {6, "июня"},
                {7, "июля"},
                {8, "августа"},
                {9, "сентября"},
                {10, "октября"},
                {11, "ноября"},
                {12, "декабря"}
            };

            Console.Write("Введите номер дня 1-31: ");
            if (!int.TryParse(Console.ReadLine(), out int day) || day is < 0 or > 31)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }
            
            Console.Write("Введите номер месяца 1-12: ");
            if (!int.TryParse(Console.ReadLine(), out int month) || month is < 0 or > 12)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            string stringDay = days.FirstOrDefault(d => d.Key == day).Value;
            string stringMonth = months.FirstOrDefault(m => m.Key == month).Value;

            Console.WriteLine();
            Console.WriteLine($"{stringDay} {stringMonth}");
        }

        private static void Task2()
        {
            string sourceDirection = "север";
            
            Console.Write("Введите команду 0, 1 или -1: ");
            if (!int.TryParse(Console.ReadLine(), out int command) || command is < -1 or > 1)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            Console.WriteLine($"Исходное направление: {sourceDirection}");

            sourceDirection = command switch
            {
                0 => "север",
                1 => "запад",
                -1 => "восток",
                _ => "север"
            };

            Console.WriteLine($"Текущее направление: {sourceDirection}");
        }

        private static void Task3()
        {
            Console.Write("Введите число 10-40: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n is < 10 or > 40)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            string result = "";

            result = n switch
            {
                10 => "десять учебных заданий",
                11 => "одиннадцать учебных заданий",
                12 => "двенадцать учебных заданий",
                13 => "тринадцать учебных заданий",
                14 => "четырнадцать учебных заданий",
                15 => "пятнадцать учебных заданий",
                16 => "шестнадцать учебных заданий",
                17 => "семнадцать учебных заданий",
                18 => "восемнадцать учебных заданий",
                19 => "девятнадцать учебных заданий",
                _ => ""
            };

            string firstPart = (n / 10) switch
            {
                2 => "Двадцать",
                3 => "Тридцать",
                4 => "Сорок",
                _ => ""
            };

            string secondPart = (n % 10) switch
            {
                1 => " одно учебное задание",
                2 => " два учебных задания",
                3 => " три учебных задания",
                4 => " четыре учебных задания",
                5 => " пять учебных заданий",
                6 => " шесть учебных заданий",
                7 => " семь учебных заданий",
                8 => " восемь учебных заданий",
                9 => " девять учебных заданий",
                0 => " учебных заданий",
                _ => ""
            };

            if (string.IsNullOrEmpty(result))
            {
                result = string.Concat(firstPart, secondPart);
                Console.WriteLine(result);
                return;
            }

            Console.WriteLine(result);
        }

        private static void Task4()
        {
            Console.Write("Введите число 100-999: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n is < 100 or > 999)
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            string result, firstPart = "", secondPart = "", thirdPart = "", fourthPart = "";

            firstPart = (n / 100) switch
            {
                1 => "сто",
                2 => "двести",
                3 => "триста",
                4 => "триста",
                5 => "пятьсот",
                6 => "шестьсот",
                7 => "семьсот",
                8 => "восемьсот",
                9 => "девятьсот",
                _ => ""
            };

            if ((n % 100) / 10 == 1)
            {
                secondPart = (n % 100) switch
                {
                    11 => " одиннадцать",
                    12 => " двенадцать ",
                    13 => " тринадцать",
                    14 => " четырнадцать",
                    15 => " пятнадцать ",
                    16 => " шестнадцать ",
                    17 => " семнадцать",
                    18 => " восемнадцать",
                    19 => " девятнадцать",
                    _  => ""
                };
            }
            else
            {
                thirdPart = (n % 100 / 10) switch
                {
                    1 => " десять",
                    2 => " двадцать",
                    3 => " тридцать",
                    4 => " сорок",
                    5 => " пятьдесят",
                    6 => " шестьдесят",
                    7 => " семьдесят",
                    8 => " восемьдесят",
                    9 => " девяносто",
                    _ => ""
                };

                fourthPart = (n % 10) switch
                {
                    1 => " один ",
                    2 => " два ",
                    3 => " три ",
                    4 => " четыре ",
                    5 => " пять ",
                    6 => " шесть ",
                    7 => " семь ",
                    8 => " восемь ",
                    9 => " девять ",
                    _ => ""
                };
            }
            
            result = string.Concat(firstPart, secondPart, thirdPart, fourthPart);

            Console.WriteLine(result);
        }

        private static void Task5()
        {
            Console.Write("Введите год: ");
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                Console.WriteLine("Вы ввели некорректное число");
                return;
            }

            string result, firstPart = "", secondPart = "", thirdPart = "";

            switch (year % 10)
            {
                case 0:
                case 1:
                    firstPart = "бел";
                    break;
                
                case 2:
                case 3:
                    firstPart = "черн";
                    break;
                
                case 4:
                case 5:
                    firstPart = "зелён";
                    break;
                
                case 6:
                case 7:
                    firstPart = "красн";
                    break;
                
                case 8:
                case 9:
                    firstPart = "жёлт";
                    break;
                
                default:
                    firstPart = "";
                    break;
            }

            switch (year % 12)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 9:
                case 10:
                case 11:
                    secondPart = "ой ";
                    break;
                case 6:
                case 7:
                case 8:
                    secondPart = "ого ";
                    break;
                
                default:
                    secondPart = "";
                    break;
            }

            switch ((year + 8) % 12)
            {
                case 0:
                    thirdPart = "крысы";
                    break;
                case 1:
                    thirdPart = "коровы";
                    break;
                case 2:
                    thirdPart = "тигра";
                    break;
                case 3:
                    thirdPart = "зайца";
                    break;
                case 4:
                    thirdPart = "дракона";
                    break;
                case 5:
                    thirdPart = "змеи";
                    break;
                case 6:
                    thirdPart = "лошади";
                    break;
                case 7:
                    thirdPart = "овцы";
                    break;
                case 8:
                    thirdPart = "обезьяны";
                    break;
                case 9:
                    thirdPart = "курицы";
                    break;
                case 10:
                    thirdPart = "собаки";
                    break;
                case 11:
                    thirdPart = "свиньи";
                    break;
            }

            result = string.Concat(firstPart, secondPart, thirdPart);
            Console.WriteLine(result);
        }
    }
}