﻿using Npgsql;
using System.Text.RegularExpressions;

namespace Intotech.Common.Database.DbSetup;

public class DbSetupManager
{
    private string _rootConnectionString;
    private string _sqlFilePath;
    private string _databaseName;
    private string _customDbConnectionString;

    protected string FileContents = String.Empty;

    public DbSetupManager(string rootConnectionString, string customDbConnectionString, string databaseName, string sqlFilePath)
    {
        _rootConnectionString = rootConnectionString;
        _sqlFilePath = sqlFilePath;
        _databaseName = databaseName;
        _customDbConnectionString = customDbConnectionString;
    }

    public bool SetupDatabase(bool force)
    {
        using NpgsqlConnection connection = new NpgsqlConnection(_rootConnectionString);
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
                    if (!force) // to remove
                    {
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Error creating database: " + ex.Message);
                    return false;
                }
            }
        }

        connection.Close();

        FileContents = FileUtils.GetTextFromFile(_sqlFilePath);

        if (FileContents == string.Empty)
        {
            Console.WriteLine("SQL file path is probably wrong. I can't create tables.");
            return false;
        }

        bool isDbUpToDate = CheckTablesNewerVersion();

        if (!isDbUpToDate)
        {
            using (NpgsqlConnection customConnection = new NpgsqlConnection(_customDbConnectionString))
            {
                customConnection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(FileContents, customConnection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (NpgsqlException ex)
                    {
                        Console.WriteLine("Error creating tables: " + ex.Message);
                        return false;
                    }
                }

                customConnection.Close();
            }

            return true;
        }

        return false;
    }

    protected virtual bool CheckTablesNewerVersion()
    {
        using var connection = new NpgsqlConnection(_customDbConnectionString);
        connection.Open();

        var query = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'public' AND table_type='BASE TABLE';";

        using var command = new NpgsqlCommand(query, connection);
        long dbTableCount = (long)command.ExecuteScalar();

        int fileTablesCount = ReadTablesInSqlFile();

        return dbTableCount == fileTablesCount;
    }

    protected virtual int ReadTablesInSqlFile()
    {
        string searchText = "create table ";

        int count = Regex.Matches(FileContents, searchText, RegexOptions.IgnoreCase).Count;

        return count;
    }
}