using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;   
            
        }

        public virtual double DefaultFuelConsumption { get; set; } = 1.25;
        public virtual double FuelConsumption { get; set; }

        public int HorsePower { get; set;}
        public double Fuel { get; set;}

        public virtual void Drive(double kilometers) 
        { 
           
            this.Fuel -= kilometers*DefaultFuelConsumption;

        }
    }
}
