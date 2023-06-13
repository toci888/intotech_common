using System.Reflection;

namespace Intotech.ReflectiveTools.SourceGenerators.Models2DtosGenerator;

public class ClassRendererRunner
{
    public static void LoadAndReadAssembly(string assemblyPath, string outputDirectory, string usings, string nmSpace)
    {
        Assembly assembly = Assembly.LoadFrom(assemblyPath);

        Type[] types = assembly.GetTypes();

        foreach (Type type in types)
        {
            ClassRenderer.RenderAutoProperties(type, outputDirectory, usings, nmSpace);
        }
    }
}