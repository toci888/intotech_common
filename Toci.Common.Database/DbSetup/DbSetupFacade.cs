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

        public bool RunAll(bool force = false, string insideFolder = "")
        {
            bool isDbFresh = DbSetupManager.SetupDatabase(force);
            
            string solutionDirectory = EnvironmentUtils.GetSolutionDirectory();

            var path = $"{solutionDirectory}/{DbSetupEntity.BackendFolderPath}/{insideFolder}/{DbSetupEntity.ProjectName}/Models/{DbSetupEntity.DatabaseName.Replace(".", "")}Context.cs";
            string fileContent = FileUtils.GetTextFromFile(path);
            

            bool isScaffoldConnectionStringRight = fileContent.Contains(DbSetupEntity.CustomDbConnectionString);


            if (isDbFresh || !isScaffoldConnectionStringRight)
            {
                return DbScaffoldManager.RunScaffold();
            }

            return false;
        }
    }
}
