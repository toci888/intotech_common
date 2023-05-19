namespace Intotech.Common;

public class FileUtils
{
    public static string GetTextFromFile(string path)
    {
        try
        {
            return File.ReadAllText(path);
        }
        catch (FileNotFoundException)
        {
            return string.Empty;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            return string.Empty;
        }
    }

    public static string[] GetLinesFromFile(string path)
    {
        try
        {
            return File.ReadAllLines(path);
        }
        catch (FileNotFoundException)
        {
            return Array.Empty<string>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            return Array.Empty<string>();
        }
    }
}
