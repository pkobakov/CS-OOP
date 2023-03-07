using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations.Models
{
   public class Pet : NaturalInhabitant
   {
        public Pet(string name, string birthdate)
           : base(name, birthdate)
        {
        }
    }
}
