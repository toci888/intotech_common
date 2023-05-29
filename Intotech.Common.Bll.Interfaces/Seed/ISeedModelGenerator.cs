using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Bll.Interfaces.Seed
{
    public interface ISeedModelGenerator
    {
        void GenerateFiles(string path, string destPath, string namespaceSeed, string namespaceUsing, string seedBase);
    }
}
