using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Beverage
{
    public class Coffee : HotBeverage
    {
        private const decimal coffeePrice = 3.50m;
        private const double coffeeMilliliters = 50d;
        public Coffee(string name, double caffeine) 
            : base(name, coffeePrice, coffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public  double Caffeine { get; set; }
    }
}
