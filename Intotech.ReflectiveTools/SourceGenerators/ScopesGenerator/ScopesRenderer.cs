

namespace Intotech.ReflectiveTools.SourceGenerators.ScopesGenerator
{
    public class ScopesRenderer
    {
        public virtual void RenderAutoProperties(Type sourceClass, string outputPath)
        {
            string text = $"builder.Services.AddScoped<I{sourceClass.Name}DtoLogic, {sourceClass.Name}DtoLogic>();\n";

            outputPath += "Scopes.txt";

            if (!File.Exists(outputPath))
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(outputPath))
                    {
                        sw.Write(text);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while creating the file: " + ex.Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(outputPath))
                {
                    sw.Write(text);
                }
            }

        }
    }
}
