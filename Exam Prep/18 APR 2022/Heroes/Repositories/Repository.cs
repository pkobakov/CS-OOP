using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        private readonly IList<T> models;
        public Repository()
        {
            models = new List<T>();
        }
        public IReadOnlyCollection<T> Models => models.ToList().AsReadOnly();

        public void Add(T model)
        {
            models.Add(model);
        }

        public T FindByName(string name)
        {
            return models.FirstOrDefault( m => m.GetType().Name == name);

        }

        public bool Remove(T model)
        {
            return models.Remove(model); 
        }
    }
}
