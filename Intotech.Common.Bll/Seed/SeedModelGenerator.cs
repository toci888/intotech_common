using Intotech.Common.Bll.Interfaces.Seed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Bll.Seed
{
    public class SeedModelGenerator : ISeedModelGenerator
    {
        public virtual void GenerateFiles(string path, string destPath, string namespaceSeed, string namespaceUsing, string seedBase)
        {
            string[] files = Directory.GetFiles(path);
            string template = File.ReadAllText(@"C:\Users\bzapa\source\repos\toci888\Intotech.Common\Intotech.Common.Bll\Seed\SeedModelTemplate.txt");

            foreach (string file in files)
            {
                string[] elements = file.Split(new string[] { "\\" }, StringSplitOptions.None);

                string item = elements[elements.Length - 1];

                string modelName = item.Replace(".cs", "");

                string templatePopulated = template
                    .Replace("{TModel}", modelName)
                    .Replace("{Namespace}", namespaceSeed)
                    .Replace("{UsingNamespace}", namespaceUsing)
                    .Replace("{SeedBase}", seedBase);

                File.WriteAllText(destPath + item, templatePopulated);
            }
        }
    }
}
