using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VehiclesExtension.Models.Contracts;

namespace VehiclesExtension.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double tankCapacity;
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity 
        {
            get { return fuelQuantity; }
            protected set 
            {
                if (value > tankCapacity) 
                { 
                   fuelQuantity = 0;
                }
                else 
                {
                   fuelQuantity = value;
                
                }

            } 
        }
        public double TankCapacity
        {
            get { return tankCapacity; }
            private set 
            {
                tankCapacity = value;
            } 
        }

        public virtual double FuelConsumption { get; protected set; }


        public virtual string Drive( double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            if (this.FuelQuantity < fuelNeeded ) 
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.TankCapacity < fuelAmount)
            {
                throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
            }

            this.FuelQuantity += fuelAmount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
