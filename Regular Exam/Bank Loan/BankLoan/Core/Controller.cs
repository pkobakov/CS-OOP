using BankLoan.Core.Contracts;
using BankLoan.Models.Bank;
using BankLoan.Models.Client;
using BankLoan.Models.Contracts;
using BankLoan.Models.Loan;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private IRepository<ILoan> loans;
        private IRepository<IBank> banks;
        public Controller() 
        { 
            this.loans = new LoanRepository();
            this.banks = new BankRepository();
        }
        public string AddBank(string bankTypeName, string name)
        {
            IBank bank = bankTypeName switch
            {
                nameof(BranchBank) => new BranchBank(name),
                nameof(CentralBank) => new CentralBank(name),
                _ => throw new ArgumentException(ExceptionMessages.BankTypeInvalid) //!!! could be ArgumentException instead of return string
            }; 

            this.banks.AddModel(bank);
            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }

        public string AddLoan(string loanTypeName)
        {
            ILoan loan = loanTypeName switch 
            {
                nameof(StudentLoan) => new StudentLoan(),
                nameof(MortgageLoan) => new MortgageLoan(),
                _=> throw new ArgumentException(ExceptionMessages.LoanTypeInvalid)
            };

            this.loans.AddModel(loan);
            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan = this.loans.FirstModel(loanTypeName);
            IBank bank = this.banks.FirstModel(bankName);

            if (loan == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }

            bank.AddLoan(loan);
            this.loans.RemoveModel(loan);
            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            IClient client = clientTypeName switch 
            {
              nameof(Student) => new Student(clientName, id, income),
              nameof(Adult) => new Adult(clientName, id, income),
              _=> throw new ArgumentException(ExceptionMessages.ClientTypeInvalid)
            };
            
            // Student => BranchBank
            // Adult => CentralBank

            IBank bank = this.banks.FirstModel(bankName);

            bool studentCondition = bank.GetType().Name == nameof(CentralBank) &&
                client.GetType().Name == nameof(Student);
            bool adultConditition = bank.GetType().Name == nameof(BranchBank) &&
                client.GetType().Name == nameof(Adult);

            if (studentCondition || adultConditition)
            {
                return OutputMessages.UnsuitableBank;
            }

            bank.AddClient(client);
            return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);

        }


        public string FinalCalculation(string bankName)
        {
            IBank bank = this.banks.FirstModel(bankName);

            double incomeSum = bank.Clients.Sum(x => x.Income);
            double loansAmount = bank.Loans.Sum(x => x.Amount);

            double total = incomeSum + loansAmount;

            return string.Format(OutputMessages.BankFundsCalculated, bankName, $"{total:f2}");
        }


        public string Statistics()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var bank in this.banks.Models)
            {
                stringBuilder.AppendLine(bank.GetStatistics()); 
            }

            return stringBuilder.ToString().TrimEnd();    
        }
    }
}
