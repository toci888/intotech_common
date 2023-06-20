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
        public static void LoadAndReadAssembly(string mainFolderName, string outputDirectory, string usings, string nmSpace)
        {
            DtoLogicRenderer logicRenderer = new DtoLogicRenderer();

            var mainFolderPath = logicRenderer.GetMainPath(mainFolderName);

            var path = mainFolderPath + "\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Toci.Driver.Database.Persistence\\bin\\Debug\\net7.0\\Toci.Driver.Database.Persistence.dll";

            Assembly assembly = Assembly.LoadFrom(path);

            Type[] types = assembly.GetTypes();

            for (int i = 4; i < types.Length; i++)
            {
                DtoRenderer.RenderAutoProperties(types[i], outputDirectory, usings, nmSpace);
            }
        }
    }
}
