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

            PropertyInfo[] properties = entity.GetType().GetProperties();   

            foreach (PropertyInfo property in properties) // if type string int bool AccountDto -> GlueEntity
            {
                string val = property.GetValue(entity, null).ToString();

                result.Add($"{property.Name}: ${val}");
            }

            return result;
        }
    }
}
