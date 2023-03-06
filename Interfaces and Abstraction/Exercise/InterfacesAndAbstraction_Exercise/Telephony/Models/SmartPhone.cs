using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Contracts;
using Telephony.Exceptions;

namespace Telephony.Models
{
    public class SmartPhone : ICallable, IBrowseable
    {


        public string Browse(string url)
        {
            if (url.Any(s => char.IsDigit(s)))
            {
                throw new InvalidURLException("Invalid URL!");
            }
            return $"Browsing: {url}!";
        }

        public string Call(string number)
        { 
            if (!number.All(s => char.IsDigit(s))) 
            {
                throw new InvalidNumberException("Invalid number!");
            }
        
          return $"Calling... {number}";
        }
    }
}
