using Intotech.ReflectiveTools.SourceGenerators.LogicGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.ReflectiveTools.SourceGenerators.StandardManagerGenerator
{
    public class ManagerRenderer : IRenderer
    {
        public virtual void GenerateInterfaceBodyAndSave(Type sourceClass, string outputPath, string usings, string nmSpace)
        {
            if (!usings.Contains("Intotech.Common.Bll.Interfaces"))
            {
                usings += "\r\nusing Intotech.Common.Bll.Interfaces;";
            }

            outputPath += "IStandard" + sourceClass.Name + "Manager.cs";

            using (StreamWriter writer = new StreamWriter(outputPath, Encoding.UTF8, new FileStreamOptions() { Mode = FileMode.OpenOrCreate, Access = FileAccess.ReadWrite }))
            {
                writer.WriteLine(usings + Environment.NewLine);
                writer.WriteLine(nmSpace + Environment.NewLine);
                writer.WriteLine($"public interface IStandard{sourceClass.Name}Manager : IStandardControllerManager<I{sourceClass.Name}Logic, {sourceClass.Name}, {sourceClass.Name}ModelDto, {sourceClass.Name}Dto>");
                writer.WriteLine("{");
                writer.WriteLine("}");

            }
        }

        public virtual void GenerateClassBodyAndSave(Type sourceClass, string outputPath, string usings, string nmSpace)
        {
            if (!usings.Contains("Intotech.Wheelo.Common"))
            {
                usings += "\r\nusing Intotech.Wheelo.Common;";
            }

            outputPath += "Standard" + sourceClass.Name + "Manager.cs";

            using (StreamWriter writer = new StreamWriter(outputPath, Encoding.UTF8, new FileStreamOptions() { Mode = FileMode.OpenOrCreate, Access = FileAccess.ReadWrite }))
            {
                writer.WriteLine(usings + Environment.NewLine);
                writer.WriteLine(nmSpace + Environment.NewLine);
                writer.WriteLine($"public class Standard{sourceClass.Name}Manager : WheeloServiceManager<I{sourceClass.Name}Logic, {sourceClass.Name}, {sourceClass.Name}ModelDto, {sourceClass.Name}Dto>");
                writer.WriteLine("{");
                writer.WriteLine($"        public Standard{sourceClass.Name}Manager(I{sourceClass.Name}Logic logic) : base(logic)");
                writer.WriteLine("        {");
                writer.WriteLine("        }");
                writer.WriteLine("}");

            }
        }
    }
}
