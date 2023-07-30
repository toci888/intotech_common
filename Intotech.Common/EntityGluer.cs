using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common
{
    public static class EntityGluer
    {
        /*
         Account

        1. Id: 123
        2. Email: "kac..."
        3. AccountDto: { Id: 2
        }

         * */
        public static List<string> GlueEntity(object entity)
        {
            
            List<string> result = new List<string>();
            int iterator = 1;

            if (entity == default) { result.Add("null"); return result; }

            PropertyInfo[] properties = entity.GetType().GetProperties();  
            
            result.Add(entity.GetType().Name);

            foreach (PropertyInfo property in properties) // if type string int bool AccountDto -> GlueEntity
            {
                var name = property.PropertyType;

                if (!property.PropertyType.Name.Contains("ICollection"))
                {
                    if (IsPrimitiveOrNullablePrimitive(property.PropertyType) || property.PropertyType == typeof(string))
                    {
                        object val = property.GetValue(entity, null);

                        if (val != default)
                        {
                            val.ToString();
                        }

                        result.Add($" {iterator++}. {property.Name}: {val}");
                    }
                    else
                    {
                        object val = property.GetValue(entity, null);
                        result.Add($" {iterator++}. {property.Name}: {{{string.Join(", ", GlueEntity(val))}}}");
                    }
                }
                
            }
           
            return result;
        }

        static bool IsPrimitiveOrNullablePrimitive(Type type)
        {
            if (type.IsPrimitive || type == typeof(DateTime))
            {
                return true;
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                Type underlyingType = Nullable.GetUnderlyingType(type);

                if (underlyingType != null && (underlyingType.IsPrimitive || underlyingType == typeof(DateTime)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
