using System.Text;

namespace Intotech.ReflectiveTools.SourceGenerators.StandardControllerGenerator
{
    public class ControllerRenderer
    {
        public virtual void RenderController(Type model, string outputPath, string usings, string nmSpace)
        {
            if (!model.FullName.Contains("Context"))
            {
                outputPath += model.Name + "Controller.cs";

                using (StreamWriter writer = new StreamWriter(outputPath, Encoding.UTF8, new FileStreamOptions() { Mode = FileMode.OpenOrCreate, Access = FileAccess.ReadWrite }))
                {
                    writer.WriteLine(usings);
                    writer.WriteLine("using Intotech.Common.Bll.Interfaces.ComplexResponses;\r\nusing Intotech.Common.Microservices;\r\nusing Intotech.Wheelo.Common;\r\nusing Microsoft.AspNetCore.Mvc;" + Environment.NewLine);
                    writer.WriteLine(nmSpace + Environment.NewLine);
                        
                    writer.WriteLine("[ApiController]");
                    writer.WriteLine("[Route(\"api/[controller]\")]");

                    writer.WriteLine($"public class {model.Name}Controller : WheeloApiSimpleControllerBase<I{model.Name}Manager>");
                    writer.WriteLine("{");

                    writer.WriteLine($"\tpublic {model.Name}Controller(I{model.Name}Manager logic, IHttpContextAccessor httpContextAccessor) : base(logic, httpContextAccessor)\r\n\t\t{{\r\n\t\t}}");

                    writer.WriteLine("}");


                }
            }          
        }
    }
}
