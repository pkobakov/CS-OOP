using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class LaserRadar : Supplement
    {
        public LaserRadar(int interfaceStandard, int batteryUsage) : base(20082, 5000)
        {
        }
    }
}
