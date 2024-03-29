﻿using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private int minHorsePower;
        private int maxHorsePower;
        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.CubicCentimeters = cubicCentimeters;
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            this.HorsePower = horsePower;
           
            
        }
        public string Model
        {
            get => model;
            private set 
            { 
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4) 
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, 4));
                }

                model = value;
            
            }
        }

        public int HorsePower 
        { 
            get => horsePower;
            private set 
            {
                if (value < this.minHorsePower || value > this.maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                horsePower = value;
            }

        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            double result = CubicCentimeters / HorsePower * laps;
            return result;
        }
    }
}
