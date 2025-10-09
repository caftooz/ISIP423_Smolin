using ConsoleAppPR5.Enums;
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
            Console.Clear();
            string table = _university.GetStudnetsTableString();
            Console.WriteLine(table);

            switch (PrintAndChooseMenu("Выбрать", "Добавить нового", "Выход"))
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
                case ConsoleKey.D3:
                    break;
            }
        }
        private void ShowTutors()
        {
            Console.Clear();
            string table = _university.GetTutorsTableString();
            Console.WriteLine(table);

            switch (PrintAndChooseMenu("Выбрать для удаления", "Добавить нового", "Выход"))
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine("Введите ID преподавателя для удаления: ");
                        int id = int.Parse(Console.ReadLine());
                        ChooseTutor(id);
                    }
                    break;
                case ConsoleKey.D2:
                    AddTutor();
                    break;
                case ConsoleKey.D3:
                    break;
            }
        }
        private void ShowCourses()
        {
            Console.Clear();
            string table = _university.GetCoursesTableString();
            Console.WriteLine(table);

            switch (PrintAndChooseMenu("Выбрать для удаления", "Добавить новый", "Выход"))
            {
                case ConsoleKey.D1:
                    {
                        Console.WriteLine("Введите ID курса для удаления: ");
                        int id = int.Parse(Console.ReadLine());
                        ChooseCourse(id);
                    }
                    break;
                case ConsoleKey.D2:
                    AddCourse();
                    break;
                case ConsoleKey.D3:
                    break;
            }
        }

        private void ChooseStudent(int id)
        {
            Console.Clear();
            Student student = _university.GetStudent(s => s.ID == id);

            string format = "|{0,-4}|{1,-15}|{2,-10}|{3,-10}|{4,-50}|\n";
            string line = "-----------------------------------------------------------------------------------------------\n";

            Console.WriteLine(line + Student.GetTitleColumnString(format) + line + student.GetInfoString(format) + line);

            switch (PrintAndChooseMenu("Удалить", "Записать на курс"))
            {
                case ConsoleKey.D1:
                    _university.RemoveStudent(student);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"студент {student.GetInitialsString()} удалён!!!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine(_university.GetCoursesTableString());
                    Console.WriteLine($"Введите ID курса для записи студента \"{student.GetInitialsString()}\": ");
                    int courseId = int.Parse(Console.ReadLine());
                    Course course = _university.GetCourse(c => c.ID == courseId);
                    _university.SingUpStudentForCourse(student, course);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n{student.GetInitialsString()} успешно записан на курс \"{course.GetName()}\"");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }
        private void ChooseTutor(int id)
        {
            Tutor tutor = _university.GetTutor(t => t.ID == id);

            _university.RemoveTutor(tutor);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Преподаватель {tutor.GetInitialsString()} удалён!!!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private void ChooseCourse(int id)
        {
            Course course = _university.GetCourse(c => c.ID == id);

            _university.RemoveCourse(course);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Курс \"{course.GetName()}\" удалён!!!");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        private void AddStudent()
        {
            Console.Clear();
            Console.Write("Введите имя студента: ");
            string name = Console.ReadLine();
            Console.Write("Введите фамилию студента: ");
            string surname = Console.ReadLine();
            Console.Write("Введите отчество студента: ");
            string middle = Console.ReadLine();
            Console.Write("Введите возраст студента: ");
            string age = Console.ReadLine();
            Console.WriteLine("Выберите пол студента: ");
            Gender gender = default;
            switch (PrintAndChooseMenu("Мужчина", "Женщина"))
            {
                case ConsoleKey.D1:
                    gender = Gender.Male;
                    break;
                case ConsoleKey.D2:
                    gender = Gender.Female;
                    break;
            }

            Student student = new(name, surname, middle, int.Parse(age), gender);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Студент усешно добавлен!\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            string format = "|{0,-4}|{1,-15}|{2,-10}|{3,-10}|{4,-50}|\n";
            string line = "-----------------------------------------------------------------------------------------------\n";

            Console.WriteLine(line + Student.GetTitleColumnString(format) + line + student.GetInfoString(format) + line);

            _university.AddStudent(student);

        }
        private void AddTutor()
        {
            Console.Clear();
            Console.Write("Введите имя преподавателя: ");
            string name = Console.ReadLine();
            Console.Write("Введите фамилию преподавателя: ");
            string surname = Console.ReadLine();
            Console.Write("Введите отчество преподавателя: ");
            string middle = Console.ReadLine();
            Console.Write("Введите возраст преподавателя: ");
            string age = Console.ReadLine();
            Console.WriteLine("Выберите пол преподавателя: ");
            Gender gender = default;
            switch (PrintAndChooseMenu("Мужчина", "Женщина"))
            {
                case ConsoleKey.D1:
                    gender = Gender.Male;
                    break;
                case ConsoleKey.D2:
                    gender = Gender.Female;
                    break;
            }

            Tutor tutor = new(name, surname, middle, int.Parse(age), gender);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Преподаватель усешно добавлен!\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            string format = "|{0,-4}|{1,-15}|{2,-10}|{3,-10}|{4,-40}|\n";
            string line = "-------------------------------------------------------------------------------------\n";

            Console.WriteLine(line + Tutor.GetTitleColumnString(format) + line + tutor.GetInfoString(format) + line);

            _university.AddTutor(tutor);
        }
        private void AddCourse()
        {
            Console.Clear();
            Console.Write("Введите название курса: ");
            string name = Console.ReadLine();

            string table = _university.GetTutorsTableString();
            Console.WriteLine(table);

            Console.WriteLine("Введите ID преподавателя для назначения на курс: ");
            int id = int.Parse(Console.ReadLine());

            Tutor tutor = _university.GetTutor(t => t.ID == id);

            Console.Write("Введите максимальное количество студентов на курс: ");
            string maxStudents = Console.ReadLine();

            Course course = new(tutor, name, int.Parse(maxStudents));
            _university.AddCourse(course);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Курс усешно добавлен!\n");
            Console.ForegroundColor = ConsoleColor.Gray;
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
