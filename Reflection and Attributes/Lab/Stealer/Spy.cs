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

        public string AnalyzeAccessModifiers(string className) 
        {
            Type classType;
            string classFullName = string.Empty;
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            var types = myAssembly.GetTypes();
            foreach (var type in types.Where(t => t.Name == className)) 
            {
                classFullName = type.FullName;
            }

           

            StringBuilder sb = new StringBuilder();
            classType = Type.GetType(classFullName);
            FieldInfo [] nonPrivateFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            foreach (var field in nonPrivateFields )
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {

                sb.AppendLine($"{method.Name} have to be public!"); 
            }

            foreach (var method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }
    }
}
