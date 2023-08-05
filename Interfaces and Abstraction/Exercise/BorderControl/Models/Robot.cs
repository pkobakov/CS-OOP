using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models
{
    public class Robot : IIdentifiable
    {
        private string id;
        private string model;
        public Robot(string model, string id) 
        { 
            this.Id = id;
            this.Model = model;
        }

        public string Model { get; set; }

        public string Id { get => id; private set { id = value; } }
    }
}
