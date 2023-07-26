namespace Intotech.Common;

public interface IErrorLogger
{
    public void Log(List<Exception> ex);
    public void Log(Exception ex, LogLevels logLevel);
    public void Log(string message);
    public void Log(string message, LogLevels logLevel);
    public void Log(string message, LogLevels logLevel, params object[] details);
}
