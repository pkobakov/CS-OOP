using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories.Models
{
    public class SubjectRepository : IRepository<ISubject>
    {
        private ICollection<ISubject> models;
        public SubjectRepository()
        {
            this.models = new List<ISubject>();
        }
        public IReadOnlyCollection<ISubject> Models => models.ToList().AsReadOnly();

        public void AddModel(ISubject model)
        {
            models.Add(model);
        }

        public ISubject FindById(int id)
        {
            if (models.Any(s => s.Id == id))
            {
                return models.FirstOrDefault(s => s.Id == id);
            }
            else
            {
                return null;
            }
        }

        public ISubject FindByName(string name)
        {
            if (models.Any(s => s.Name == name))
            {
                return models.FirstOrDefault(s => s.Name == name);
            }
            else
            {
                return null;
            }
        }
    }
}
