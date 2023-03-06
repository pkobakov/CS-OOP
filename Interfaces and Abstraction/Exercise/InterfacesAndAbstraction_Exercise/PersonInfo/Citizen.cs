using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
    public class Citizen : IPerson
    {
        string name;
        int age;
        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
