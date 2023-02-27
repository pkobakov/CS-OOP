using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person( string firstName, string lastName, int age )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName { get => firstName; private set { firstName = value; } }
        public string LastName { get => lastName; private set { lastName = value; } }   
        public int Age { get => age; private set { age = value; } }

        public override string ToString() => $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        
    }
}
