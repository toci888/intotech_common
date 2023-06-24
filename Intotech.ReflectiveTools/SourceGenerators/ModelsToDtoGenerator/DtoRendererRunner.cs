using Intotech.ReflectiveTools.DtosLogicGenerator;
using Intotech.ReflectiveTools.SourceGenerators.LogicGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.ReflectiveTools.SourceGenerators.ModelsToDtoGenerator
{
    public class DtoRendererRunner
    {
        public virtual void LoadAndReadAssembly(string inputDllPath, string outputDirectory, string usings, string nmSpace)
        {
            var  types = Assembly.LoadFrom(inputDllPath).GetTypes();

            for (int i = 4; i < types.Length; i++)
            {
                DtoRenderer dtoRenderer = new();

                dtoRenderer.RenderAutoProperties(types[i], outputDirectory, usings, nmSpace);
            }
        }
    }
}
