namespace Intotech.Common.Database.DbSetup
{
    public class DbSetupEntity
    {
        public DbSetupEntity(string host, string password, string newDatabaseName)
        {
            AssignConnectionStrings(host, "5432", password, newDatabaseName);
        }

        public DbSetupEntity(string password, string newDatabaseName)
        {
            AssignConnectionStrings("localhost", "5432", password, newDatabaseName);
        }

        public DbSetupEntity(string host, string port, string password, string newDatabaseName)
        {
            AssignConnectionStrings(host, port, password, newDatabaseName);
        }

        private void AssignConnectionStrings(string host, string port, string password, string newDatabaseName)
        {
            RootConnectionString = $"Host={host};Port={port};Database=postgres;Username=postgres;Password={password}";
            CustomDbConnectionString = $"Host={host};Port={port};Database={newDatabaseName};Username=postgres;Password={password}";
            DatabaseName = newDatabaseName;
        }

        public string RootConnectionString { get; set; }
        public string ProjectName { get; set; }
        public string ParentProjectFolderPath { get; set; }
        public string SqlFilePath { get; set; }
        public string DatabaseName { get; set; }
        public string CustomDbConnectionString { get; set; }
    }
}
