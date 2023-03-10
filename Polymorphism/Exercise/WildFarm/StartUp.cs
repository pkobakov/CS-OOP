
namespace WildFarm
{
	using System;
    using WildFarm.Core;
    using WildFarm.Core.Interfaces;
    using WildFarm.Factories;
    using WildFarm.Factories.Interfaces;
    using WildFarm.Interfaces;
    using WildFarm.IO;
    using WildFarm.IO.Interfaces;

    public class StartUp
	{
		public static void Main(string[] args)
		{
			IReader reader = new Reader();
			IWriter writer = new Writer();
			IFoodFactory foodFactory = new FoodFactory();
			IAnimalFactory animalFactory = new AnimalFactory();

			IEngine engine = new Engine(reader, writer, foodFactory, animalFactory);
            

			engine.Run();	
		}
	}
}

