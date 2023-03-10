using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Interfaces;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal( string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }

        public abstract IReadOnlyCollection<Type> PreferredFoods { get; }

        public abstract string ProduceSound();

        public void Eat(IFood food)
        {
            if (!PreferredFoods.Any(f => f.Name == food.GetType().Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }

            this.Weight += food.Quantity * WeightMultiplier;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString() => $"{this.GetType().Name} ";

    }
}
