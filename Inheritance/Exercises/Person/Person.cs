using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        private string name; 
        private int age;    
        private const int minAge = 0;
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name 
        {
            get { return this.name; }
            private set { this.name = value; } 
        }
        public virtual int Age 
        {
            get { return this.age; }
            protected set 
            {
                if (value >= minAge)
                {
                 this.age = value; 
                }
            }   
        
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append(String.Format("Name: {0}, Age: {1}", Name, Age));


            return str.ToString();

        }
    }
}
