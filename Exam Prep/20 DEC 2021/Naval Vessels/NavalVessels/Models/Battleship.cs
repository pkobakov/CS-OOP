using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double initialArmorThickness = 300;
        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, initialArmorThickness)
        {
            this.SonarMode = false;
        }

        public bool SonarMode { get; private set; }
        public void ToggleSonarMode()
        {
            this.SonarMode = !this.SonarMode;

            if (this.SonarMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
                
            }

            
        }
        public override void RepairVessel()
        {
            if (ArmorThickness < initialArmorThickness)
            {
                this.ArmorThickness = initialArmorThickness;
            }
        }
        public override string ToString()
        {
            string sonarMode = this.SonarMode ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Sonar mode: {sonarMode}";
        }
    }
}
