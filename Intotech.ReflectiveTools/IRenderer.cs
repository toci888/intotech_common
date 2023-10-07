using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.ReflectiveTools
{
    public interface IRenderer
    {
        public void GenerateInterfaceBodyAndSave(Type sourceClass, string outputPath, string usings, string nmSpace);
        public void GenerateClassBodyAndSave(Type sourceClass, string outputPath, string usings, string nmSpace);
    }
}
