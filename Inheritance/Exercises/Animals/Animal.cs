using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal
    {

        private string name;
        private int age;
        private string gender;
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                name = value;
            } 
        }

        public int Age 
        {
            get => age;
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
            
                age = value;
            }
        }

        public string Gender 
        {
            get => gender;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)&& value != "Male" && value != "Female")
                {
                    throw new ArgumentException("Invalid input!");
                }

              gender = value;
            }
        }
        public abstract string ProduceSound(); 
        

        public override string ToString() 
        { 
           var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.AppendLine($"{ProduceSound()}");

            return sb.ToString();
        
        }
    }
}
