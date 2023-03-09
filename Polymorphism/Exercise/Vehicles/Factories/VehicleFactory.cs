using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Factories.Interfaces;
using Vehicles.Interfaces;
using Vehicles.Models;

namespace Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle Create(string type, double fuelQuantity, double fuelConsumption)
        {
            switch (type) 
            { 
                case "Car": return new Car (fuelQuantity, fuelConsumption); break;
                case "Truck": return new Truck(fuelQuantity, fuelConsumption); break;
                default: throw new ArgumentException("Invalid vehicle type.");
            }

        }
    }
}
