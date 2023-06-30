using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Core.Contracts;
using WildFarm.IO.Contracts;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Animals.Mammals.Felines;
using WildFarm.Models.Contracts;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        IReader reader;
        IWriter writer;

        StringBuilder stringBuilder = new StringBuilder();

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string command;
            while ((command = reader.ReadLine()) != "End")
            {

                try
                {
                    IAnimal animal = null;
                    string [] animalData  = command.Split().ToArray();
                    string[] foodGiven = reader.ReadLine().Split().ToArray();

                    string animalType = animalData[0];
                    string name = animalData[1];
                    double weight = double.Parse(animalData[2]);
                    
                    animal = animalType switch
                    {
                        nameof(Hen) => new Hen(name, weight, double.Parse(animalData[3])),
                        nameof(Owl) => new Owl(name, weight, double.Parse(animalData[3])),
                        nameof(Cat) => new Cat(name, weight, animalData[3], animalData[4]),
                        nameof(Tiger) => new Tiger(name, weight, animalData[3], animalData[4]),
                        nameof(Dog) => new Dog(name, weight, animalData[3]),
                        nameof(Mouse) => new Mouse(name, weight, animalData[3]),
                        _ => throw new ArgumentException("Invalid animal type!")
                    };


                    IFood food = null;
                    string foodType = foodGiven[0];
                    int foodPieces = int.Parse(foodGiven[1]);

                    animal.ProduceSound();
                    FoodCheck(animal, foodType, foodPieces);

                    stringBuilder.AppendLine(animal.ToString());
                }
                catch (ArgumentException ae)
                {

                    writer.WriteLine(ae.Message); continue;
                }
                
            }

            writer.WriteLine(stringBuilder.ToString().TrimEnd());
        }

        private static void FoodCheck(IAnimal animal, string foodName, int pieces) 
        {
            HashSet<string> foodNames = new HashSet<string>()
            { 
                "Meat", "Vegetable", "Fruit", "Seeds"
            };

            if (!foodNames.Contains(foodName))
            {
                throw new ArgumentException("Invalid Food Type!");
            }

            else 
            {
                animal.Eat(foodName, pieces);
            }
        }
    }
}
