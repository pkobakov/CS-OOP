using EasterRaces.Core.Contracts;
using EasterRaces.IO;
using EasterRaces.IO.Contracts;
using EasterRaces.Core.Entities;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using System;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Repositories.Entities;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main()
        {
            IChampionshipController controller = new ChampionshipController();
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            Engine engine = new Engine(controller, reader, writer);
            engine.Run();

        }
    }
}
