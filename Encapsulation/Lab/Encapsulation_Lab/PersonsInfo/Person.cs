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
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName { get => firstName; private set { firstName = value; } }
        public string LastName { get => lastName; private set { lastName = value; } }
        public int Age { get => age; private set { age = value; } }
        public decimal Salary { get => salary; private set { salary = value; } }

        public decimal IncreaseSalary(decimal percentage)
        {
            if (this.Age < 30) { salary += salary*percentage/2/100; }
            else { salary += salary*percentage/100; }

            return salary;
        }
        public override string ToString() => $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        
    }
}
