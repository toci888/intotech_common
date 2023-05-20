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
            DbScaffoldManager = new DbScaffoldManager(DbSetupEntity.CustomDbConnectionString, DbSetupEntity.ProjectName);
        }

        public bool RunAll(bool force = false)
        {
            bool isDbFresh = DbSetupManager.SetupDatabase(force);
            
            string solutionDirectory = EnvironmentUtils.GetSolutionDirectory();


            string fileContent = FileUtils.GetTextFromFile(
                $"{solutionDirectory}/{DbSetupEntity.BackendFolderPath}/{DbSetupEntity.ProjectName}/Models/{DbSetupEntity.DatabaseName.Replace(".", "")}Context.cs");
            

            bool isScaffoldConnectionStringRight = fileContent.Contains(DbSetupEntity.CustomDbConnectionString);


            if (isDbFresh || !isScaffoldConnectionStringRight)
            {
                return DbScaffoldManager.RunScaffold();
            }

            return false;
        }
    }
}
