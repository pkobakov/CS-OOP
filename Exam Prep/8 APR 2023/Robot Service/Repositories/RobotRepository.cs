using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private ICollection<IRobot> models;
        public RobotRepository()
        {
            this.models = new List<IRobot>();
        }

        public void AddNew(IRobot model)
        {
            this.models.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            return this.models.FirstOrDefault(m => m.InterfaceStandards.Any(i => i == interfaceStandard));
        }

        public IReadOnlyCollection<IRobot> Models()
        {
            return this.models.ToList().AsReadOnly();
        }

        public bool RemoveByName(string typeName)
        {
            var model = this.models.FirstOrDefault(r => r.GetType().Name == typeName);
            return this.models.Remove(model);
        }

       
    }
}
