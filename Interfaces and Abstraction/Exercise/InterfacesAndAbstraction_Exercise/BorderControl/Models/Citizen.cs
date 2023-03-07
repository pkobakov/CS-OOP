using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models
{
    public class Citizen : IIdentifiable
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id) 
        { 
           this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        public string Name { get => name; private set { name = value; } }
        public int Age { get => age; private set { age = value; } }
        public string Id { get => id; private set { id = value; } }
    }
}
