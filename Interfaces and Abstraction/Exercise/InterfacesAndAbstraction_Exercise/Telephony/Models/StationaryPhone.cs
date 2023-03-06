using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Telephony.Contracts;
using Telephony.Exceptions;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
  
        public StationaryPhone()
        {
            
        }


        public string Call(string number)
        {
            if (!number.All(s => char.IsDigit(s)))
            {
                throw new InvalidNumberException("Invalid number!");
            }

            return $"Dialing... {number}";
        }
    }
}
