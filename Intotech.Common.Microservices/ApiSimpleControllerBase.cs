using Microsoft.AspNetCore.Mvc;

namespace Intotech.Common.Microservices;

public abstract class ApiSimpleControllerBase<TService> : ControllerBase
{
    protected TService Service;
    protected ApiSimpleControllerBase(TService service)
    {
        Service = service;
    }
}