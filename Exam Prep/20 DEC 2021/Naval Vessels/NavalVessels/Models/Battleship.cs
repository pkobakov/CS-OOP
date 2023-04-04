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
        private const double BSarmorThickness = 300;
        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, BSarmorThickness)
        {
            this.SonarMode = false;
        }

        public bool SonarMode { get; private set; }
        public void ToggleSonarMode()
        {
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

            this.SonarMode = ! this.SonarMode;
        }
        public override void RepairVessel()
        {
            this.ArmorThickness = BSarmorThickness;
        }
        public override string ToString()
        {
            string sonarMode = this.SonarMode ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Sonar mode: {sonarMode}";
        }
    }
}
