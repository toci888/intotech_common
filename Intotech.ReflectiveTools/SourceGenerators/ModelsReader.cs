using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.ReflectiveTools.SourceGenerators
{
    public static class ModelsReader
    {
        public static List<string> ReadAllModelsNames(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);

            List<FileInfo> files = directory.EnumerateFiles().ToList();

            return files.Select(f => f.Name.Replace(".cs", string.Empty)).ToList();
        }
    }
}
