using Npgsql;

namespace Intotech.Common.Database.DbSetup;

public class DbSetupManager
{
    private string _connectionString;
    private string _sqlFilePath;
    private string _databaseName;
    private string _customDbConnectionString;

    protected string FileContents;

    public DbSetupManager(string connectionString, string customDbConnectionString,string databaseName, string sqlFilePath)
    {
        _connectionString = connectionString;
        _sqlFilePath = sqlFilePath;
        _databaseName = databaseName;
        _customDbConnectionString = customDbConnectionString;
    }

    public bool SetupDatabase(bool force)
    {
        
        using NpgsqlConnection connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        using (NpgsqlCommand command = new NpgsqlCommand($"CREATE DATABASE \"{_databaseName}\"", connection))
        {
            try
            {
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException ex)
            {
                if (ex.SqlState == "42P04")
                {
                    Console.WriteLine($"Database '{_databaseName}' already exists.");
                    if (!force)
                    {
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Error creating database: " + ex.Message);
                }
            }
        }

        connection.Close();

        using (NpgsqlConnection customConnection = new NpgsqlConnection(_customDbConnectionString))
        {
            customConnection.Open();

            ReadSqlFile();

            using (NpgsqlCommand command = new NpgsqlCommand(FileContents, customConnection))
            {
                command.ExecuteNonQuery();
            }

            customConnection.Close();
        }

        return true;
    }

    protected virtual bool ReadSqlFile()
    {
        try
        {
            FileContents = File.ReadAllText(_sqlFilePath);
        }
        catch (FileNotFoundException e)
        {
            
        }
        
        return true;
    }
}