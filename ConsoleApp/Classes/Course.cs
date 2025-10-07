using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPR5.Classes
{
    internal class Course
    {
        private Tutor _tutor;
        private string _name;
        private int _maxStudents;

        public List<Student> Students { get; private set; }
        public Course(Tutor tutor, string name, int maxStudents)
        {
            _tutor = tutor;
            _name = name;
            _maxStudents = maxStudents;

            Students = new();
        }

        public string GetName()
        {
            return _name;
        }
        public string GetInfoString()
        {
            return $"{_name}\t{Students.Count}/{_maxStudents}\t{_tutor.GetInitialsString()}";
        }
    }
}
