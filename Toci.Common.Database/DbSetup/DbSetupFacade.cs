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
            bool isDbFresh = DbSetupManager.SetupDatabase(force);
            //bool isScaffoldConnectionStringRight = DbSetupEntity.CustomDbConnectionString == IntotechXerionContext.cs.Contains(DbSetupEntity.CustomDbConnectionString)

            if (isDbFresh)
            {
                return DbScaffoldManager.RunScaffold();
            }

            return false;
        }
    }
}
