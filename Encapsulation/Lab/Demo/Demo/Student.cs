using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class Student
    {
        private string name;
        private int age;
        public Student( string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get => name; private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException("Invalid Name.");
                } name = value; } }
        public int Age
        {
            get => age; private set
            {
                if (value < 18)
                {
                    throw new ArgumentException("Too young to be a student");
                } age = value; } }

        public override string ToString()
        {
            return $"Student with Name : {this.Name} is {this.Age} years old.";
        }
    }
}
