using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private double maxMileage;
        private string licensePlateNumber;
        private int batteryLevel;

        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            this.Brand = brand;
            this.Model = model;
            this.MaxMileage = maxMileage;
            this.LicensePlateNumber = licensePlateNumber;
        }
        public string Brand
        {
            get { return brand; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }
                brand = value;
            }
        }
        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                model = value;
            }
        }

        public double MaxMileage { get; private set; }

        public string LicensePlateNumber
        {
            get { return licensePlateNumber; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }

                licensePlateNumber = value; }
        }

        public int BatteryLevel { get; private set; } = 100;

        public bool IsDamaged { get; private set; } = false;
        public void ChangeStatus()
        {
            this.IsDamaged = !this.IsDamaged;
        }

        public virtual void Drive(double mileage)
        {
            double percentage = Math.Round(this.maxMileage / mileage)*100;

            this.batteryLevel -= (int)(percentage);

            if (this.GetType().Name == nameof(CargoVan))
            {
                this.batteryLevel -= 5;
            }
        }

        public void Recharge()
        {
            this.batteryLevel = 100;
        }

        public override string ToString()
        {
            string result = this.IsDamaged ? "OK" : "damaged";
            return $"{this.Brand} {this.Model} License plate: {this.LicensePlateNumber} Battery: {this.BatteryLevel}% Status: {result}";
        }
    }
}
