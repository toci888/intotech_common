using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Interfaces;

namespace Intotech.Common.Bll
{
    public abstract class ServiceBase : IService
    {
        protected string DefaultLang = "pl"; //#TODO CONSTS

        protected IErrorLogger ErrorLogger;
        protected ITranslationEngineI18n I18nTranslation;

        protected ServiceBase(IErrorLogger errorLogger, ITranslationEngineI18n i18nTranslation) 
        {
            ErrorLogger = errorLogger;
            I18nTranslation = i18nTranslation;
        }
    }
}
