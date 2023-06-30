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
        public virtual void LoadAndReadAssembly(string modelPath, string outputPath, string usings, string nmSpace)
        {
            DtoLogicRenderer renderer = new ();

            Type[] model = Assembly.LoadFrom(modelPath).GetTypes();

            for (int i = 4; i < model.Length; i++)
            {
                if (model[i].Name != "<>c")
                {
                    renderer.RendererDtoLogic(model[i], outputPath, usings, nmSpace);
                }
                
            }

                

        }
    }
}
