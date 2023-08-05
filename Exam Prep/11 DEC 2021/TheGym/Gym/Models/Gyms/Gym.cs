using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;
        public Gym(string name, int capacity) 
        { 
            this.Name = name;
            this.Capacity = capacity;
            equipment = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }
        public string Name
        { 
            get { return name; }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value; 
            }
        }

        public int Capacity { get; private set;  }

        public double EquipmentWeight => equipment.Sum(e => e.Weight);

        public ICollection<IEquipment> Equipment => this.equipment.ToList();

        public ICollection<IAthlete> Athletes => this.athletes.ToList();

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Capacity == 0)
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }

            this.Capacity--;
            this.athletes.Add(athlete);
            
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);  
        }

        public void Exercise()
        {
            foreach (var athlete in this.athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} is a {this.GetType().Name}");
            string athletesList = this.Athletes.Count > 0 ? string.Join(", ", athletes) : "No athletes";
            sb.AppendLine($"Athletes: {athletesList}");
            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight} grams\"");

            return sb.ToString().Trim();   

        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            this.Capacity++;
            return this.athletes.Remove(athlete);
        }
    }
}
