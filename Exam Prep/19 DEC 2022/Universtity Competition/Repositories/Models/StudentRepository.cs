using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories.Models
{
    public class StudentRepository : IRepository<IStudent>
    {
        private ICollection<IStudent> models;
        public StudentRepository() 
        { 
           models = new List<IStudent>();
        }
        public IReadOnlyCollection<IStudent> Models => models.ToList().AsReadOnly();

        public void AddModel(IStudent model)
        {
            this.models.Add(model);
        }

        public IStudent FindById(int id)
        {
            
             return models.FirstOrDefault(s => s.Id == id);

        }

        public IStudent FindByName(string name)
        {
            string[] fullName = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string firstName = fullName[0]; 
            string lastName = fullName[1];

      
            return models.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
         
        }
    }
}
