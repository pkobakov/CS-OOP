using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Services
{
    public static class Validator 
    {
      
        public static bool IsValid(object obj) 
        {
           var properties = obj.GetType().GetProperties().Where(p => p.CustomAttributes
                                                         .Any(ca => typeof(MyValidationAttribute)
                                                         .IsAssignableFrom(ca.AttributeType)))
                                                         .ToArray();
            
            foreach (var property in properties) 
            {
                IEnumerable<MyValidationAttribute> attributes = property.GetCustomAttributes()
                                                                        .Where(ca => typeof(MyValidationAttribute)
                                                                        .IsAssignableFrom(ca.GetType()))
                                                                        .Cast<MyValidationAttribute>();
                foreach (var attribute in attributes) 
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;

        }
    }
}
