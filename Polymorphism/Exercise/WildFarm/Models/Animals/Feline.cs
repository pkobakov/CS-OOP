using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Feline : Animal, IFeline, IMammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight)
        {
            this.Breed = breed;
            this.LivingRegion = livingRegion;
        }

        public string Breed { get; private set; }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"[{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
