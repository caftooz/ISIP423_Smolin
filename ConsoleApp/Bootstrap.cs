using ConsoleAppPR5.Classes;
using ConsoleAppPR5.Enums;

namespace ConsoleAppPR5
{
    internal class Bootstrap
    {
        static void Main(string[] args)
        {
            University KIP_FIN = new();
            UniversityConcolseMenu consoleMenu = new(KIP_FIN);

            InitializeUniversity(KIP_FIN);

            while (true)
            {
                consoleMenu.ReShowMenu();
            }
        }

        private static void InitializeUniversity(University university)
        {
            //Студенты
            Student studnet1 = new("Александр", "Смолин", "Сергеевич", 17, Gender.Male);
            Student studnet2 = new("Артемий", "Резанцев", "Павлович", 18, Gender.Male);

            university.AddStudent(studnet1);
            university.AddStudent(studnet2);

            //Преподаватели
            Tutor tutor1 = new("Максим", "Гордов", "Олегович", 64, Gender.Male);

            university.AddTutor(tutor1);

            //Курсы
            Course course1 = new(tutor1, "Разработка программных модулей", 30);

            university.AddCourse(course1);

            //Запись на курсы
            university.SingUpStudentForCourse(studnet1, course1);
        }
    }
}
