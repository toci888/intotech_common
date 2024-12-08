namespace Intotech.Common.Database.DbSetup
{
    public class DbSetupEntity
    {
        public DbSetupEntity(string host, string password, string newDatabaseName)
        {
            AssignConnectionStrings(host, "5432", password, newDatabaseName);
        }

        /// <summary>
        /// Constructor deciding the database location - docker or localhost.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="newDatabaseName"></param>
        public DbSetupEntity(string password, string newDatabaseName)
        {
            string host = EnvironmentUtils.IsDockerEnv ? "host.docker.internal" : "localhost";
            string port = EnvironmentUtils.IsDockerEnv ? "5500" : "5432";

            AssignConnectionStrings(host, port, password, newDatabaseName);
        }

        public DbSetupEntity(string host, string port, string password, string newDatabaseName)
        {
            AssignConnectionStrings(host, port, password, newDatabaseName);
        }

        /// <summary>
        /// Create all necessary database connection strings.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="password"></param>
        /// <param name="newDatabaseName">Major db, for which we run the create custom database and scaffold.</param>
        private void AssignConnectionStrings(string host, string port, string password, string newDatabaseName)
        {
            RootConnectionString = $"Host={host};Port={port};Database=postgres;Username=postgres;Password={password}";
            CustomDbConnectionString = $"Host={host};Port={port};Database={newDatabaseName};Username=postgres;Password={password}";
            DatabaseName = newDatabaseName;
        }

        public string RootConnectionString { get; set; }
        public string ProjectName { get; set; }
        public string SqlFilePath { get; set; }
        public string DatabaseName { get; set; }
        public string CustomDbConnectionString { get; set; }
        public string BackendFolderPath { get; set; }
        public string SolutionDirectory { get; set; }
    }
}
