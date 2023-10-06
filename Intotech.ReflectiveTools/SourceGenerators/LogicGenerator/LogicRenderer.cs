using Intotech.ReflectiveTools.SourceGenerators.Models2DtosGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Intotech.ReflectiveTools.SourceGenerators.LogicGenerator
{
    public class LogicRenderer
    {
        public virtual void RenderLogicClassInterface(Type sourceClass, string outputPath, string usings, string nmSpace, bool isInterfase)
        {
            if (!isInterfase)
            {
                if (!sourceClass.FullName.Contains("Context"))
                {
                    GenerateClassBodyAndSave(sourceClass, outputPath, usings, nmSpace);
                }
            }
            else
            {
                if (!sourceClass.FullName.Contains("Context"))
                {
                    GenerateInterfaceBodyAndSave(sourceClass, outputPath, usings, nmSpace);
                }
            }
        }

        protected virtual void GenerateClassBodyAndSave(Type sourceClass, string outputPath, string usings, string nmSpace)
        {
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

        protected virtual void GenerateInterfaceBodyAndSave(Type sourceClass, string outputPath, string usings, string nmSpace)
        {
            outputPath += "I" + sourceClass.Name + "Logic.cs";

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
