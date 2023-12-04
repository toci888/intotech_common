using Intotech.Common.Bll;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Http;
using Intotech.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace Intotech.Common.Microservices;

public abstract class ApiSimpleControllerBase<TManager> : ControllerBase where TManager : IManager
{
    protected TManager Manager;
    protected ITranslationEngineI18n I18nTranslation;
    protected string HeaderLanguage = TranslationEngineConsts.LangPl;

    protected ApiSimpleControllerBase(TManager manager, IHttpContextAccessor httpContextAccessor)
    {
        Manager = manager;

        if (httpContextAccessor != null)
        { 
            KeyValuePair<string, StringValues> langHeader = httpContextAccessor.HttpContext.Request.Headers.Where(h => h.Key.Equals(HttpConfigurationConsts.LanguageHeaderKey)).FirstOrDefault();

            if (langHeader.Key != null && langHeader.Value.Count > 0)
            {
                HeaderLanguage = langHeader.Value.ToString().Split(",", StringSplitOptions.None).First();
            }
        }

        Manager.AcceptLanguageHeader(HeaderLanguage);
    }
}