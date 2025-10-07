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
            while (true)
            {
                switch (Console.ReadKey(true).Key)
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
                        continue;
                }

                break;
            }
        }
    }
}
