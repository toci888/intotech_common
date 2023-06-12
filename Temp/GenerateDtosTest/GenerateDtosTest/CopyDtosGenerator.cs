using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace GenerateDtosTest
{
    internal class CopyDtosGenerator : CopyModelGeterator
    {
        internal bool isGenerated;
        internal bool GenerateFromPersistance(string solutionSourcePath, string projectNameSource, string solutionDestinationPath , string? sufixNewClass)
        {
            // Otrzymanie dll z którego będziemy kopiować 

            string assemblyPath = $"{solutionSourcePath}\\{projectNameSource}\\bin\\Debug\\net7.0\\{projectNameSource}.dll";
            
            Assembly assembly;
            try
            {
                assembly = Assembly.LoadFrom(assemblyPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }



            // Generowanie klas


            if (assembly != null)
            {
                CopyModelGeterator.ClearFolder(solutionDestinationPath);

                foreach (var exportedType in assembly.ExportedTypes)
                {
                    CopyModelGeterator.GenerateNewClass(solutionDestinationPath, exportedType, sufixNewClass);
                }
                 return isGenerated = true;
            }
            

            return isGenerated;


        }
    }
}
