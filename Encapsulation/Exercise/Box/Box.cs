using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height) 
        { 
            Length = length;
            Width = width;
            Height = height;
        
        }    
        public double Length
        {
            get => length; 
            private set
            {
                Validation(value, nameof(Length));

                length = value;
            } 
        }
        public double Width 
        { 
            get => width; 
            private set 
            {
                Validation(value, nameof(Width));
                width = value;
            } 
        }
        public double Height
        {
            get => height;
            private set
            {
                Validation(value, nameof(Height));

                height = value; 
            }
        }

        public double SurfaceArea() => (2*((length * height)+(length*width)+(width*height)));
        public double LateralSurfaceArea() => 2 * ((length * height) + (width * height));
        public double Volume() => length*width*height;
        public void Validation(double value, string propertyName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{propertyName} cannot be zero or negative.");
            }

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.SurfaceArea():f2}");
            sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {this.Volume():f2}");
            
            return sb.ToString().TrimEnd();
        }
    }
}
