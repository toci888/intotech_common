﻿using Intotech.ReflectiveTools.SourceGenerators.LogicGenerator;
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
        public bool LogicRender(string inputDllPath, string outputDirectory, string usings, string nameSpace)
        {
            List<string> selectedObj = new() { "Intotech.Wheelo.Bll.Persistence.csproj", "Logic.cs" };

            if (Directory.GetFiles(outputDirectory).Length - selectedObj.Count() == 0)
            {
                try
                {
                    LogicRendererRunner.LoadAndReadAssembly(inputDllPath, outputDirectory, usings, nameSpace, false);
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
                

                if (FolderCleaner(outputDirectory, selectedObj) == false)
                {
                    return false;
                }


                return true;
            }
        }
        public bool ILogicRender(string inputDllPath, string outputDirectory, string usings, string nameSpace)
        {
            List<string> selectedObj = new() { "Intotech.Wheelo.Bll.Persistence.Interfaces.csproj", "AccountLogicConstants.cs" };
            
            if (Directory.GetFiles(outputDirectory).Length - selectedObj.Count() == 0)
            {
                try
                {
                    LogicRendererRunner.LoadAndReadAssembly(inputDllPath, outputDirectory, usings, nameSpace, true);
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
                if (FolderCleaner(outputDirectory, selectedObj) == false)
                {
                    return false;
                }


                return true;
            }
        }

        public static bool FolderCleaner(string outputDirectory, List<string> selectedObj = null)
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