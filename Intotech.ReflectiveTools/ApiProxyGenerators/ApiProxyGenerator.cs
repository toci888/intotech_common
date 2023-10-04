using Intotech.Common.Http;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Core;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;

namespace Intotech.ReflectiveTools.ApiProxyGenerators
{
    public class ApiProxyGenerator
    {
        protected Assembly ControllersAssembly;
        
        public ApiProxyGenerator()
        {
            ControllersAssembly = Assembly.LoadFrom(@"C:\Users\bzapa\source\repos\toci888\Intotech.Wheelo\Toci.Driver.Api\bin\Debug\net7.0\Intotech.Wheelo.Api.dll");
        }

        public virtual void CreateProxies(string usings, string namespaceStr, string outputPath)
        {
            List<Type> controllerTypes = ControllersAssembly.GetTypes().Where(t => t.Name.Contains("Controller")).ToList();

            foreach (Type controllerType in controllerTypes)
            {
                List<MethodInfo> methods = controllerType.GetMethods().ToList();

                string proxyBody = string.Empty;

                foreach (MethodInfo method in methods)
                {
                    proxyBody += GetProxyMethodBody(method);
                }

                string fullClass = GetProxyClassBody(controllerType, proxyBody, usings, namespaceStr);

                File.WriteAllText($"{outputPath}\\{controllerType.Name}ApiProxyTest.cs", fullClass);
            }
        }

        protected virtual string GetProxyClassBody(Type controllerType, string classContents, string usings, string namespaceStr)
        {
            StringBuilder entireClass = new StringBuilder();

            usings += Environment.NewLine + "using Intotech.Wheelo.Tests.Integration.Basic;";

            entireClass.AppendLine(usings);
            entireClass.AppendLine($"namespace {namespaceStr}; {Environment.NewLine}");
            entireClass.AppendLine($"public class {controllerType.Name}ApiProxyTest : IntegrationTestsBaseProxy ");
            entireClass.AppendLine("{");
            entireClass.AppendLine(classContents);
            entireClass.AppendLine("}");


            return entireClass.ToString();
        }

        protected virtual string GetProxyMethodCallByAttributes(MethodInfo method, string paramType)
        {
            HttpPutAttribute gowno = new HttpPutAttribute();

            List<Attribute> attributes = method.GetCustomAttributes().ToList();

            //AttributeDto attrData = (AttributeDto)attributes.Select(attr => (AttributeDto)HttpAttributesParser.GetHttpAttributeData(attr).Method.Length > 0).First();

            AttributeDto attrData = new AttributeDto();

            foreach (Attribute attribute in attributes)
            {
                attrData = HttpAttributesParser.GetHttpAttributeData(attribute);

                if (attrData.Method.Length > 0)
                {
                    break;
                }
            }

            return $"Api{attrData.Method}<{paramType}>(\"{attrData.Route}\", false);";
        }

        protected virtual string GetProxyMethodBody(MethodInfo method)
        {
            StringBuilder sb = new StringBuilder();

            if (method.ReturnType.GenericTypeArguments.Length == 0)
            {
                return string.Empty;
            }

            sb.AppendLine($"public virtual {method.ReturnType.GenericTypeArguments[0].Name} {method.Name}Test() ");

            sb.AppendLine("{");

            ParameterInfo paramMethod = method.GetParameters().Count() > 0 ? method.GetParameters()[0] : null;

            if (paramMethod == null)
            {
                return string.Empty;
            }

            string paramType = paramMethod.ParameterType.ToString().Split(".", StringSplitOptions.None).Last();
            string callProxyMethod = GetProxyMethodCallByAttributes(method, paramType);

            sb.AppendLine($"{paramType} {paramMethod.Name} = new {paramType}();");

            sb.AppendLine(callProxyMethod);

            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
