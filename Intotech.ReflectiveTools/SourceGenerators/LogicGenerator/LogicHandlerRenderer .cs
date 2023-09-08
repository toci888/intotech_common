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

                    outputPath += "Dto" + sourceClass.Name + "LogicHandler.cs";

                    /*public class DtoClientLogicHandler : DtoLogicHandlerBase<ClientDtoLogic, ClientDto, ClientModelDto, Client, IClientLogic, List<Client>, List<ClientModelDto>>, IDtoClientLogicHandler
                    {
                        public DtoClientLogicHandler(ClientDtoLogic dtoLogic,
                            DtoLogicHandlerBase<ClientDtoLogic, ClientDto, ClientModelDto, Client, IClientLogic, List<Client>, List<ClientModelDto>> children = null) : base(dtoLogic, children)
                        {
                        }
                    }*/

                    using (StreamWriter writer = new StreamWriter(outputPath, Encoding.UTF8, new FileStreamOptions() { Mode = FileMode.OpenOrCreate, Access = FileAccess.ReadWrite }))
                    {
                        writer.WriteLine(usings + Environment.NewLine);
                        writer.WriteLine(nmSpace + Environment.NewLine);
                        writer.WriteLine($"public class Dto{sourceClass.Name}LogicHandler : DtoLogicHandlerBase<{sourceClass.Name}DtoLogic, {sourceClass.Name}Dto, {sourceClass.Name}ModelDto, {sourceClass.Name}, I{sourceClass.Name}Logic, List<{sourceClass.Name}>, List<{sourceClass.Name}ModelDto>>, IDto{sourceClass.Name}LogicHandler");
                        writer.WriteLine("{");
                        writer.WriteLine($"public Dto{sourceClass.Name}LogicHandler({sourceClass.Name}DtoLogic dtoLogic," +
                            $"\r\n\t\t\tDtoLogicHandlerBase<{sourceClass.Name}DtoLogic, {sourceClass.Name}Dto, {sourceClass.Name}ModelDto, {sourceClass.Name}, I{sourceClass.Name}Logic, List<{sourceClass.Name}>, List<{sourceClass.Name}ModelDto>> children = null) : base(dtoLogic, children)\r\n                        {{\r\n                        }}");
                        
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
