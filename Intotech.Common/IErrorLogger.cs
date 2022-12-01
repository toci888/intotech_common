namespace Intotech.Common;

public interface IErrorLogger
{
    public void Log(List<Exception> ex);
    public void Log(string message);
}
