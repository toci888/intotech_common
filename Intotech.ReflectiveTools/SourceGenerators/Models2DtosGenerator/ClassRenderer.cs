using System.Reflection;
using System.Text;

namespace Intotech.ReflectiveTools.SourceGenerators.Models2DtosGenerator;

public class ClassRenderer : RenderersBase
{
    public virtual void RenderModelDtoClass(Type sourceClass, string outputPath, string usings, string nmSpace)
    {
        if (!sourceClass.FullName.Contains("Context"))
        {
            GenerateAndSaveClassBody(sourceClass, outputPath, usings, nmSpace);
        }
    }

    protected override void GenerateAndSaveClassBody(Type sourceClass, string outputPath, string usings, string nmSpace, RendererCustomData rendererCustomData = null)
    {
        PropertyInfo[] properties = sourceClass.GetProperties();

        outputPath += sourceClass.Name + "ModelDto.cs";

        using (StreamWriter writer = new StreamWriter(outputPath, Encoding.UTF8, new FileStreamOptions() { Mode = FileMode.OpenOrCreate, Access = FileAccess.ReadWrite }))
        {
            writer.WriteLine(usings + Environment.NewLine);
            writer.WriteLine(nmSpace + Environment.NewLine);
            writer.WriteLine($"public class {sourceClass.Name}ModelDto : DtoModelBase");
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

                typeName = ClassRendererPropertyTypeUtils.MapTypeName(typeName);

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