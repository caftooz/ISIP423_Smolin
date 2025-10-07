using ConsoleAppPR5.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ConsoleAppPR5.Classes
{
    internal class Tutor : Person
    {
        public Tutor(string name, string surname, string? middleName, int age, Gender gender) : base (name, surname, middleName, age, gender)
        {
            Courses = new();
        }
        public List<Course> Courses { get; private set; }

        public string GetInfoString(string format)
        {
            string coursesStr = "";
            foreach (var course in Courses)
            {
                coursesStr += (course.GetName() + ", ");
            }

            string[] personInfoStringArray = GetPersonInfoStringArray();

            return String.Format(format, personInfoStringArray[0], personInfoStringArray[1], personInfoStringArray[2], coursesStr);
        }
        public static string GetTitleColumnString(string format)
        {
            string[] personTitleColumnStringArray = GetPersonTitleColumnStringArray();

            return String.Format(format, personTitleColumnStringArray[0], personTitleColumnStringArray[1], personTitleColumnStringArray[2], "ведёт курсы");
        }
    }
}
