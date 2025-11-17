using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public static class Menu
    {
        static private int _i = 1;
        public static void Write(params string[] items)
        {
            int length = _i + items.Length;
            if (length <= 1 || length > 9) throw new Exception("Неверное количество пунктов в меню");


            foreach (string item in items)
            {
                Console.WriteLine($"{_i}. {item}");
                _i++;
            }
        }
        public static Numbers Input(int numbersCount, bool haveExit = false)
        {
            _i = 1;
            Numbers choosenNumber = new();
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D0:
                        if (haveExit) choosenNumber = Numbers.D0;
                        else continue;
                        break;
                    case ConsoleKey.D1:
                        choosenNumber = Numbers.D1;
                        break;
                    case ConsoleKey.D2:
                        if (numbersCount >= 2) choosenNumber = Numbers.D2;
                        else continue;
                        break;
                    case ConsoleKey.D3:
                        if (numbersCount >= 3) choosenNumber = Numbers.D3;
                        else continue;
                        break;
                    case ConsoleKey.D4:
                        if (numbersCount >= 4) choosenNumber = Numbers.D4;
                        else continue;
                        break;
                    case ConsoleKey.D5:
                        if (numbersCount >= 5) choosenNumber = Numbers.D5;
                        else continue;
                        break;
                    case ConsoleKey.D6:
                        if (numbersCount >= 6) choosenNumber = Numbers.D6;
                        else continue;
                        break;
                    case ConsoleKey.D7:
                        if (numbersCount >= 7) choosenNumber = Numbers.D7;
                        else continue;
                        break;
                    case ConsoleKey.D8:
                        if (numbersCount >= 8) choosenNumber = Numbers.D8;
                        else continue;
                        break;
                    case ConsoleKey.D9:
                        if (numbersCount >= 9) choosenNumber = Numbers.D9;
                        else continue;
                        break;
                    default:
                        continue;
                }
                break;
            }

            Console.Clear();
            return choosenNumber;
        }

        public enum Numbers
        {
            D0, D1, D2, D3, D4, D5, D6, D7, D8, D9
        }
    }
}
