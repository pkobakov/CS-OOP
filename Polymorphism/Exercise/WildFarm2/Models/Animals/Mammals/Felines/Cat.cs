using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Contracts;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double foodModifier = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }
        public override void Eat(string foodName, int pieces)
        {

            if (foodName != nameof(Meat) && foodName != nameof(Vegetable))
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
            Console.WriteLine("Meow");
        }
    }
}
