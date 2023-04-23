using System.Diagnostics;

namespace Intotech.Common.Database.DbSetup;

public class DbScaffoldManager
{
    private string _connectionString;
    private string _projectName;
    private string _parentProjectFolderPath;

    public DbScaffoldManager(string connectionString, string projectName, string parentProjectFolderPath)
    {
        _connectionString = connectionString;
        _projectName = projectName;
        _parentProjectFolderPath = parentProjectFolderPath;
    }

    public void RunScaffold()
    {
        string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string workingDirectory = Path.Combine(solutionDirectory, _parentProjectFolderPath);

        var arguments = $"ef dbcontext scaffold \"{_connectionString}\" Npgsql.EntityFrameworkCore.PostgreSQL -o Models --project {_projectName} -f";
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = workingDirectory
            }
        };
        process.Start();
        process.WaitForExit();

        if (process.ExitCode != 0)
        {
            string errorOutput = process.StandardError.ReadToEnd();
            Console.WriteLine($"Error: {errorOutput}");
        }
        else
        {
            Console.WriteLine("Models generated successfully.");
        }
    }
}