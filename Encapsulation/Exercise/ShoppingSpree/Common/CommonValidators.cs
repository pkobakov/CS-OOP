using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree.Common
{
    public  class CommonValidators
    {
        private const decimal MoneyMinValue = 0;
        public static void ValidateName(string value)
        {
            if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
        }
        public static void ValidateSum(decimal value)
        {
            if (value < MoneyMinValue)
            {
                throw new ArgumentException("Money cannot be negative");
            }
        }
    }
}
