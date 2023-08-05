using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;
        public Controller() 
        { 
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            if ((athleteType == nameof(Boxer) && gym.GetType().Name != nameof(BoxingGym)) ||
                (athleteType == nameof(Weightlifter) && gym.GetType().Name != nameof(WeightliftingGym))) 
            {
                return OutputMessages.InappropriateGym;
            }

            IAthlete athlete = athleteType switch
            { 
               nameof(Boxer) => new Boxer(athleteName, motivation, numberOfMedals),
               nameof(Weightlifter) => new Weightlifter(athleteName, motivation, numberOfMedals),
               _=> throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType)
            };

            gym.AddAthlete(athlete);

            return $"Successfully added {athleteType} to {gymName}.";


        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = equipmentType switch 
            { 
                nameof(BoxingGloves) => new BoxingGloves(),
                nameof(Kettlebell) => new Kettlebell(),
                _=> throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType)
            };

            this.equipment.Add(equipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);


        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = gymType switch
            {
                nameof(BoxingGym) => new BoxingGym(gymName),
                nameof(WeightliftingGym) => new WeightliftingGym(gymName),
                _=> throw new InvalidOperationException(ExceptionMessages.InvalidGymType)
            }; 

            gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            var totalWeight = gym.EquipmentWeight;

            return $"The total weight of the equipment in the gym {gymName} is {totalWeight:f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            IEquipment equipment = this.equipment.FindByType(equipmentType);
            if (equipment == null) 
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            
            }
            

            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);




        }

        public string Report()
        {
            var sb = new StringBuilder();   
            foreach (var gym in gyms) 
            {
                sb.AppendLine($"{gym.Name} is a {gym.GetType().Name}:");
                
                string athletesList = gym.Athletes.Count > 0 ? string.Join(", ", gym.Athletes.Select(a => a.FullName) ) : "No athletes";
                sb.AppendLine($"Athletes: {athletesList}");
                sb.AppendLine($"Equipment total count: {gym.Equipment.Count}");
                sb.AppendLine($"Equipment total weight: {gym.EquipmentWeight:f2} grams");
            }

            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);
            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
