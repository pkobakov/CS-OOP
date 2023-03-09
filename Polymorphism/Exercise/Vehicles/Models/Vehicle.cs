using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private  double fuelQuantity;
        private  double fuelConsumption;
        private double increaseConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double increaseConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.increaseConsumption = increaseConsumption;
        }

        public double FuelQuantity { get => fuelQuantity; private set { fuelQuantity = value; } }
        public double FuelConsumption { get => fuelConsumption; private set { fuelConsumption = value; } }

       
        public string Drive(double distance)
        {
            double totalConsumption = FuelConsumption + increaseConsumption;

            if (FuelQuantity < distance*totalConsumption) 
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * totalConsumption;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuel)
        {
            FuelQuantity += fuel;
        }

        public override string ToString() =>$"{this.GetType().Name}: {FuelQuantity:f2}";
    }
}
