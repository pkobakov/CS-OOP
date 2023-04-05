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
        private const double initialArmorThickness = 200;
        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, initialArmorThickness)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }

        public void ToggleSubmergeMode()
        {
            this.SubmergeMode = !this.SubmergeMode;
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
            if (this.ArmorThickness < initialArmorThickness) 
            { 
                this.ArmorThickness = initialArmorThickness;
            }
        }

        public override string ToString()
        {
            string submergeMode = this.SubmergeMode ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Submerge mode: {submergeMode}";
        }
    }
}
