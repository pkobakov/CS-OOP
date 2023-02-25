using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Food
{
    public class Fish : MainDish
    {
        private const double fishGrams = 22d;
        public Fish(string name, decimal price) 
            : base(name, price, fishGrams)
        {
            
        }
    }
}
