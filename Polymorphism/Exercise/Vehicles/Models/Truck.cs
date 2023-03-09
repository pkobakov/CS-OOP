using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Interfaces;

namespace Vehicles.Models
{
    public class Truck : Vehicle, ITruck
    {
        private const double truckConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption, truckConsumption)
        {
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel*0.95);
        }
    }
}
