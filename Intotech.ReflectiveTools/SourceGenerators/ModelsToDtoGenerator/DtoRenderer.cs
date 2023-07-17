using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.ReflectiveTools.SourceGenerators.ModelsToDtoGenerator
{
    public class DtoRenderer
    {
        public virtual void RenderAutoProperties(Type sourceClass, string outputPath, string usings, string nmSpace)
        {
          
                if (!sourceClass.FullName.Contains("Context"))
                {
                    PropertyInfo[] properties = sourceClass.GetProperties();

                    outputPath += sourceClass.Name + "Dto.cs";

                    using (StreamWriter writer = new StreamWriter(outputPath, Encoding.UTF8, new FileStreamOptions() { Mode = FileMode.OpenOrCreate, Access = FileAccess.ReadWrite }))
                    {
                        writer.WriteLine(usings + Environment.NewLine);
                        writer.WriteLine(nmSpace + Environment.NewLine);
                        writer.WriteLine($"public class {sourceClass.Name}Dto : DtoBase");
                        writer.WriteLine("{");
                        writer.WriteLine($"    public {sourceClass.Name}ModelDto {sourceClass.Name} {{ get; set; }}");
                        //writer.WriteLine($"    public {sourceClass.Name}roleModelDto {sourceClass.Name}Role {{ get; set; }}");
                        //writer.WriteLine($"    public {sourceClass.Name}modeModelDto {sourceClass.Name}Mode {{ get; set; }}");
                        writer.WriteLine("}");

                    }
                }

        }
    }
}
