using ConsoleAppPR5.Classes;
using ConsoleAppPR5.Enums;

namespace ConsoleAppPR5
{
    internal class Bootstrap
    {
        static void Main(string[] args)
        {
            //UniversityConcolseMenu consoleMenu = new();
            //consoleMenu.ShowMenu();

            University un = new();

            string format = "|{0,-15}|{1,-10}|{2,-10}|{3,-40}|";
            string line = "--------------------------------------------------------------------------------";

            Student studnet = new("Александр", "Смолин", "Сергеевич", 17, Gender.Male);
            Student studnet1 = new("Артемий", "Резанцев", "Павлович", 18, Gender.Male);

            Tutor tutor = new("Максим", "Гордов", "Олегович", 64, Gender.Male);

            Course course = new(tutor, "Разработка программных модулей", 30);

            un.SingUpStudentForCourse(studnet, course);

            Console.WriteLine(line);
            Console.WriteLine(Student.GetTitleColumnString(format));
            Console.WriteLine(line);
            Console.WriteLine(studnet.GetInfoString(format));
            Console.WriteLine(studnet1.GetInfoString(format));
            Console.WriteLine(line);

            Console.WriteLine();

            Console.WriteLine(line);
            Console.WriteLine(Tutor.GetTitleColumnString(format));
            Console.WriteLine(line);
            Console.WriteLine(tutor.GetInfoString(format));
            Console.WriteLine(line);
        }
    }
}





// Просматривать информацию о всех студентах/преподавателей/курсах

// Студенты могут записываться на курсы
