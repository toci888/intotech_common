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

         * */
        public static List<string> GlueEntitiy(object entity)
        {
            List<string> result = new List<string>();

            PropertyInfo[] properties = entity.GetType().GetProperties();   

            foreach (PropertyInfo property in properties)
            {
                string val = property.GetValue(entity, null).ToString();

                result.Add($"{property.Name}: ${val}");
            }

            return result;
        }
    }
}
