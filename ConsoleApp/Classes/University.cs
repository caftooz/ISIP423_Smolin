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
        public string GetStudnetsTable()
        {
            return String.Empty;
        }
    }
}
