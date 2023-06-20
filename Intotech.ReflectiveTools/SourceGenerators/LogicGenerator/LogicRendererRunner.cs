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
        public static void LoadAndReadAssembly(string mainFolderName, string outputDirectory, string usings, string nmSpace, bool isInterfase)
        {
            DtoLogicRenderer logicRenderer = new DtoLogicRenderer();

            var mainFolderPath = logicRenderer.GetMainPath(mainFolderName);

            var path = mainFolderPath +"\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Toci.Driver.Database.Persistence\\bin\\Debug\\net7.0\\Toci.Driver.Database.Persistence.dll";

            Assembly assembly = Assembly.LoadFrom(path);

            Type[] types = assembly.GetTypes();

            for (int i = 4; i < types.Length; i++)
            {
                LogicRenderer.RenderAutoProperties(types[i], outputDirectory, usings, nmSpace, isInterfase);
            }
               
            

           
        }
    }
}
