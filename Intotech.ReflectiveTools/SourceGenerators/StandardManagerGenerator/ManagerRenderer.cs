using Intotech.ReflectiveTools.SourceGenerators.LogicGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.ReflectiveTools.SourceGenerators.StandardManagerGenerator
{
    public class ManagerRenderer : LogicRenderer
    {
        protected override void GenerateInterfaceBodyAndSave(Type sourceClass, string outputPath, string usings, string nmSpace)
        {
            if (!usings.Contains("Intotech.Common.Bll.Interfaces"))
            {
                usings += "using Intotech.Common.Bll.Interfaces;";
            }

            outputPath += "IStandard" + sourceClass.Name + "Manager.cs";

            using (StreamWriter writer = new StreamWriter(outputPath, Encoding.UTF8, new FileStreamOptions() { Mode = FileMode.OpenOrCreate, Access = FileAccess.ReadWrite }))
            {
                writer.WriteLine(usings + Environment.NewLine);
                writer.WriteLine(nmSpace + Environment.NewLine);
                writer.WriteLine($"public interface IStandard{sourceClass.Name}Manager : IStandardControllerManager<{sourceClass.Name}>");
                writer.WriteLine("{");
                writer.WriteLine("}");

            }
        }

        protected override void GenerateClassBodyAndSave(Type sourceClass, string outputPath, string usings, string nmSpace)
        {
            
        }
    }
}
