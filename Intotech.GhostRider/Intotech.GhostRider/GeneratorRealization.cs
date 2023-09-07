using Intotech.ReflectiveTools.DtosLogicGenerator;
using Intotech.ReflectiveTools.SourceGenerators.LogicGenerator;
using Intotech.ReflectiveTools.SourceGenerators.ModelManipulation;
using Intotech.ReflectiveTools.SourceGenerators.Models2DtosGenerator;
using Intotech.ReflectiveTools.SourceGenerators.ModelsToDtoGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.GhostRider
{
    public class GeneratorRealization
    {
        public virtual bool DtoRender(string inputDllPath, string outputDirectory, string usings, string nameSpace)
        {
            if (Directory.GetFiles(outputDirectory).Length == 0)
            {
                try
                {
                    DtoRendererRunner dtoRendererRunner = new();

                    dtoRendererRunner.LoadAndReadAssembly(inputDllPath, outputDirectory, usings, nameSpace);
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
                if (!FolderCleaner(outputDirectory))
                {
                    return false;
                }
                
                return true;
            }
        }
        public virtual bool ModelDtoRender(string inputDllPath, string outputDirectory, string usings, string nameSpace)
        {
            if (Directory.GetFiles(outputDirectory).Length == 0)
            {
                try
                {
                    ClassRendererRunner classRendererRunner = new();

                    classRendererRunner.LoadAndReadAssembly(inputDllPath, outputDirectory, usings, nameSpace);
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
        public virtual bool LogicRender(string inputDllPath, string outputDirectory, string usings, string nameSpace, List<string> dontDeleteFiles)
        {
            //if (Directory.GetFiles(outputDirectory).Length > 0)
            {
                try
                {
                    LogicRendererRunner logicRendererRunner = new();

                    logicRendererRunner.LoadAndReadAssembly(inputDllPath, outputDirectory, usings, nameSpace, false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw;
                }
                return false;
            }
            //else
            //{
            //    if (FolderCleaner(outputDirectory, dontDeleteFiles) == false)
            //    {
            //        return false;
            //    }
            //    return true;
            //}
        }
        public virtual bool ILogicRender(string inputDllPath, string outputDirectory, string usings, string nameSpace, List<string> dontDeleteFiles)
        {   
            if (Directory.GetFiles(outputDirectory).Length - dontDeleteFiles.Count() == 0)
            {
                try
                {
                    LogicRendererRunner logicRendererRunner = new();

                    logicRendererRunner.LoadAndReadAssembly(inputDllPath, outputDirectory, usings, nameSpace, true);
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
                if (FolderCleaner(outputDirectory, dontDeleteFiles) == false)
                {
                    return false;
                }
                return true;
            }
        }

        public virtual bool ILogicHandlerRender(string inputDllPath, string outputDirectory, string usings, string nameSpace, List<string> dontDeleteFiles)
        {
            if (Directory.GetFiles(outputDirectory).Length - dontDeleteFiles.Count() == 0)
            {
                try
                {
                    LogicRendererRunner logicRendererRunner = new();
                    // todo handlers
                    logicRendererRunner.LoadAndReadAssembly(inputDllPath, outputDirectory, usings, nameSpace, true, true);
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
                if (FolderCleaner(outputDirectory, dontDeleteFiles) == false)
                {
                    return false;
                }
                return true;
            }
        }

        public virtual bool DtoLogicRender(string modelPath, string outputDirectory, string usings, string nameSpace, bool isInterface)
        {
            if (Directory.GetFiles(outputDirectory).Length== 0)
            {
                try
                {
                    DtoLogicRendererRunner dtosRender = new();

                    dtosRender.LoadAndReadAssembly(modelPath, outputDirectory, usings, nameSpace, isInterface);
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

        public virtual bool MDManRender(string folderPath, string baseClass)
        {
            try
            {
                ModelDerivanceManipulator mdm = new ModelDerivanceManipulator();

                mdm.AddDerivanceToModels(folderPath, baseClass);

                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public virtual bool FolderCleaner(string outputDirectory, List<string> selectedObj = null)
        {

            DialogResult result = MessageBox.Show("There are objects in the folder, delete them?", "", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                
                DirectoryInfo directory = new DirectoryInfo(outputDirectory);

                foreach (FileInfo file in directory.GetFiles())
                {
                    if (selectedObj != null)
                    {
                        if (!selectedObj.Contains(file.Name))
                        {
                            file.Delete();
                        }
                    }
                    else
                    {
                        file.Delete();
                    }
                    
                    
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
