using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class RouteRepository : IRepository<IRoute>
    {
        private ICollection<IRoute> models;
        public RouteRepository() 
        {
            this.models = new List<IRoute>();
        }
        public void AddModel(IRoute model)
        {
            this.models.Add(model);
        }

        public IRoute FindById(string identifier)
        {
            return this.models.FirstOrDefault(m => m.RouteId == int.Parse(identifier));
        }

        public IReadOnlyCollection<IRoute> GetAll()
        {
            return this.models.ToList().AsReadOnly();
        }

        public bool RemoveById(string identifier)
        {
           return this.models.Remove(this.FindById(identifier));
        }
    }
}
