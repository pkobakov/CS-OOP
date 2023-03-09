using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius { get; private set; }
        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(this.Radius, 2);
        }

        public override double CalculatePerimeter()
        {
            return 2*(Math.PI*this.Radius);
        }

        public override string Draw()
        {
            return base.Draw();
        }

    }
}
