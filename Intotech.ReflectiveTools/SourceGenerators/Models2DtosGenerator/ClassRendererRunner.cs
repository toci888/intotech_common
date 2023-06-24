using System.Reflection;

namespace Intotech.ReflectiveTools.SourceGenerators.Models2DtosGenerator;

public class ClassRendererRunner
{
    public virtual void LoadAndReadAssembly(string assemblyPath, string outputDirectory, string usings, string nmSpace)
    {
        Assembly assembly = Assembly.LoadFrom(assemblyPath);

        Type[] types = assembly.GetTypes();

        for (int i = 4; i < types.Length; i++)
        {
            ClassRenderer classRenderer = new();

            classRenderer.RenderAutoProperties(types[i], outputDirectory, usings, nmSpace);
        }
            
        
    }
}