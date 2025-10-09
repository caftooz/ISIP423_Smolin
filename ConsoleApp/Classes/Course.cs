using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPR5.Classes
{
    internal class Course
    {
        private static int _lastId = 1;
        public int ID { get; private set; }

        private Tutor _tutor;
        private string _name;
        private int _maxStudents;

        public List<Student> Students { get; private set; }
        public Course(Tutor tutor, string name, int maxStudents)
        {
            _tutor = tutor;
            _name = name;
            _maxStudents = maxStudents;

            ID = _lastId;
            _lastId++;

            Students = new();
            tutor.Courses.Add(this);
        }

        public string GetName()
        {
            return _name;
        }
        public string GetInfoString(string format)
        {
            return String.Format(format, ID,_name, _tutor.GetInitialsString(), $"{Students.Count}/{_maxStudents}");
        }
        public static string GetTitleColumnString(string format)
        {
            return String.Format(format, "ID", "название", "преподаватель", "студенты");
        }
    }
}
