using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        public TunedCar(string make, string model, string VIN, int horsePower) 
            : base(make, model, VIN, horsePower,65, 7.5)
        {
        }

        public override void Drive()
        {
            base.Drive();

            int hpReduceAmount = (int)Math.Round(this.HorsePower * 0.03);
            this.HorsePower -= hpReduceAmount;
        }
    }
}
