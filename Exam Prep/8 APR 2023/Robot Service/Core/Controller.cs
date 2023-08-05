using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IRepository<IRobot> robots;
        private IRepository<ISupplement> supplements;

        public Controller()
        {
            this.robots = new RobotRepository();
            this.supplements = new SupplementRepository();
        }
        public string CreateRobot(string model, string typeName)
        {
            string message = string.Format(OutputMessages.RobotCannotBeCreated, typeName);

            if (typeName != nameof(IndustrialAssistant) && typeName != nameof(DomesticAssistant))
            {
                return message; 
            }
            IRobot robot = typeName switch
            {
                nameof(DomesticAssistant) => new DomesticAssistant(model),
                nameof(IndustrialAssistant) => new IndustrialAssistant(model),
            };

            this.robots.AddNew(robot);

            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            ISupplement supplement;
            string message = string.Format(OutputMessages.SupplementCannotBeCreated, typeName);

            if (typeName != nameof(SpecializedArm) && typeName != nameof(LaserRadar))
            {
                return message;
            }

            supplement = typeName switch 
            {
               nameof(SpecializedArm) => new SpecializedArm(),
               nameof(LaserRadar) => new LaserRadar()
            };

            this.supplements.AddNew(supplement);
            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            var selectedRobots = this.robots.Models().Where(r => r.InterfaceStandards
                                                                  .Any(s => s == intefaceStandard));

            if (selectedRobots.Count() == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            var sortedRobots =selectedRobots.OrderByDescending(r => r.BatteryLevel);
            var availablePower = sortedRobots.Sum(r => r.BatteryLevel);

            if (availablePower < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - availablePower);
            }

            int usedRobotsCount = 0;

            foreach (var robot in sortedRobots)
            {
                usedRobotsCount++;

                if (robot.BatteryLevel >= totalPowerNeeded)  
                {
                    robot.ExecuteService(totalPowerNeeded);  break;
                }
                if (robot.BatteryLevel < totalPowerNeeded)
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                    
                }
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, usedRobotsCount);

        }

        public string Report()
        {
            var sb = new StringBuilder();   
            foreach (var robot in this.robots.Models()
                                      .OrderByDescending(b => b.BatteryLevel)
                                      .ThenBy(b => b.BatteryCapacity))
            {
                sb.AppendLine(robot.ToString());
                     
            }

            return sb.ToString().Trim();
        }

        public string RobotRecovery(string model, int minutes)
        {
            
            var feededRobots = robots.Models().Where(r => r.BatteryLevel < r.BatteryCapacity * 0.50 && r.Model == model).ToList();

            feededRobots.ForEach( r => r.Eating(minutes));


            return string.Format(OutputMessages.RobotsFed, feededRobots.Count());
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = this.supplements.Models().FirstOrDefault( s => s.GetType().Name == supplementTypeName);
            int interFaceValue = supplement.InterfaceStandard;
            var selectedRobots = this.robots.Models().Where(i => i.InterfaceStandards.All(i => i != interFaceValue)).ToList();
            var robotsForUpgrade = selectedRobots.Where( r => r.Model == model);
           

            if (robotsForUpgrade.Count() == 0)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            var robotForUpgrade = robotsForUpgrade.FirstOrDefault();

            robotForUpgrade.InstallSupplement(supplement);
            this.supplements.RemoveByName(supplementTypeName);
            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);

        }
    }
}
