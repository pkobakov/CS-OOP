using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Food
{
    public class Cake : Dessert
    {
        private const decimal cakePrice = 5m;
        private const double cakeGrams = 250d;
        private const double cakeCalories = 1000d;
        public Cake (string name) 
            : base(name, cakePrice, cakeGrams, cakeCalories)
        {
            
        }
    }
}
