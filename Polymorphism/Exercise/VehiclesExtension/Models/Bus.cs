using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesExtension.Models.Contracts;

namespace VehiclesExtension.Models
{
    public class Bus: Vehicle, IBus
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override string Drive(double distance)
        {
            double fuelNeeded = distance * (this.FuelConsumption + 1.4);

            if (this.FuelQuantity < fuelNeeded)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public string DriveEmpty(double distance) 
        {
            return base.Drive(distance);
        }
    }
}
