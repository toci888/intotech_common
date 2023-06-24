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
        public virtual void LoadAndReadAssembly(string mainFolderPath, string outputPath, string usings, string nmSpace)
        {
            DtoLogicRenderer renderer = new ();


            string modelsDllPath = "\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Toci.Driver.Database.Persistence\\bin\\Debug\\net7.0\\Toci.Driver.Database.Persistence.dll";
            string modelsDtosDllPath = "\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Intotech.Wheelo.Bll.Models\\bin\\Debug\\net7.0\\Intotech.Wheelo.Bll.Models.dll";
            string logicDllPath = "\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Intotech.Wheelo.Bll.Persistence\\bin\\Debug\\net7.0\\Intotech.Wheelo.Bll.Persistence.dll";
            string dtosDllPath = "\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Intotech.Wheelo.Bll.Models\\bin\\Debug\\net7.0\\Intotech.Wheelo.Bll.Models.dll";

            List<string> paths = new List<string>();

            
            paths.Add(modelsDtosDllPath);
            paths.Add(logicDllPath);
            paths.Add(dtosDllPath);

            List<Type[]> allTypes = new ();
           
            for (int i = 0; i < paths.Count(); i++)
            {
                Type? [] singleTypes = Assembly.LoadFrom(mainFolderPath + paths[i]).GetTypes();
                allTypes.Add(singleTypes);
            }


            var models = Assembly.LoadFrom(mainFolderPath + modelsDllPath).GetTypes();

            for (int i = 4; i < models.Length; i++)
            {
                var keyName = models[i].Name;

                if (keyName != "IntotechWheeloContext" && keyName !="<>c")
                {
                    var types = renderer.GetRightTypes(keyName, allTypes);

                    types.Add(models[i]);

                    renderer.RendererDtoLogic(types, outputPath, usings, nmSpace);
                }



            }

                

        }
    }
}
