using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Contracts;

namespace WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double foodModifier = 0.35;
        public Hen(string name, double weight,double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(string foodName, int pieces)
        {
            this.FoodEaten += pieces;
             this.Weight += foodModifier * pieces;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
