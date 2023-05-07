using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Database.DbSetup
{
    public class DbSetupEntity
    {
        public DbSetupEntity(string host, string password, string newDatabaseName)
        {
            RootConnectionString = $"Host={host};Database=postgres;Username=postgres;Password={password}";
            CustomDbConnectionString = $"Host={host};Database={newDatabaseName};Username=postgres;Password={password}";
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
