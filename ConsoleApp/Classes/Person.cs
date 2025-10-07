using ConsoleAppPR5.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace ConsoleAppPR5.Classes
{
    internal abstract class Person
    {
        private string _name;
        private string _surname;
        private string? _middleName;

        private int _age;
        private Gender _gender;

        public Person(string name, string surname, string? middleName, int age, Gender gender)
        {
            _name = name;
            _surname = surname;
            _middleName = middleName;
            _age = age;
            _gender = gender;
        }

        public string GetInitialsString()
        {
            return $"{_surname} {_name[0]}. {(_middleName != null ? (_middleName[0] + ".") : String.Empty)}";
        }
        protected string[] GetPersonInfoStringArray()
        {
            string[] infoArr = { GetInitialsString(), _age.ToString(), _gender.ToString() };
            return infoArr;
        }
        protected static string[] GetPersonTitleColumnStringArray()
        {
            string[] titleColumnArr = { "ФИО", "возраст", "пол" };
            return titleColumnArr;
        }
    }
}
