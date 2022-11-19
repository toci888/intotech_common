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
        protected Dictionary<string, string> TypesMap = new Dictionary<string, string>()
        {
            { "Int32", "number" },
            { "String", "string" },

        };

        protected List<string> skip = new List<string>()
        {
            "Navigation"
        };

        public void Generate(Assembly assembly)
        {
            List<Type> types = assembly.GetTypes().ToList();

            foreach (Type type in types)
            {
                string json = string.Empty;

                List<PropertyInfo> properties = type.GetProperties().ToList();

                foreach (PropertyInfo property in properties)
                { //Id!: number;
                    if (!NameContains(property.Name))
                    {
                        string mappedType = GetTypeName(property.PropertyType.ToString());  //  TypesMap.Where(map => property.PropertyType.ToString().Contains(map.Key) ? map.Value : string.Empty)

                        if (!string.IsNullOrEmpty(mappedType))
                        {
                            json += property.Name + "!: " + mappedType + "; " + Environment.NewLine;
                        }
                    }
                }

                string final = "export class " + type.Name + " {" + Environment.NewLine + json + Environment.NewLine + "}";
                File.WriteAllText(@"C:\Users\bzapa\source\repos\toci888\intotech_wheelo\reflective\" + type.Name + ".ts", final);
            }
        }

        protected virtual bool NameContains(string name)
        {
            return skip.Where(x => name.Contains(x)).Any();
        }

        protected virtual string GetTypeName(string type)
        {
            foreach (KeyValuePair<string, string> map in TypesMap)
            {
                if (type.Contains(map.Key))
                {
                    return map.Value;
                }
            }

            return string.Empty;
        }
    }
}
