using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPR5.Classes
{
    internal class University
    {
        private List<Student> _allStudents;
        private List<Tutor> _allTutors;
        private List<Course> _allCourses;

        public University()
        {
            _allStudents = new();
            _allTutors = new();
            _allCourses = new();
        }
        public void AddStudent(Student student)
        {
            _allStudents.Add(student);
        }
        public void AddTutor(Tutor tutor)
        {
            _allTutors.Add(tutor);
        }
        public void AddCourse(Course course)
        {
            _allCourses.Add(course);
        }
        public void SingUpStudentForCourse(Student student, Course course)
        {
            student.SignUpForACourse(course);
            course.Students.Add(student);
        }
        public string GetStudnetsTableString()
        {
            string format = "|{0,-15}|{1,-10}|{2,-10}|{3,-40}|\n";
            string line = "--------------------------------------------------------------------------------\n";

            string table = line + Student.GetTitleColumnString(format) + line;
            if (_allStudents.Count > 0)
            {
                foreach (var student in _allStudents)
                {
                    table += student.GetInfoString(format);
                }
            }
            else
            {
                table += String.Format(format, "", "", "", "");
            }

            table += line;

            return table;
        }
        public string GetTutorTableString()
        {
            string format = "|{0,-15}|{1,-10}|{2,-10}|{3,-40}|\n";
            string line = "--------------------------------------------------------------------------------\n";

            string table = line + Student.GetTitleColumnString(format) + line;
            if (_allTutors.Count > 0)
            {
                foreach (var tutor in _allTutors)
                {
                    table += tutor.GetInfoString(format);
                }
            }
            else
            {
                table += String.Format(format, "", "", "", "");
            }

            table += line;

            return table;
        }
    }
}
