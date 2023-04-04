using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        public IReadOnlyCollection<T> Models => throw new NotImplementedException();

        public void Add(T model)
        {
            throw new NotImplementedException();
        }

        public T FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T model)
        {
            throw new NotImplementedException();
        }
    }
}
