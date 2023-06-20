using System.Text.RegularExpressions;

namespace Intotech.ReflectiveTools.SourceGenerators.ModelManipulation;

public class ModelDerivanceManipulator
{
    public virtual void AddDerivanceToModels(string path, string baseClassName)
    {
        List<string> files = Directory.GetFiles(path).ToList();

        foreach (string file in files)
        {
            if (!file.Contains("Context"))
            {
                string fileContents = File.ReadAllText(file);

                string pattern = @"class\s+(\w+)"; // Regular expression pattern to match "class AnyClassName"
                string replacement = "class $1 : " + baseClassName; // Replacement pattern to add the derivation

                string result = Regex.Replace(fileContents, pattern, replacement);

                File.WriteAllText(file, result);
            }
        }
    }
}