using Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class Tesla : ICar, IElectricCar
    {
        public int Battery => throw new NotImplementedException();

        string model;
        string color;
        int baterries;

        public Tesla(string model, string color, int baterries)
        {
            this.Model = model;
            this.Color = color;
            this.baterries = baterries;
        }

        public string Model
        {
            get => model;
            private set => model = value;
        }


        public string Color
        {
            get => color;
            private set => color = value;
        }

        public string Start() => "Engine Start";

        public string Stop() => "Breaaak!";
        public override string ToString() => $"{this.Color} {GetType().Name} {this.Model} with {baterries} batteries{Environment.NewLine}{Start()}{Environment.NewLine}{Stop()}";
    }
}
