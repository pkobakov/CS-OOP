using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Factories.Interfaces;
using Vehicles.Interfaces;
using Vehicles.IO.Interfaces;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private IReader _reader;
        private IWriter _writer;
        private IVehicleFactory _factory;

        private readonly ICollection<IVehicle> vehicles;
        public Engine(IReader reader, IWriter writer, IVehicleFactory factory)
        {
            this._reader = reader;
            this._writer = writer;  
            vehicles = new List<IVehicle>();
            _factory = factory;
        }
        public void Run()
        {
            vehicles.Add(CreateVehicle());
            vehicles.Add(CreateVehicle());

            int commandsCount = int.Parse(_reader.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                try
                {
                    ProcessCommand();

                }
                catch (ArgumentException ae) 
                {
                    _writer.WriteLine(ae.Message);
                }
                catch (Exception)
                {

                    throw;
                }

            }

            foreach (IVehicle vehicle in vehicles) { _writer.WriteLine(vehicle.ToString()); }   
        }

        private IVehicle CreateVehicle()
        {
            string[] tokens = _reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return _factory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]));

        }
        private void ProcessCommand()
        {
            string[] commandTokens = _reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = commandTokens[0];
            string type = commandTokens[1];

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == type);
            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }

            if (command == "Drive")
            {
                double distance = double.Parse(commandTokens[2]);
                _writer.WriteLine(vehicle.Drive(distance));
            }
            else if (command == "Refuel")
            {
                double fuel = double.Parse(commandTokens[2]);
                vehicle.Refuel(fuel);
            }
        }


    }
}
