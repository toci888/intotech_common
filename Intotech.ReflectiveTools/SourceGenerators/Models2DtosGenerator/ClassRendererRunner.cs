using System.Reflection;

namespace Intotech.ReflectiveTools.SourceGenerators.Models2DtosGenerator;

public class ClassRendererRunner
{
    protected List<string> Excluded = new() { "<>c", "Context", "Attribute" };
    public virtual void LoadAndReadAssembly(string assemblyPath, string outputDirectory, string usings, string nmSpace)
    {
        Assembly assembly = Assembly.LoadFrom(assemblyPath);

        Type[] types = assembly.GetTypes();

        for (int i = 0; i < types.Length; i++)
        {
            if (!Excluded.Any(n => types[i].Name.Contains(n)))
            {
                ClassRenderer classRenderer = new();

                classRenderer.RenderModelDtoClass(types[i], outputDirectory, usings, nmSpace);
            }
        }
            
        
    }
}