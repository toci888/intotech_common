using Intotech.ReflectiveTools.SourceGenerators.Models2DtosGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.ReflectiveTools.SourceGenerators.LogicGenerator
{
    internal class LogicRenderer
    {
        public static void RenderAutoProperties(Type sourceClass, string outputPath, string usings, string nmSpace, bool isInterfase)
        {
            if (!isInterfase)
            {
                if (!sourceClass.FullName.Contains("Context"))
                {
                    PropertyInfo[] properties = sourceClass.GetProperties();

                    outputPath += sourceClass.Name + "Logic.cs";

                    using (StreamWriter writer = new StreamWriter(outputPath, Encoding.UTF8, new FileStreamOptions() { Mode = FileMode.OpenOrCreate, Access = FileAccess.ReadWrite }))
                    {
                        writer.WriteLine(usings + Environment.NewLine);
                        writer.WriteLine(nmSpace + Environment.NewLine);
                        writer.WriteLine($"public class {sourceClass.Name}Logic : Logic<{sourceClass.Name}>, I{sourceClass.Name}Logic");
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

                    outputPath += "I"+sourceClass.Name + "Logic.cs";

                    using (StreamWriter writer = new StreamWriter(outputPath, Encoding.UTF8, new FileStreamOptions() { Mode = FileMode.OpenOrCreate, Access = FileAccess.ReadWrite }))
                    {
                        writer.WriteLine(usings + Environment.NewLine);
                        writer.WriteLine(nmSpace + Environment.NewLine);
                        writer.WriteLine($"public interface I{sourceClass.Name}Logic : ILogicBase<{sourceClass.Name}>");
                        writer.WriteLine("{");
                        writer.WriteLine("}");

                    }


                }
            }

        }
    }
}
