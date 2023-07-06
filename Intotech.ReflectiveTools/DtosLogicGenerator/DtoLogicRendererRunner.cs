using Intotech.ReflectiveTools.SourceGenerators.Models2DtosGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Intotech.ReflectiveTools.DtosLogicGenerator;

namespace Intotech.ReflectiveTools.DtosLogicGenerator
{
    public class DtoLogicRendererRunner
    {
        protected List<string> Excluded = new() {"<>c", "Context","Attribute"};
        public virtual void LoadAndReadAssembly(string modelPath, string outputPath, string usings, string nmSpace, bool isInterface)
        {
            DtoLogicRenderer renderer = new ();

            Type[] model = Assembly.LoadFrom(modelPath).GetTypes();

            for (int i = 0; i < model.Length; i++)
            {
                if (!Excluded.Any(n=> model[i].Name.Contains(n)))
                {
                    renderer.RendererDtoLogic(model[i], outputPath, usings, nmSpace, isInterface);
                }
                
            }

                

        }
    }
}
