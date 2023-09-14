using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.ReflectiveTools.ApiProxyGenerators
{
    public class ApiProxyGenerator
    {
        protected Assembly ControllersAssembly;

        public ApiProxyGenerator()
        {
            ControllersAssembly = Assembly.LoadFrom(@"C:\Users\bzapa\source\repos\toci888\intotech_wheelo\Toci.Driver.Api\bin\Debug\net7.0\Intotech.Wheelo.Api.dll");
        }

        public virtual void CreateProxies()
        {
            List<Type> controllerTypes = ControllersAssembly.GetTypes().Where(t => t.Name.Contains("Controller")).ToList();

            foreach (Type controllerType in controllerTypes)
            {
                List<MethodInfo> methods = controllerType.GetMethods().ToList();

                foreach (MethodInfo method in methods)
                {
                    GetProxyBody(method);
                }
            }
        }

        protected virtual string GetProxyBody(MethodInfo method)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"public virtual {method.ReturnType.GenericTypeArguments[0].Name} {method.Name}Test() ");

            sb.AppendLine($"{{");

            ParameterInfo paramMethod = method.GetParameters()[0];

            sb.AppendLine($"{paramMethod.ParameterType} {paramMethod.Name} = new {paramMethod.ParameterType}();");



            sb.AppendLine($"}}");

            return sb.ToString();
        }
    }
}
