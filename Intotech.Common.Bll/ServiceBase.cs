using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Interfaces;

namespace Intotech.Common.Bll
{
    public abstract class ServiceBase : IManager
    {
        protected string DefaultLang; // = "pl"; //#TODO CONSTS

        protected IErrorLogger ErrorLogger;
        protected ITranslationEngineI18n I18nTranslation;
        protected string HeaderLanguage;

        protected ServiceBase(IErrorLogger errorLogger, ITranslationEngineI18n i18nTranslation) 
        {
            ErrorLogger = errorLogger;
            I18nTranslation = i18nTranslation;
        }

        public void AcceptLanguageHeader(string header)
        {
            DefaultLang = HeaderLanguage = header;
        }
    }
}
