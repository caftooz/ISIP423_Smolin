using ConsoleAppPR5.Enums;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace ConsoleAppPR5.Classes
{
    internal class Student : Person
    {
        public List<Course> Courses { get; private set; }

        public Student(string name, string surname, string? middleName, int age, Gender gender) : base (name, surname, middleName, age, gender)
        {
            Courses = new();
        }
        public void SignUpForACourse(Course course)
        {
            Courses.Add(course);
        }
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

            return String.Format(format, personTitleColumnStringArray[0], personTitleColumnStringArray[1], personTitleColumnStringArray[2], "записан на курсы");
        }
    }
}
