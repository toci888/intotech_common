namespace Intotech.ReflectiveTools.SourceGenerators.Models2DtosGenerator;

public static class ClassRendererPropertyTypeUtils
{
    private static Dictionary<string, string> TypesMap = new Dictionary<string, string>()
    {
        { "String", "string" },
        { "Int32", "int" },
    };

    public static string MapTypeName(string sourceType)
    {
        return TypesMap.ContainsKey(sourceType) ? TypesMap[sourceType] : sourceType;
    }
}