using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public Spy() { }
        public string StealFieldInfo(string type, params string [] fields) 
        {
            
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(type);
            FieldInfo[] classFields = classType.GetFields( BindingFlags.Instance |
                                                           BindingFlags.Public | 
                                                           BindingFlags.NonPublic |
                                                           BindingFlags.Static);

            var classInstance = Activator.CreateInstance(classType);
            
            sb.AppendLine($"Class under investigation: {classType.FullName}");
            foreach (FieldInfo field in classFields.Where(f => fields.Contains(f.Name))) 
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
                   
            }

            
            return sb.ToString();
        }
    }
}
