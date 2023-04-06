using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        public TunedCar(string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace) 
            : base(make, model, VIN, horsePower,65, 7.5)
        {
        }

        public override void Drive()
        {
            base.Drive();

            int hpReduceAmount = Convert.ToInt32(this.HorsePower * 3 / 100);
            this.HorsePower -= hpReduceAmount;
        }
    }
}
