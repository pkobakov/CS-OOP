using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Factories.Interfaces;
using WildFarm.Interfaces;
using WildFarm.Models.Foods;

namespace WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string type, int quantity)
        {
            switch (type) 
            {
                case "Vegetable":return new Vegetable(quantity); break;
                case "Fruit":return new Fruit(quantity); break;
                case "Meat":return new Meat(quantity); break;
                case "Seeds": return new Seeds(quantity); break;
                default:throw new ArgumentException("Invalid food type"); break;
            }

            
        }
    }
}
