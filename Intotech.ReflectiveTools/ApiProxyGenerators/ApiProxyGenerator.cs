using Intotech.Common.Http;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Intotech.ReflectiveTools.ApiProxyGenerators
{
    public class ApiProxyGenerator
    {
        protected Assembly ControllersAssembly;
        
        public ApiProxyGenerator()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve; ;

            ControllersAssembly = Assembly.LoadFrom(@"C:\Users\bzapa\source\repos\toci888\Intotech.Wheelo\Intotech.Wheelo.Api\bin\Debug\net7.0\Intotech.Wheelo.Api.dll");
        }

        private Assembly? CurrentDomain_AssemblyResolve(object? sender, ResolveEventArgs args)
        {
            string assemblyName = new AssemblyName(args.Name).Name;
            string desiredAssemblyPath = "C:\\\\Users\\\\bzapa\\\\source\\\\repos\\\\toci888\\\\Intotech.Common\\\\Intotech.Runner\\\\bin\\\\Debug\\\\net7.0\\\\Microsoft.AspNetCore.Mvc.Core.dll";

            if (assemblyName.Contains("Mvc.Core"))
            {
                if (File.Exists(desiredAssemblyPath))
                {
                    return Assembly.LoadFile(desiredAssemblyPath);
                }
            }

            string desiredAssemblyPath2 = "C:\\\\Users\\\\bzapa\\\\source\\\\repos\\\\toci888\\\\Intotech.Common\\\\Intotech.Runner\\\\bin\\\\Debug\\\\net7.0\\\\Microsoft.AspNetCore.Authorization.dll";

            if (assemblyName.Contains("AspNetCore.Authorization"))
            {
                if (File.Exists(desiredAssemblyPath2))
                {
                    return Assembly.LoadFile(desiredAssemblyPath2);
                }
            }

            return null;// Assembly.Load(args.Name);
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
            List<object> attributes = method.GetCustomAttributes(true).ToList();

            //AttributeDto attrData = (AttributeDto)attributes.Select(attr => (AttributeDto)HttpAttributesParser.GetHttpAttributeData(attr).Method.Length > 0).First();

            AttributeDto attrData = new AttributeDto();

            foreach (Attribute attribute in attributes)
            {
                attrData = HttpAttributesParser.GetHttpAttributeData(attribute);

                if (attrData.Method != null && attrData.Method.Length > 0)
                {
                    break;
                }
            }

            return $"Api{attrData.Method}<{paramType}>(\"{attrData.Route}\", false);";
        }

        private void CurrentDomain_AssemblyLoad(object? sender, AssemblyLoadEventArgs args)
        {
            //throw new NotImplementedException();
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
