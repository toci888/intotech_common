namespace Intotech.Common.Database.DbSetup
{
    public class DbSetupFacade
    {
        protected DbSetupEntity DbSetupEntity { get; set; }

        protected DbSetupManager DbSetupManager;
        protected DbScaffoldManager DbScaffoldManager;

        private string _dbContextFilePath;

        public DbSetupFacade(DbSetupEntity dbSetupEntity, string insideFolder = "")
        {
            DbSetupEntity = dbSetupEntity;

            string solutionPath = EnvironmentUtils.GetSolutionDirectory();

            string backendFolderPath = EnvironmentUtils.IsDockerEnv ? DbSetupEntity.BackendFolderPath : string.Empty;
            _dbContextFilePath = $"{solutionPath}/{backendFolderPath}/{insideFolder}/{DbSetupEntity.ProjectName}/Models/{DbSetupEntity.DatabaseName.Replace(".", "")}Context.cs";

            DbSetupManager = new DbSetupManager(DbSetupEntity.RootConnectionString, DbSetupEntity.CustomDbConnectionString, DbSetupEntity.DatabaseName, DbSetupEntity.SqlFilePath);
            DbScaffoldManager = new DbScaffoldManager(DbSetupEntity.CustomDbConnectionString, DbSetupEntity.ProjectName, _dbContextFilePath);
        }

        public bool RunAll(bool force = false) // todo!
        {
            bool isDbFresh = DbSetupManager.SetupDatabase(force);
            

            string fileContent = FileUtils.GetTextFromFile(_dbContextFilePath);
            

            //bool isScaffoldConnectionStringRight = fileContent.Contains(DbSetupEntity.CustomDbConnectionString);


            //if (isDbFresh || !isScaffoldConnectionStringRight)
            //{
            //    return DbScaffoldManager.RunScaffold();
            //}

            return false;
        }
    }
}
