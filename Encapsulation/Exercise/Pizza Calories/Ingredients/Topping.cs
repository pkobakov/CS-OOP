using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Ingredients
{
    public class Topping
    {
        private readonly Dictionary<string, double> toppingTypes =
            new Dictionary<string, double>() 
            { 
                { "meat", 1.2 },
                { "veggies", 0.8 },
                { "cheese", 1.1 },
                { "sauce", 0.9 } 
            };

        private readonly double baseModifier = 2.0;
        private double weight;
        private string toppingType;

        public Topping(string toppingType, double weight )
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }

        public string ToppingType
        {
            get => toppingType;
            private set
            {
                if (!toppingTypes.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                toppingType = value;
            }
        }
        public double Weight 
        { 
            get => weight;
            private set 
            {
                if (value < 1 || value > 50) 
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50]."); 
                 
                }

                weight = value;
            } 
            
        
        }



        public double Calories => baseModifier * weight * toppingTypes[toppingType.ToLower()];

        public override string ToString() => $"{this.Calories:F2}";
        
    }
}
