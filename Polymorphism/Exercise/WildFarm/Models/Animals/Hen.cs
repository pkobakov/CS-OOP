using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Interfaces;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double henWeightMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => henWeightMultiplier;

        public override IReadOnlyCollection<Type> PreferredFoods 
            => new HashSet<Type> { typeof(Seeds), 
                                   typeof(Vegetable), 
                                   typeof(Fruit), 
                                   typeof(Meat)};

        public override string ProduceSound() => "Cluck";
    }
}
