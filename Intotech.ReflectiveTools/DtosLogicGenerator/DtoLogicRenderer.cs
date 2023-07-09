using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.ReflectiveTools.DtosLogicGenerator
{
    public class DtoLogicRenderer
    {
        public virtual void RendererDtoLogic(Type model, string outputPath, string usings, string nmSpace, bool isInterfase)
        {
            if (!isInterfase)
            {
                outputPath += model.Name + "DtoLogic.cs";

                using (StreamWriter writer = new StreamWriter(outputPath, Encoding.UTF8, new FileStreamOptions() { Mode = FileMode.OpenOrCreate, Access = FileAccess.ReadWrite }))
                {
                    writer.WriteLine(usings + Environment.NewLine);
                    writer.WriteLine(nmSpace + Environment.NewLine);
                    writer.WriteLine($"public class {model.Name}DtoLogic : DtoLogicBase<{model.Name}ModelDto, {model.Name}, I{model.Name}Logic, {model.Name}Dto, List<{model.Name}>, List<{model.Name}ModelDto>>, I{model.Name}DtoLogic");
                    writer.WriteLine("{");

                    writer.WriteLine($"    public {model.Name}DtoLogic(I{model.Name}Logic {model.Name.ToLower()}logic) \r\n        " +
                        $": base({model.Name.ToLower()}logic, \r\n            " +
                        $"(aDto, aModelDto) => {{ \r\n                " +
                        $"aDto.{model.Name} = aModelDto;\r\n                " +
                        $"return aDto;\r\n            }})\r\n    {{\r\n    }}\r\n\r\n    " +
                        $"protected override DtoBase<{model.Name},{model.Name}ModelDto> GetDtoModelField({model.Name}Dto dto)\r\n    {{\r\n       " +
                        $"return dto.{model.Name};\r\n    }}\r\n\r\n    protected override {model.Name}Dto FillEntity({model.Name}Dto dto, {model.Name}ModelDto  field)\r\n    {{\r\n        " +
                        $"dto.{model.Name} = field;\r\n\r\n        return dto;\r\n    }}" +
                        $"    protected override {model.Name}Dto FillEntity({model.Name}Dto dto, List<{model.Name}ModelDto> field)\r\n    {{\r\n        throw new NotImplementedException();\r\n    }}");

                    writer.WriteLine("}");


                }

            }
            else
            {
                outputPath += "I" + model.Name + "DtoLogic.cs";

                using (StreamWriter writer = new StreamWriter(outputPath, Encoding.UTF8, new FileStreamOptions() { Mode = FileMode.OpenOrCreate, Access = FileAccess.ReadWrite }))
                {
                    writer.WriteLine(usings + Environment.NewLine);
                    writer.WriteLine(nmSpace + Environment.NewLine);
                    writer.WriteLine($"   public interface I{model.Name}DtoLogic : IDtoLogicBase<{model.Name}ModelDto, {model.Name}, {model.Name}Dto, List<{model.Name}>, List<{model.Name}ModelDto>>\r\n    {{\r\n\r\n    }}");
                }
            }
        }
    }
}
