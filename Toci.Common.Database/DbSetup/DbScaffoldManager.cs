using System.Diagnostics;

namespace Intotech.Common.Database.DbSetup;

public class DbScaffoldManager
{
    private string _connectionString;
    private string _projectName;
    private string _databaseName;
    private string _dbContextFilePath;

    public DbScaffoldManager(string connectionString, string projectName, string dbContextFilePath)
    {
        _connectionString = connectionString;
        _projectName = projectName;
        _dbContextFilePath = dbContextFilePath;
    }

    public bool RunScaffold()
    {
        string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

        if (EnvironmentUtils.IsDockerEnv)
        {
            GetDbName();

            string context = FileUtils.GetTextFromFile(_dbContextFilePath);

            if (!context.Contains("=> optionsBuilder.UseNpgsql(\"Host=host.docker.internal"))
            {
                string connStringText = "=> optionsBuilder.UseNpgsql(\"";
                int pgStringPos = context.IndexOf(connStringText);

                if (pgStringPos == -1)
                {
                    Console.WriteLine("Nie znalazłem connection stringa innego niż docker" + _projectName);
                    return false;
                }

                int start = pgStringPos + connStringText.Length;
                int end = context.IndexOf("\"", start);
                string oldText = context.Substring(start, end - start);
                string newContext = context.Replace(oldText, _connectionString);

                File.WriteAllText(_dbContextFilePath, newContext);

                //Environment.Exit(0);
                return false;
            }
        }

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

    private void GetDbName()
    {
        int startIndex = _connectionString.IndexOf("Database=");
        if (startIndex >= 0)
        {
            startIndex += "Database=".Length; // Przesuwamy indeks za "Database="

            int endIndex = _connectionString.IndexOf(";", startIndex); // Znajdujemy indeks pierwszego wystąpienia znaku ";" po starcie

            if (endIndex >= 0)
            {
                _databaseName = _connectionString.Substring(startIndex, endIndex - startIndex); // Pobieramy tekst pomiędzy indeksami
            }
        }
    }
}