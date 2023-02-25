using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Cats
{
    internal class Tomcat : Cat
    {
        private const string tomcatGender = "Male";
        public Tomcat(string name, int age) : 
            base(name, age, tomcatGender)
        {
            
        }

        public override string ProduceSound() => "MEOW";
    }
}
