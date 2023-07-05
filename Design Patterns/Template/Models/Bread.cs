using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Models
{
    public abstract class Bread
    {
        public abstract void MixIngredients();
        public abstract void Bake();
        public virtual void Slice() 
        {
            Console.WriteLine( $"Slicing the {GetType().Name} bread");
        }
        public void Make() 
        {
            MixIngredients();
            Bake();
            Slice();
        }


    }
}
