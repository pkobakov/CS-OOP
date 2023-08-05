using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula1.Models.Race
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;
        ICollection<IPilot> pilots;
        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            pilots = new List<IPilot>();
        }
        public string RaceName 
        {
            get => raceName;
            private set 
            { 
                if (value.Length < 5 || string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                raceName = value;
            }
        }

        public int NumberOfLaps 
        { 
            get => numberOfLaps;
            private set 
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                numberOfLaps = value;
            }
        }

        public bool TookPlace { get ; set ; } = false;

        public ICollection<IPilot> Pilots => this.pilots.ToList().AsReadOnly();


        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            string tookPlaceResult = this.TookPlace ? "Yes" : "No";
            var sb = new StringBuilder();
            sb.AppendLine($"The { this.RaceName } race has:");
            sb.AppendLine($"Participants: {this.Pilots.Count}");
            sb.AppendLine($"Number of laps: { this.NumberOfLaps }");
            sb.AppendLine($"Took place: {tookPlaceResult}"); 


            return sb.ToString().Trim();
        }
    }
}
