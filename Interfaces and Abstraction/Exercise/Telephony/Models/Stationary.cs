using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Contracts;

namespace Telephony.Models
{
    public class Stationary : ICallable
    {
        public string Call(string number)
        {
            if (!number.All(n => char.IsDigit(n)))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {number}";
        }
    }
}
