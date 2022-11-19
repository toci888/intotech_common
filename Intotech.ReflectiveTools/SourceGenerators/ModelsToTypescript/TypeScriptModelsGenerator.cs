using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.ReflectiveTools.SourceGenerators.ModelsToTypescript
{
    public class TypeScriptModelsGenerator
    {
        public void Generate(Assembly assembly)
        {
            List<Type> types = assembly.GetTypes().ToList();

            foreach (Type type in types)
            {
                string json = string.Empty;

                List<PropertyInfo> properties = type.GetProperties().ToList();

                foreach (PropertyInfo property in properties)
                { //Id!: number;
                    json += property.Name + "!: " + property.PropertyType + "; " + Environment.NewLine;
                }

                string final = "export class " + type.Name + " {" + Environment.NewLine + json + Environment.NewLine + "}";
                File.WriteAllText(@"C:\Users\bzapa\source\repos\toci888\intotech_wheelo\reflective\" + type.Name + ".ts", final);
            }
        }
    }
}
