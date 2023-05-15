using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Database.DbSetup
{
    public class DbSetupEntity
    {
        public DbSetupEntity(string host, string? port, string password, string newDatabaseName)
        {
            port ??= "5432";

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
