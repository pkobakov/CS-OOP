
namespace Vehicles
{
	using System;
    using Vehicles.Core;
    using Vehicles.Factories;
    using Vehicles.Factories.Interfaces;
    using Vehicles.Interfaces;
    using Vehicles.IO;
    using Vehicles.IO.Interfaces;
    using Vehicles.Models;

    public class StartUp
	{
		public static void Main(string[] args)
		{
			IReader reader = new Reader();
			IWriter writer = new Writer();
			IVehicleFactory vehicle = new VehicleFactory();

			IEngine engine = new Engine(reader, writer, vehicle);

			engine.Run();
        }
	}
}
