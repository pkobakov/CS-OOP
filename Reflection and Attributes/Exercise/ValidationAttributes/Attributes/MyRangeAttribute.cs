using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int _minValue;
        private readonly int _maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this._minValue = minValue;
            this._maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {


            return (int)obj > _minValue && (int)obj < _maxValue;
        }
    }
}
