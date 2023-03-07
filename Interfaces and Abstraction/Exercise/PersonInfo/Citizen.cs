using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PersonInfo
{
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        string name;
        int age;
        string id;
        string birthdate;
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;

        }
        public string Name { get => name; private set { name = value; } }

        public int Age { get => age; private set { age = value; } }

        public string Id { get => id; private set { id = value; } }

        public string Birthdate { get => birthdate; private set { birthdate = value; } }


    }
}
