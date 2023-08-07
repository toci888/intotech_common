using Intotech.Common.Interfaces;

namespace Intotech.Common.Bll
{
    public abstract class ServiceBaseEx : ServiceBase
    {
        protected ServiceBaseEx(ITranslationEngineI18n translationEngine) : base(new ErrorLoggerDefault(), translationEngine) { }
    }
}
