using Intotech.ReflectiveTools.SourceGenerators.Models2DtosGenerator;
using Intotech.ReflectiveTools.SourceGenerators.ModelsToDtoGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.GhostRider
{
    internal class GeneratorRealization
    {
        public bool DtoRender(string inputDllPath, string outputDirectory, string usings, string nameSpace)
        {
            if (Directory.GetFiles(outputDirectory).Length == 0)
            {
                try
                {
                    DtoRendererRunner.LoadAndReadAssembly(inputDllPath, outputDirectory, usings, nameSpace);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw;
                }
                return false;
            }
            else
            {
                if (FolderCleaner(outputDirectory) == false)
                {
                    return false;
                }
                
                
                return true;
            }
        }
        public bool ModelDtoRender(string inputDllPath, string outputDirectory, string usings, string nameSpace)
        {
            if (Directory.GetFiles(outputDirectory).Length == 0)
            {
                try
                {
                    ClassRendererRunner.LoadAndReadAssembly(inputDllPath, outputDirectory, usings, nameSpace);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw;
                }
                return false;
            }
            else
            {
                if (FolderCleaner(outputDirectory) == false)
                {
                    return false;
                }


                return true;
            }
        }
        public static bool FolderCleaner(string outputDirectory)
        {

            DialogResult result = MessageBox.Show("There are objects in the folder, delete them?", "", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                DirectoryInfo directory = new DirectoryInfo(outputDirectory);

                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }

                Console.WriteLine($"Files in path {outputDirectory}, deleted.");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
