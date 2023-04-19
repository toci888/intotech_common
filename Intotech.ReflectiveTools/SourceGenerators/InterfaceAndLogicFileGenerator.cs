﻿using System;
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
            string addScopedCode = string.Empty;

            if (interf)
            {
                interfaceSkeleton = File.ReadAllText(@"C:\Dev\Intotech.Xerion\Backend\Intotech.Common\Intotech.ReflectiveTools\SourceGenerators\InterfaceSkeleton.txt");
            }
            else
            {
                interfaceSkeleton = File.ReadAllText(@"C:\Dev\Intotech.Xerion\Backend\toci888\Intotech.Common\Intotech.ReflectiveTools\SourceGenerators\LogicSkeleton.txt");
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

                addScopedCode += "builder.Services.AddScoped<I" + fileModel + "Logic, " + fileModel + "Logic>();" + Environment.NewLine;
            }

            if (!File.Exists(destDirectory + "/scopes.txt"))
            {
                File.WriteAllText(destDirectory + "/scopes.txt", addScopedCode);
            }
        }
    }
}
