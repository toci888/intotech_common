using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Database.DbSetup
{
    public class DbSetupFacade
    {
        protected DbSetupEntity DbSetupEntity { get; set; }

        protected DbSetupManager DbSetupManager;
        protected DbScaffoldManager DbScaffoldManager;

        public DbSetupFacade(DbSetupEntity dbSetupEntity)
        {
            DbSetupEntity = dbSetupEntity;

            DbSetupManager = new DbSetupManager(DbSetupEntity.RootConnectionString, DbSetupEntity.CustomDbConnectionString, DbSetupEntity.DatabaseName, DbSetupEntity.SqlFilePath);
            DbScaffoldManager = new DbScaffoldManager(DbSetupEntity.CustomDbConnectionString, DbSetupEntity.ProjectName, DbSetupEntity.ParentProjectFolderPath);
        }

        public bool RunAll(bool force = false)
        {
            bool result = DbSetupManager.SetupDatabase(force); // true - czysta

            if (result)
            {
                return DbScaffoldManager.RunScaffold();
            }

            return false;
        }
    }
}
