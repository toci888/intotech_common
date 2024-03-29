﻿using Intotech.ReflectiveTools.SourceGenerators.Models2DtosGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Intotech.ReflectiveTools.DtosLogicGenerator;

namespace Intotech.ReflectiveTools.SourceGenerators.LogicGenerator
{
    public class LogicRendererRunner
    {
        protected List<string> Excluded = new() { "<>c", "Context", "Attribute" };
        public virtual void LoadAndReadAssembly(string inputDllPath, string outputDirectory, string usings, string nmSpace, bool isInterfase)
        {
            var types = Assembly.LoadFrom(inputDllPath).GetTypes();

            for (int i = 0; i < types.Length; i++)
            {
                if (!Excluded.Any(n => types[i].Name.Contains(n)))
                {
                    LogicRenderer logicRenderer = new();

                    logicRenderer.RenderAutoProperties(types[i], outputDirectory, usings, nmSpace, isInterfase);
                }
            }
              
        }
    }
}
