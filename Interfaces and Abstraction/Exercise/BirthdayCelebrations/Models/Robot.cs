using BirthdayCelebrations.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations.Models
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.ID = id;
        }
        public string Model { get; set; }
        public string ID { get; private set; }
    }
}
