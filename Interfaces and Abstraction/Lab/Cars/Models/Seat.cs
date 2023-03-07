using Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Models
{
    public class Seat : ICar
    {
        string model;
        string color;

        public Seat(string model, string color)
        {
            this.Model = model;
            this.Color = color;
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

        public override string ToString() => $"{this.Color} {GetType().Name} {this.Model}{Environment.NewLine}{Start()}{Environment.NewLine}{Stop()}";
    }
}
