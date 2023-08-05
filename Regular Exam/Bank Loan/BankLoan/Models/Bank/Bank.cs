using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models.Bank
{
    public abstract class Bank : IBank
    {
        private string name;
        private int capacity;
        private ICollection<ILoan> loans;
        private ICollection<IClient> clients;
        public Bank(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.loans = new List<ILoan>();
            this.clients = new List<IClient>();
        }
        public string Name 
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                name = value;
            }   
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<ILoan> Loans => this.loans.ToList().AsReadOnly();

        public IReadOnlyCollection<IClient> Clients => this.clients.ToList().AsReadOnly();

        public double SumRates()
        {
            return this.loans.Sum(x => x.InterestRate);
        }

        public void AddClient(IClient Client)
        {
            if (this.Clients.Count >= this.Capacity )
            {
                throw new ArgumentException("Not enough capacity for this client.");
            }
            this.clients.Add(Client);            
        }

        public void AddLoan(ILoan loan)
        {
            this.loans.Add(loan);
        }
        public void RemoveClient(IClient Client)
        {
            this.clients.Remove(Client);
        }

        public string GetStatistics()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Name: {this.Name}, Type: {this.GetType().Name}");
            string clientsResult = this.Clients.Count != 0 ? string.Join(", ", this.Clients.Select(c => c.Name)) : "none";
            stringBuilder.AppendLine($"Clients: {clientsResult}");
            stringBuilder.AppendLine($"Loans: {this.Loans.Count}, Sum of Rates: {SumRates()}");

            return stringBuilder.ToString().TrimEnd();    
        }


    }
}
