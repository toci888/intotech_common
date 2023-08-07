using Intotech.Common.Bll;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Intotech.Common.Microservices;

public abstract class ApiSimpleControllerBase<TService> : ControllerBase where TService : IService
{
    protected TService Service;
    protected ITranslationEngineI18n I18nTranslation;

    protected ApiSimpleControllerBase(TService service)
    {
        Service = service;
    }
}