using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPR5.Classes
{
    internal class UniversityConcolseMenu
    {
        private University _university;

        public UniversityConcolseMenu()
        {
            _university = new();
        }
        public void ShowMenu()
        {
            switch (PrintChooseMenu("Вывести всех студентов", "Вывести всех преподавателей", "Вывести все курсы"))
            {
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.D3:
                    break;
                case ConsoleKey.D4:
                    break;
                case ConsoleKey.D5:
                    break;
                default:
                    break;
            }
        }

        private ConsoleKey PrintChooseMenu(params string[] menuItem)
        {
            int count = menuItem.Length;

            if (count <= 1)
                return default;
            if (count > 10)
                return default;

            string menu = "";
            for (int i = 0; i < count; i++)
            {
                if (i < 9)
                {
                    menu += $"{i + 1}. {menuItem[i]}\n";
                }
                else
                {
                    menu += $"0. {menuItem[i]}\n";
                }
            }
            Console.WriteLine(menu);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        return ConsoleKey.D1;
                    case ConsoleKey.D2:
                        if (count < 2)
                            continue;
                        else 
                            return ConsoleKey.D2;
                    case ConsoleKey.D3:
                        if (count < 3)
                            continue;
                        else
                            return ConsoleKey.D3;
                    case ConsoleKey.D4:
                        if (count < 4)
                            continue;
                        else
                            return ConsoleKey.D4;
                    case ConsoleKey.D5:
                        if (count < 5)
                            continue;
                        else
                            return ConsoleKey.D5;
                    case ConsoleKey.D6:
                        if (count < 6)
                            continue;
                        else
                            return ConsoleKey.D6;
                    case ConsoleKey.D7:
                        if (count < 7)
                            continue;
                        else
                            return ConsoleKey.D7;
                    case ConsoleKey.D8:
                        if (count < 8)
                            continue;
                        else
                            return ConsoleKey.D8;
                    case ConsoleKey.D9:
                        if (count < 9)
                            continue; 
                        else
                            return ConsoleKey.D9;
                    case ConsoleKey.D0:
                        if (count < 10)
                            continue;
                        else
                            return ConsoleKey.D0;
                    default:
                        continue;
                }
            }
        }
    }
}
