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
            Student studnet3 = new("Бутаков", "Никита", "Михайлович", 18, Gender.Male);
            Student studnet4 = new("Даниил", "Попов", "Станиславовч", 17, Gender.Male);
            Student studnet5 = new("Наталья", "Коскина", "Ивановна", 18, Gender.Female);
            Student studnet6 = new("Дмитрий", "Новиков", "Евгеньевич", 18, Gender.Male);

            university.AddStudent(studnet1);
            university.AddStudent(studnet2);
            university.AddStudent(studnet3);
            university.AddStudent(studnet4);
            university.AddStudent(studnet5);
            university.AddStudent(studnet6);

            //Преподаватели
            Tutor tutor1 = new("Максим", "Гордов", "Олегович", 64, Gender.Male);
            Tutor tutor2 = new("Александр", "Антонов", "Романович", 90, Gender.Male);
            Tutor tutor3 = new("Влмадимир", "Горланов", "Владимирович", 20, Gender.Male);
            Tutor tutor4 = new("Алексей", "Киселев", "Сергеевич", 20, Gender.Male);

            university.AddTutor(tutor1);
            university.AddTutor(tutor2);
            university.AddTutor(tutor3);
            university.AddTutor(tutor4);

            //Курсы
            Course course1 = new(tutor1, "Разработка программных модулей", 30);
            Course course2 = new(tutor3, "ООП", 15);
            Course course3 = new(tutor4, "Физра", 20);
            Course course4 = new(tutor2, "Разработка программных модулей", 35);

            university.AddCourse(course1);
            university.AddCourse(course2);
            university.AddCourse(course3);
            university.AddCourse(course4);


            //Запись на курсы
            university.SingUpStudentForCourse(studnet1, course1);
            university.SingUpStudentForCourse(studnet1, course2);
            university.SingUpStudentForCourse(studnet1, course3);
            university.SingUpStudentForCourse(studnet2, course3);
            university.SingUpStudentForCourse(studnet3, course3);
            university.SingUpStudentForCourse(studnet4, course3);
            university.SingUpStudentForCourse(studnet5, course3);
            university.SingUpStudentForCourse(studnet6, course3);
            university.SingUpStudentForCourse(studnet6, course2);
            university.SingUpStudentForCourse(studnet3, course2);
            university.SingUpStudentForCourse(studnet4, course1);
            university.SingUpStudentForCourse(studnet2, course4);
            university.SingUpStudentForCourse(studnet3, course4);
            university.SingUpStudentForCourse(studnet5, course4);
        }
    }
}
