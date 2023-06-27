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
        public virtual void LoadAndReadAssembly(List<string> paths, string outputPath, string usings, string nmSpace)
        {
            DtoLogicRenderer renderer = new ();

            List<Type[]> allTypes = new ();
           
            for (int i = 1; i < paths.Count() - 1 ; i++)
            {
                Type? [] singleTypes = Assembly.LoadFrom(paths[i]).GetTypes();
                allTypes.Add(singleTypes);
            }


            var models = Assembly.LoadFrom(paths[0]).GetTypes();

            for (int i = 4; i < models.Length; i++)
            {
                var keyName = models[i].Name;

                if (keyName != "" && keyName !="<>c")
                {
                    var types = renderer.GetRightTypes(keyName, allTypes);

                    types.Add(models[i]);

                    renderer.RendererDtoLogic(types, outputPath, usings, nmSpace);
                }



            }

                

        }
    }
}
