using Intotech.ReflectiveTools.SourceGenerators.Models2DtosGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Intotech.ReflectiveTools.DtosLogicGenerator;

namespace Intotech.ReflectiveTools.SourceGenerators.LogicGenerator
{
    public class LogicRendererRunner
    {
        public static void LoadAndReadAssembly(string inputDllPath, string outputDirectory, string usings, string nmSpace, bool isInterfase)
        {
            DtoLogicRenderer logicRenderer = new DtoLogicRenderer();

            var types = Assembly.LoadFrom(inputDllPath).GetTypes();

            for (int i = 4; i < types.Length; i++)
            {
                LogicRenderer.RenderAutoProperties(types[i], outputDirectory, usings, nmSpace, isInterfase);
            }
              
        }
    }
}
