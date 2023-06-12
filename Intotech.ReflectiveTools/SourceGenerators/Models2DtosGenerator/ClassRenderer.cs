using System.Reflection;

namespace Intotech.ReflectiveTools.SourceGenerators.Models2DtosGenerator;

public class ClassRenderer
{
    public static void RenderAutoProperties(Type sourceClass, string outputPath)
    {
        if (!sourceClass.FullName.Contains("Context"))
        {
            PropertyInfo[] properties = sourceClass.GetProperties();

            outputPath += sourceClass.Name + "ModelDto.cs";

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.WriteLine($"public class {sourceClass.Name}ModelDto");
                writer.WriteLine("{");

                foreach (PropertyInfo property in properties)
                {
                    Type propertyType = property.PropertyType;
                    Type underlyingType = Nullable.GetUnderlyingType(propertyType);

                    string typeName = string.Empty;

                    if (underlyingType != null)
                    {
                        typeName = underlyingType.Name;
                    }
                    else
                    {
                        typeName = propertyType.Name;
                    }

                    if (!property.Name.Contains("Navigation"))
                    {
                        if (!typeName.Contains("ICollection"))
                        {
                            writer.WriteLine($"    public {typeName} {property.Name} {{ get; set; }}");
                        }
                    }
                }

                writer.WriteLine("}");
            }
        }
    }
}