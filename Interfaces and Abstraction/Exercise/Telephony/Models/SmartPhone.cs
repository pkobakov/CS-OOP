using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Contracts;

namespace Telephony.Models
{
    public class SmartPhone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            if (!url.All(c => !char.IsDigit(c))) 
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (!number.All(n => char.IsDigit(n))) 
            { 
              throw new ArgumentException ("Invalid number!");
            }

            return $"Calling... {number}";
        }
    }
}
