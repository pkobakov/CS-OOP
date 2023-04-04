using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double SBarmorThickness = 200;
        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, SBarmorThickness)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }
        public override void RepairVessel()
        {
            this.ArmorThickness = SBarmorThickness;
        }

        public override string ToString()
        {
            string submergeMode = this.SubmergeMode ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Sonar mode: {submergeMode}";
        }
    }
}
