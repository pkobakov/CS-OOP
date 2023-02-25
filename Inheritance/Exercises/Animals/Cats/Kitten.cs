using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Cats
{
    public class Kitten : Cat
    {
        private const string kittenGender = "Female";
        public Kitten( string name, int age) : 
            base(name, age, kittenGender)
        {
            
        }

        public override string ProduceSound() => "Meow";
    }
}
