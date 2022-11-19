using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TypeLite;
using TypeLite.TsModels;

namespace Intotech.ReflectiveTools.SourceGenerators.ModelsToTypescript
{
    public class TypeScriptGenerator
    {
        public void GenerateTsModels(Assembly asembly)
        {
            //TypeScript.Definitions().Generate();

            TsGenerator tsg = new TsGenerator();

            List<Type> types = asembly.GetTypes().ToList();
            List< TsClass > typesList = new List< TsClass >();

            foreach (Type type in types)
            {
                typesList.Add(new TsClass(type));
            }

            //List<TsModel> tsModels = new List<TsModel>();

            TsModel tsModel = new TsModel(typesList);

            string result = tsg.Generate(tsModel, TsGeneratorOutput.Properties);
        }
    }
}
