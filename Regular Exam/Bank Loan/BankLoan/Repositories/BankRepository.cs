using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private readonly ICollection<IBank> banks; 
        public BankRepository() 
        {
            this.banks = new List<IBank>();
        }
        public IReadOnlyCollection<IBank> Models =>this.banks.ToList().AsReadOnly();

        public void AddModel(IBank model)
        {
            this.banks.Add(model);
        }

        public IBank FirstModel(string name)
        {
            return this.banks.FirstOrDefault(bank => bank.Name == name);   
        }

        public bool RemoveModel(IBank model)
        {
            return this.banks.Remove(model);
        }
    }
}
