using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Factories.Interfaces;
using WildFarm.Interfaces;
using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] args)
        {
            string type = args[0];
            string name = args[1];
            double weight = double.Parse(args[2]);

            switch (type) 
            {
 
                case "Owl":
                    return new Owl(name, weight, double.Parse(args[3])); break;
                case "Hen": 
                    return new Hen(name, weight, double.Parse(args[3])); break;
                case "Mouse":
                    return new Mouse(name, weight, args[3]); break;
                case "Dog": 
                    return new Dog (name, weight, args[3]);break;
                case "Cat":
                    return new Cat(name, weight, args[3], args[4]); break;
                case "Tiger":
                    return new Tiger(name, weight, args[3], args[4]);break;
                default: 
                    throw new ArgumentException("Invalid animal type");
            }
        }
    }
}
