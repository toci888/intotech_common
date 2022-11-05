namespace Intotech.Common;

public class GlobalExceptionHandler
{
    protected IErrorLogger ErrorLogger;

    public GlobalExceptionHandler(IErrorLogger errorLogger)
    {
        ErrorLogger = errorLogger;
    }

    public virtual void ActivateGlobalExceptionHandling()
    {
        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledExceptionLog);
    }

    protected void UnhandledExceptionLog(object sender, UnhandledExceptionEventArgs exception)
    {
        List<Exception> excStack = new List<Exception>();

        Exception masterExc = (Exception)exception.ExceptionObject;

        excStack = BreakDownException(masterExc, excStack);

        ErrorLogger.Log(excStack);
    }

    protected virtual List<Exception> BreakDownException(Exception masterExc, List<Exception> currentList)
    {
        currentList.Add(masterExc);

        if (masterExc.InnerException != null)
        {
            BreakDownException(masterExc.InnerException, currentList);
        }

        return currentList;
    }
}
