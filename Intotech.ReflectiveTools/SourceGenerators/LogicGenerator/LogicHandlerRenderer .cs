using Intotech.ReflectiveTools.SourceGenerators.Models2DtosGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.ReflectiveTools.SourceGenerators.LogicGenerator
{
    public class LogicHandlerRenderer
    {
        public virtual void RenderAutoProperties(Type sourceClass, string outputPath, string usings, string nmSpace, bool isInterfase)
        {
            if (!isInterfase)
            {
                if (!sourceClass.FullName.Contains("Context"))
                {
                    PropertyInfo[] properties = sourceClass.GetProperties();

                    outputPath += "IDto" + sourceClass.Name + "LogicHandler.cs";

                    using (StreamWriter writer = new StreamWriter(outputPath, Encoding.UTF8, new FileStreamOptions() { Mode = FileMode.OpenOrCreate, Access = FileAccess.ReadWrite }))
                    {
                        writer.WriteLine(usings + Environment.NewLine);
                        writer.WriteLine(nmSpace + Environment.NewLine);
                        writer.WriteLine($"public interface IDto{sourceClass.Name}LogicHandler : IDtoLogicHandler<I{sourceClass.Name}DtoLogic, {sourceClass.Name}Dto>");
                        writer.WriteLine("{");
                        writer.WriteLine("}");

                    }
                }
            }
            else
            {
                if (!sourceClass.FullName.Contains("Context"))
                {
                    PropertyInfo[] properties = sourceClass.GetProperties();

                    outputPath += "IDto" + sourceClass.Name + "LogicHandler.cs";

                    using (StreamWriter writer = new StreamWriter(outputPath, Encoding.UTF8, new FileStreamOptions() { Mode = FileMode.OpenOrCreate, Access = FileAccess.ReadWrite }))
                    {
                        writer.WriteLine(usings + Environment.NewLine);
                        writer.WriteLine(nmSpace + Environment.NewLine);
                        writer.WriteLine($"public interface IDto{sourceClass.Name}LogicHandler : IDtoLogicHandler<I{sourceClass.Name}DtoLogic, {sourceClass.Name}Dto>");
                        writer.WriteLine("{");
                        writer.WriteLine("}");

                    }
                }
            }

        }
    }
}
