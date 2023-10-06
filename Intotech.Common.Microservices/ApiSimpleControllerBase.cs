using Intotech.Common.Bll;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Intotech.Common.Microservices;

public abstract class ApiSimpleControllerBase<TManager> : ControllerBase where TManager : IService
{
    protected TManager Manager;
    protected ITranslationEngineI18n I18nTranslation;

    protected ApiSimpleControllerBase(TManager service)
    {
        Manager = service;
    }
}