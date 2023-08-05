using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Models.Models;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories.Models
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private ICollection<IUniversity> models;
        public UniversityRepository()
        {
            this.models = new List<IUniversity>();    
        }
        public IReadOnlyCollection<IUniversity> Models => this.models.ToList().AsReadOnly();

        public void AddModel(IUniversity model)
        {
            this.models.Add(model);
        }

       

        public IUniversity FindById(int id)
        {
            
                return models.FirstOrDefault(u => u.Id == id);

        }

        public IUniversity FindByName(string name)
        {
            
                return models.FirstOrDefault(u => u.Name == name);

        }

    }
}
