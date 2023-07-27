namespace Intotech.Common.Bll
{
    public abstract class ServiceBaseEx : ServiceBase
    {
        protected ServiceBaseEx() : base(new ErrorLoggerDefault()) { }
    }
}
