using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Farm
{
    public class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine("barking...");

        }
    }
}
