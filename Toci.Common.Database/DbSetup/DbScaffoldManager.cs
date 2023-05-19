using System.Diagnostics;

namespace Intotech.Common.Database.DbSetup;

public class DbScaffoldManager
{
    private string _connectionString;
    private string _projectName;

    public DbScaffoldManager(string connectionString, string projectName)
    {
        _connectionString = connectionString;
        _projectName = projectName;
    }

    public bool RunScaffold()
    {
        string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

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
                WorkingDirectory = solutionDirectory
            }
        };
        process.Start();
        process.WaitForExit();

        if (process.ExitCode != 0)
        {
            string errorOutput = process.StandardError.ReadToEnd();
            Console.WriteLine($"Error: {errorOutput}");

            return false;
        }
        else
        {
            Console.WriteLine("Models generated successfully.");

            return true;
        }
    }
}