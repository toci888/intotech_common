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
        public virtual void RendererDtoLogic(List<Type?> inputTypes, string outputPath, string usings, string nmSpace)
        {
           
           
                var modelsDtosTypes = inputTypes[0];
                var logicType = inputTypes[1];
                var dtoType = inputTypes[2];
                var model = inputTypes[3];

                outputPath += model.Name + "DtoLogic.cs";

                using (StreamWriter writer = new StreamWriter(outputPath, Encoding.UTF8, new FileStreamOptions() { Mode = FileMode.OpenOrCreate, Access = FileAccess.ReadWrite }))
                {
                    writer.WriteLine(usings + Environment.NewLine);
                    writer.WriteLine(nmSpace + Environment.NewLine);
                    writer.WriteLine($"public class {model.Name}DtoLogic : DtoLogicBase<{modelsDtosTypes.Name}, {model.Name}, I{logicType.Name}, {dtoType.Name}, List<{model.Name}>, List<{modelsDtosTypes.Name}>>");
                    writer.WriteLine("{");

                        writer.WriteLine($"    public {model.Name}DtoLogic(I{logicType.Name} {logicType.Name.ToLower()}) \r\n        " +
                            $": base({logicType.Name.ToLower()}, m => m.Id == id, \r\n            " +
                            $"(aDto, aModelDto) => {{ \r\n                " +
                            $"aDto.{model.Name} = aModelDto;\r\n                " +
                            $"return aDto;\r\n            }})\r\n    {{\r\n    }}\r\n\r\n    " +
                            $"protected override DtoBase<{model.Name},{dtoType.Name}> GetDtoModelField({model.Name}Dto dto)\r\n    {{\r\n       " +
                            $"return dto.{model.Name};\r\n    }}\r\n\r\n    protected override {model.Name}Dto FillEntity({model.Name}Dto dto, DtoBase<{model.Name}> field)\r\n    {{\r\n        " +
                            $"dto.{model.Name} = ({model.Name}ModelDto)field;\r\n\r\n        return dto;\r\n    }}");

                    writer.WriteLine("}");

               
                }
        }

        public List<Type?> GetRightTypes(string keyName, List<Type[]> allTypes)
        {

            List<Type> sortedTypes = new();

            var modelsDtosTypes = allTypes[0];
            var logicTypes = allTypes[1];
            var dtosTypes = allTypes[2];

            var modeldto = modelsDtosTypes.FirstOrDefault(t => t.Name.Contains(keyName + "ModelDto"));
            var logic = logicTypes.FirstOrDefault(t => t.Name.Contains(keyName + "Logic"));
            var dto = dtosTypes.FirstOrDefault(t => t.Name.Contains(keyName + "Dto"));

            sortedTypes.Add(modeldto);
            sortedTypes.Add(logic);
            sortedTypes.Add(dto);
                
            return sortedTypes;
            
        }
    }
}
