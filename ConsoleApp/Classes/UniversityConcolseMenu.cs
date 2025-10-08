using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleAppPR5.Classes
{
    internal class UniversityConcolseMenu
    {
        private University _university;

        public UniversityConcolseMenu(University university)
        {
            _university = university;
        }
        public void ReShowMenu()
        {
            Console.Clear();

            switch (PrintAndChooseMenu("Студенты", "Преподаватели", "Курсы"))
            {
                case ConsoleKey.D1:
                    ShowStudents();
                    break;
                case ConsoleKey.D2:
                    ShowTutors();
                    break;
                case ConsoleKey.D3:
                    ShowCourses();
                    break;
            }

            Console.ReadKey(true);
        }

        private void ShowStudents()
        {
            string table = _university.GetStudnetsTableString();
            Console.WriteLine(table);

            switch (PrintAndChooseMenu("Выбрать", "Добавить нового"))
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine("Введите ID студента для выбора: ");
                        int id = int.Parse(Console.ReadLine());
                        ChooseStudent(id);
                    }
                    break;
                case ConsoleKey.D2:
                    AddStudent();
                    break;
            }
        }

        private void ShowTutors()
        {
            string table = _university.GetTutorsTableString();
            Console.WriteLine(table);

            switch (PrintAndChooseMenu("Выбрать", "Добавить нового"))
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine("Введите ID преподавателя для выбора: ");
                        int id = int.Parse(Console.ReadLine());
                        ChooseTutor(id);
                    }
                    break;
                case ConsoleKey.D2:
                    AddTutor();
                    break;
            }
        }
        private void ShowCourses()
        {
            string table = _university.GetCoursesTableString();
            Console.WriteLine(table);

            switch (PrintAndChooseMenu("Выбрать", "Добавить новый"))
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine("Введите ID курса для выбора: ");
                        int id = int.Parse(Console.ReadLine());
                        ChooseCourse(id);
                    }
                    break;
                case ConsoleKey.D2:
                    AddCourse();
                    break;
            }
        }
        private void ChooseStudent(int id)
        {
        }
        private void ChooseTutor(int id)
        {
        }
        private void ChooseCourse(int id)
        {
        }
        private void AddStudent()
        {
        }
        private void AddTutor()
        {
        }
        private void AddCourse()
        {
        }


        private ConsoleKey PrintAndChooseMenu(params string[] menuItem)
        {
            PrintChooseMenu(menuItem);

            ConsoleKey key = ChooseMenu(menuItem);

            return key;
        }
        private void PrintChooseMenu(params string[] menuItem)
        {
            int count = menuItem.Length;

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
        }
        private ConsoleKey ChooseMenu(params string[] menuItem)
        {
            int count = menuItem.Length;

            if (count <= 1 || count > 10)
                throw new Exception("Неверный список меню");

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
