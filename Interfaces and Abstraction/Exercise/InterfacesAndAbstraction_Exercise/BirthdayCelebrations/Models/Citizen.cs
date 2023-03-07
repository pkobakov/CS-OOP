using BirthdayCelebrations.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations.Models
{
    public class Citizen : NaturalInhabitant, IIdentifiable
    {
        private string name;
        private int age;

        public Citizen(string name, int age, string iD, string birthdate)
            : base(name, birthdate)
        {
            this.name = name;
            this.Age = age;
            this.ID = iD;
            this.Birthdate = birthdate;
        }

        public int Age { get; private set; }
        public string ID { get; private set; }

    }
}
