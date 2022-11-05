using Microsoft.AspNetCore.Mvc;

namespace Intotech.Common.Microservices;

public abstract class ApiSimpleControllerBase<TLogic> : ControllerBase
{
    protected TLogic Logic;
    protected ApiSimpleControllerBase(TLogic logic)
    {
        Logic = logic;
    }
}