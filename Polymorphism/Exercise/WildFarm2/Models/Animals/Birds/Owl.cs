using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Contracts;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double foodModifier = 0.25;
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(string foodName, int pieces)
        {

            if (foodName != nameof(Meat))
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {foodName}!");
            }

            else 
            {
                this.FoodEaten += pieces;
                this.Weight += foodModifier * pieces;
            }

        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
