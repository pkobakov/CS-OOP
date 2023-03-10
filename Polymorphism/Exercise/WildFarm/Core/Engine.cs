using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Core.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.Interfaces;
using WildFarm.IO.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private IFoodFactory foodFactory;
        private IAnimalFactory animalFactory;

        private readonly ICollection<IAnimal> animals;

        public Engine(IReader reader, IWriter writer, IFoodFactory foodFactory, IAnimalFactory animalFactory)
        {
            this.reader = reader;
            this.writer = writer;
            
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;

            animals = new List<IAnimal>();

        }

        public void Run()
        {
            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                IAnimal animal = null;

                try
                {
                    animal = CreateAnimal(command);
                    IFood food = CreateFood();

                    writer.Write(animal.ProduceSound());
                    
                    animal.Eat(food);

                }
                catch (ArgumentException ae)
                {
                    writer.Write(ae.Message);
                }
                catch (Exception)
                {

                    throw;
                }

                animals.Add(animal);    
            }

            foreach (var animal in animals)
            {
                writer.Write(animal.ToString());
            }
        }

        private IAnimal CreateAnimal(string command) 
        {
           string[] animalTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return animalFactory.CreateAnimal(animalTokens);
        }

        private IFood CreateFood() 
        {
            string[] foodTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string foodType = foodTokens[0];
            int quantity = int.Parse(foodTokens[1]);

            return foodFactory.CreateFood(foodType, quantity);
        }
    }
}
