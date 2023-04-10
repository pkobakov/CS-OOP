using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class IndustrialAssistant : Robot
    {
        public IndustrialAssistant(string model, int batteryCapacity, int conversionCapacityIndex)
            : base(model, 40000, 40000)
        {
        }
    }
}
