using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class Route : IRoute
    {
        private string startPoint;
        private string endPoint;
        private double length;
        private int routeId;
        public Route(string startPoint, string endPoint, double length, int routeId)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.Length = length;
            this.RouteId = routeId;
        }
        public string StartPoint 
        {
             get { return startPoint; } 
             private set 
             {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.StartPointNull);
                } 
                startPoint = value;
             }
        }

        public string EndPoint 
        {
            get { return  endPoint; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EndPointNull);
                }
                endPoint = value;
            }
        }

        public double Length 
        {
            get { return length; }
            private set 
            {
                if (value < 1)
                {
                    throw new ArgumentNullException(ExceptionMessages.RouteLengthLessThanOne);
                }
                length = value;
            }
        
        }

        public int RouteId { get { return routeId; } private set { routeId = value; } }

        public bool IsLocked { get;  private set; } = true;

        public void LockRoute()
        {
            this.IsLocked = true;
        }
    }
}
