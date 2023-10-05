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
        protected List<string> Excluded = new() { "<>c", "Context", "Attribute" };
        public virtual void LoadAndReadAssembly(string inputDllPath, string outputDirectory, string usings, string nmSpace)
        {
            var  types = Assembly.LoadFrom(inputDllPath).GetTypes();

            for (int i = 0; i < types.Length; i++)
            {
                if (!Excluded.Any(n => types[i].Name.Contains(n)))
                {
                    DtoRenderer dtoRenderer = new();

                    dtoRenderer.RenderDtoClass(types[i], outputDirectory, usings, nmSpace);
                }
            }
        }
    }
}
