using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesExtension.Models.Contracts;

namespace VehiclesExtension.Models
{
    public class Truck : Vehicle, ITruck
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 1.6;

        public override void Refuel(double fuelAmount)
        {
            if (fuelAmount > this.TankCapacity)
            {
                base.Refuel(fuelAmount);    
            }
            else 
            {
               base.Refuel(fuelAmount * 0.95);
            
            }
        }

    }
}
