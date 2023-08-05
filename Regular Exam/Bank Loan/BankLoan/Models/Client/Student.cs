using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models.Client
{
    public class Student : Client
    {
        public Student(string name, string id, double income) 
            : base(name, id, 2, income)
        {
        }

        public override void IncreaseInterest()
        {
            this.Interest += this.Interest * (1/100);
        }
    }
}
