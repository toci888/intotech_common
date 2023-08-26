using System.Runtime.InteropServices;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Microservices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Intotech.Common.Microservices;

public abstract class ApiControllerBase<TLogic, TModel> : ControllerBase, IApiControllerBase<TLogic, TModel> where TLogic : ILogicBase<TModel> where TModel : ModelBase
{
    protected TLogic Logic;
    protected ApiControllerBase(TLogic logic)
    {
        Logic = logic;
    }

    [HttpPost]
    [Route("Create")]
    public virtual TModel Create(TModel model)
    {
        return Logic.Insert(model);
    }

    [HttpGet]
    [Route("Select")]
    public virtual IEnumerable<TModel> Get()
    {
        return Logic.Select(m => true);
    }

    [HttpPut]
    [Route("Update")]
    public virtual TModel Update(TModel model)
    {
        return Logic.Update(model);
    }

    [HttpDelete]
    [Route("Delete")]
    public virtual int Delete(TModel model)
    {
        return Logic.Delete(model);
    }
}