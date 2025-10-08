using ConsoleAppPR5.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ConsoleAppPR5.Classes
{
    internal class Tutor : Person
    {
        private static int _lastId = 1;
        public int ID { get; private set; }
        public List<Course> Courses { get; private set; }
        public Tutor(string name, string surname, string? middleName, int age, Gender gender) : base(name, surname, middleName, age, gender)
        {
            Courses = new();

            ID = _lastId;
            _lastId++;
        }

        public string GetInfoString(string format)
        {
            string coursesStr = "";
            foreach (var course in Courses)
            {
                coursesStr += (course.GetName() + ", ");
            }

            string[] personInfoStringArray = GetPersonInfoStringArray();

            return String.Format(format, ID,personInfoStringArray[0], personInfoStringArray[1], personInfoStringArray[2], coursesStr);
        }
        public static string GetTitleColumnString(string format)
        {
            string[] personTitleColumnStringArray = GetPersonTitleColumnStringArray();

            return String.Format(format, "ID",personTitleColumnStringArray[0], personTitleColumnStringArray[1], personTitleColumnStringArray[2], "ведёт курсы");
        }
    }
}
