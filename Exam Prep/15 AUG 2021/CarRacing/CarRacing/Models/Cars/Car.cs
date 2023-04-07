using CarRacing.Models.Cars.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        public Car
        ( string make,
          string model,
          string VIN, 
          int horsePower,
          double fuelAvailable,
          double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = VIN;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;        
        }
        public string Make 
        { 
           get => make; 
           private set 
           {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }    
                make = value;
           }
        }

        public string Model 
        { 
           get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }
                model = value;
            }
        }

        public string VIN
        {
            get => vin;
            private set 
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarVIN);
                }
                vin = value;
            }
        }

        public int HorsePower 
        { 
            get => horsePower;
            protected set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarHorsePower);
                }
                horsePower = value;
            }
        }

        public double FuelAvailable 
        {
            get => fuelAvailable;
            private set 
            {
                if (value < 0)
                {
                    fuelAvailable = 0;
                }
                fuelAvailable = value;  
            }
        }

        public double FuelConsumptionPerRace 
        {
            get => fuelConsumptionPerRace;
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCarFuelConsumption);
                }
                fuelConsumptionPerRace = value;
            }
        
        }

        public virtual void Drive()
        {
            this.FuelAvailable -= this.FuelConsumptionPerRace;
        }
    }
}
