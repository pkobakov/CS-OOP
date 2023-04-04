using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private ICollection<IVessel> vessels;
        public Captain(string fullName) 
        { 
            this.FullName = fullName;
            vessels = new List<IVessel>();
        }

        public string FullName
        { 
            get { return fullName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                fullName = value; }
        }

        public int CombatExperience { get; private set; } = 0;

        public ICollection<IVessel> Vessels => this.vessels.ToList().AsReadOnly();

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }

            this.vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.FullName} has {this.CombatExperience} combat experience and commands {Vessels.Count} vessels.");

            if (this.Vessels.Count != 0 )
            {
                foreach (var vessel in this.Vessels)
                {
                    if (vessel.GetType().Name == nameof(Submarine))
                    {
                        sb.AppendLine(vessel.ToString());  
                    }
                    else
                    {
                        sb.AppendLine(vessel.ToString());
                    }
                }
            }

            return sb.ToString().Trim();
        }
    }
}
