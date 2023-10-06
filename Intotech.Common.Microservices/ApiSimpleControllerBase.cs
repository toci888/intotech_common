using Intotech.Common.Bll;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Http;
using Intotech.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace Intotech.Common.Microservices;

public abstract class ApiSimpleControllerBase<TManager> : ControllerBase where TManager : IManager
{
    protected TManager Manager;
    protected ITranslationEngineI18n I18nTranslation;
    protected string HeaderLanguage = TranslationEngineConsts.LangPl;

    protected ApiSimpleControllerBase(TManager manager)
    {
        Manager = manager;

        KeyValuePair<string, StringValues> langHeader = Request.Headers.Where(h => h.Key.Equals(HttpConfigurationConsts.LanguageHeaderKey)).FirstOrDefault();

        if (langHeader.Key != null)
        {
            HeaderLanguage = langHeader.Value;
        }

        Manager.AcceptLanguageHeader(HeaderLanguage);
    }
}