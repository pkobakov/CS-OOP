using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Models
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;
        public Sandwich(
            string bread,
            string meat,
            string cheese,
            string veggies
            ) 
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }   
        public override SandwichPrototype Clone()
        {
            string ingredientList = this.GetIngredientList();
            Console.WriteLine($"Cloning sandwich with ingredients: {ingredientList}");
            return MemberwiseClone() as SandwichPrototype;
        }

        public string GetIngredientList() => $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
    }
}
