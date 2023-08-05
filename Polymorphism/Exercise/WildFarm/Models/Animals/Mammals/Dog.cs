using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Contracts;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double foodModifier = 0.40;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(string foodName, int pieces)
        {
            ;
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
            Console.WriteLine("Woof!");
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }

    }
}
