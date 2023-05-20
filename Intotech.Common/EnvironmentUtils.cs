namespace Intotech.Common
{
    public class EnvironmentUtils
    {
        public static bool IsDockerEnv;
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

        private static bool IsRunningInDocker()
        {
            string? dockerEnv = Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER");
            return !string.IsNullOrEmpty(dockerEnv) && dockerEnv.Equals("true", StringComparison.OrdinalIgnoreCase);
        }
    }
}