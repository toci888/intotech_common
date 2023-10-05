using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Http
{
    public class AttributeDto
    {
        public string Method { get; set; }
        public string Route { get; set; }
    }

    public static class HttpAttributesParser
    {
        private static Dictionary<string, Type> ParseAttributesMap = new Dictionary<string, Type>()
        {
            { "Get", typeof(HttpGetAttribute) },
            { "Post", typeof(HttpPostAttribute) },
            { "Put", typeof(HttpPutAttribute) },
            { "Delete", typeof(HttpDeleteAttribute) },
            { "Patch", typeof(HttpPatchAttribute) },
        };



        public static AttributeDto GetHttpAttributeData(Attribute httpAttributeCandidate)
        {
            AttributeDto result = new AttributeDto();

            foreach (KeyValuePair<string, Type> item in ParseAttributesMap)
            {
                if (httpAttributeCandidate.GetType().FullName == item.Value.FullName)
                {
                    //HttpMethodAttribute hma = (HttpMethodAttribute)Convert.ChangeType(httpAttributeCandidate, item.Value);

                    result.Method = item.Key;

                    result.Route = GetTemplateFromAttribute(httpAttributeCandidate);

                    break;
                }
            }

            return result;
        }

        public static string GetTemplateFromAttribute(Attribute httpAttributeCandidate)
        {
            //HttpGetAttribute httpGetAttribute = httpAttributeCandidate as Microsoft.AspNetCore.Mvc.HttpGetAttribute;

            object? routePropValue = httpAttributeCandidate.GetType().GetProperty("Template").GetValue(httpAttributeCandidate, null);

            if (routePropValue != null)
            {
                return routePropValue.ToString();
            }

            return string.Empty;
        }
    }
}
