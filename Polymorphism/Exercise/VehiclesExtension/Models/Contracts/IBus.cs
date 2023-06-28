using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesExtension.Models.Contracts
{
     public interface IBus : IVehicle
     {
        string DriveEmpty(double distance);
     }
}
