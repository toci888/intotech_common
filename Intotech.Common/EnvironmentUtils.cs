namespace Intotech.Common
{
    public class EnvironmentUtils
    {
        /// <summary>
        /// boolean stating whether we are in the docker environment.
        /// </summary>
        public static bool IsDockerEnv;

        /// <summary>
        /// Gets the current directory, checks whether we are running in the docker environment, if it does returns path combination with "src", otherwise gets parent directory.
        /// </summary>
        /// <returns>Solution directory path.</returns>
        public static string GetSolutionDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            IsDockerEnv = IsRunningInDocker();

            if (IsDockerEnv)
            {
                string? parentDirectory = Directory.GetParent(currentDirectory)?.FullName;
                return Path.Combine(parentDirectory ?? string.Empty, "src");
            }
            else
            {
                string? parentDirectory = Directory.GetParent(currentDirectory)?.Parent?.FullName;
                return parentDirectory ?? string.Empty;
            }
        }

        /// <summary>
        /// Cheks the environment variable "DOTNET_RUNNING_IN_CONTAINER" and responds true or false.
        /// </summary>
        /// <returns>Whetheer we are running in Docker.</returns>
        private static bool IsRunningInDocker()
        {
            string? dockerEnv = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER");
            return !string.IsNullOrEmpty(dockerEnv) && dockerEnv.Equals("true", StringComparison.OrdinalIgnoreCase);
        }
    }
}