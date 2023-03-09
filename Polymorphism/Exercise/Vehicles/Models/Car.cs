using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Vehicles.Interfaces;

namespace Vehicles.Models
{
    public class Car : Vehicle, ICar
    {
        private const double carConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption, carConsumption)
        {
        }
    }
}
