﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models.Client
{
    public class Adult : Client
    {
        public Adult(string name, string id, double income)
            : base(name, id, 4, income)
        {
        }

        public override void IncreaseInterest()
        {
            this.Interest += this.Interest * (2 / 100);
        }
    }
}
