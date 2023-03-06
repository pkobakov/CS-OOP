using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Ingredients
{
    public class Dough
    {
        private readonly Dictionary<string, double> flourTypes = 
            new Dictionary<string, double>() 
            { 
                { "white", 1.5 },
                { "wholegrain", 1.0} 
            };

        private readonly Dictionary<string, double> bakingTechnics =
            new Dictionary<string, double>()
            {
                {"crispy", 0.9 },
                {"chewy", 1.1},
                {"homemade", 1.0}
            };

        private readonly double baseModifier = 2; 

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType 
        {
            get => flourType;
            private set
            { 
               if (!flourTypes.ContainsKey( value.ToLower())) 
               {

                    throw new ArgumentException("Invalid type of dough.");
               }
            
             flourType = value.ToLower();
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                if (!bakingTechnics.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value.ToLower();
            }
        }

        public double Weight 
        { 
            get=> weight;
            private set 
            {
                if (  value < 1 || value > 200) 
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

            weight = value;
            } 
        }

        public double Calories => ((baseModifier * this.Weight) * (flourTypes[this.FlourType]*bakingTechnics
            [this.BakingTechnique]));

        public override string ToString() => $"{this.Calories:F2}";
        
    }
}
