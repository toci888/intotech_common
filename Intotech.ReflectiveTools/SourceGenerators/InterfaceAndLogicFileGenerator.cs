using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.ReflectiveTools.SourceGenerators
{
    public class InterfaceAndLogicFileGenerator
    {
        public virtual void GenerateCodeFiles(string destDirectory, List<string> models, GeneratedFileDto gfDto, bool interf = true)
        {
            //DirectoryInfo dirInfo = new DirectoryInfo(destDirectory);

            string interfaceSkeleton = string.Empty;

            if (interf)
            {
                interfaceSkeleton = File.ReadAllText(@"C:\Users\bzapa\source\repos\toci888\Intotech.Common\Intotech.ReflectiveTools\SourceGenerators\InterfaceSkeleton.txt");
            }
            else
            {
                interfaceSkeleton = File.ReadAllText(@"C:\Users\bzapa\source\repos\toci888\Intotech.Common\Intotech.ReflectiveTools\SourceGenerators\LogicSkeleton.txt");
            }

            interfaceSkeleton = interfaceSkeleton.Replace("{ModelPersistenceUsingEx}", gfDto.ModelPersistenceUsing)
                .Replace("{KeyNamespaceEx}", gfDto.KeyNamespace);
            //.Replace("{FileNameEx}", )

            foreach (string fileModel in models)
            {
                string interfaceGen = interfaceSkeleton.Replace("{FileNameEx}", fileModel);

                if (interf)
                {
                    File.WriteAllText(destDirectory + "/" + "I" + fileModel + "Logic.cs", interfaceGen);
                }
                else
                {
                    File.WriteAllText(destDirectory + "/" + fileModel + "Logic.cs", interfaceGen);
                }
            }
        }
    }
}
