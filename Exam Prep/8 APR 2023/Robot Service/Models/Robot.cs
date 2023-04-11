using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private int batteryLevel;
        private int convertionCapacityIndex;
        private ICollection<int> interfaceStandarts;
        public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            this.Model = model;
            this.BatteryCapacity = batteryCapacity;
            this.BatteryLevel = batteryCapacity;
            this.ConvertionCapacityIndex = conversionCapacityIndex;
            this.interfaceStandarts = new List<int>();
        }
        public string Model 
        { 
            get => model;
            private set 
            { 
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }
                model = value;
            } 
        }

        public int BatteryCapacity 
        { 
            get => batteryCapacity;
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }
                batteryCapacity = value; 
            }
        }

        public int BatteryLevel 
        { 
            get => batteryLevel;
            private set 
            {
                batteryLevel = value;
            } 
        }

        public int ConvertionCapacityIndex { get; private set; }

        public IReadOnlyCollection<int> InterfaceStandards => this.interfaceStandarts.ToList().AsReadOnly();

        public void Eating(int minutes)
        {
            int producedEnergy =  this.ConvertionCapacityIndex * minutes;
            
            if (this.BatteryLevel == this.BatteryCapacity)
            {
                this.BatteryLevel = this.BatteryCapacity;
            }
            else 
            {
                this.BatteryLevel += producedEnergy;
            }
           
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (this.BatteryLevel >= consumedEnergy)
            {
                this.BatteryLevel -= consumedEnergy;
                return true;
            }

            return false;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            int supplementInterfaceStandart = supplement.InterfaceStandard;
            this.interfaceStandarts.Add(supplementInterfaceStandart);
            this.BatteryCapacity -= supplement.BatteryUsage;
            this.BatteryLevel -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} {this.Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            var supplementList = this.interfaceStandarts.Count > 0 ? string.Join(", ", this.interfaceStandarts) : "none";
            sb.AppendLine($"--Supplements installed: {supplementList}");
            return sb.ToString().Trim(); ;
        }
    }
}
