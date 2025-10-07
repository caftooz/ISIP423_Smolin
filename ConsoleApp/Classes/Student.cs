using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPR5.Classes
{
    internal class Student : Person
    {
        private List<Course> _courses;

        internal void SignUpForACourse(Course course)
        {
            _courses.Add(course);
        }
    }
}
