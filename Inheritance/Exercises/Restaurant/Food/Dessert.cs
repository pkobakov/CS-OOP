using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Food
{
    public class Dessert : Food
    {
        public Dessert(string name, decimal price, double grams, double calories) 
            : base(name, price, grams)
        {
            this.Calories = calories;
        }

        public double Calories { get; set; }
    }
}
