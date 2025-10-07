using ConsoleAppPR5.Enums;
using System;
using System.Collections.Generic;
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
    }
}
