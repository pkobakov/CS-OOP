using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private ICollection<ICaptain> captains;
        public Controller() 
        {
            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }
        //ready
        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain;
            IVessel vessel;

            if (!captains.Any(c => c.FullName == selectedCaptainName)) 
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            if (vessels.FindByName(selectedVesselName) == null) 
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            vessel = vessels.FindByName(selectedVesselName);
            
            if (vessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            captain = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            captain.AddVessel(vessel);
            vessel.Captain = captain;

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }
        
        //ready
        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackVessel = vessels.FindByName(attackingVesselName);
            var defendVessel = vessels.FindByName(defendingVesselName);

            if (attackVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }

            if ( defendVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (attackVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }

            if (defendVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            
                attackVessel.Attack(defendVessel);
                attackVessel.Captain.IncreaseCombatExperience();
                defendVessel.Captain.IncreaseCombatExperience();

                return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defendVessel.ArmorThickness);
            
        }

        //ready
        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains.Where(c => c.Vessels.Count > 0).FirstOrDefault(c => c.FullName == captainFullName);
            return captain.Report();
        }
        //ready
        public string HireCaptain(string fullName)
        {
            ICaptain captain;

            if (captains.Any( c => c.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            captain = new Captain(fullName);
            captains.Add(captain);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        //ready
        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel; 

            if (vessels.FindByName(name) != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, name);
            }

            if (vesselType != nameof(Submarine) && vesselType != nameof(Battleship))
            {
                return OutputMessages.InvalidVesselType;
            }

            vessel = vesselType switch 
            { 
               nameof(Submarine) => new Submarine(name, mainWeaponCaliber, speed),
               nameof(Battleship) => new Battleship(name, mainWeaponCaliber, speed),    
            };

            vessels.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        //ready
        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();

            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        //ready
        public string ToggleSpecialMode(string vesselName)
        {
            var vessel = vessels.FindByName(vesselName);

            if (vessel == null) 
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if (vessel.GetType().Name == nameof(Submarine))
            {
                (vessel as Submarine).ToggleSubmergeMode();
                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);

            }

            else 
            {
                (vessel as Battleship).ToggleSonarMode();
                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }

            
        }

        //ready
        public string VesselReport(string vesselName)
        {
           IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return null;
            }

            return vessel.ToString();
        }
    }
}
