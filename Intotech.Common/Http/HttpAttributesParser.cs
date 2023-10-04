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
                if (httpAttributeCandidate.GetType() == item.Value)
                {
                    HttpMethodAttribute hma = (HttpMethodAttribute)Convert.ChangeType(httpAttributeCandidate, item.Value);

                    result.Method = item.Key;
                    result.Route = hma.Template;

                    break;
                }
            }

            return result;
        }
    }
}
