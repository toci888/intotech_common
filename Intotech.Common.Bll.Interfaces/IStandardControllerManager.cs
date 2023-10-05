using Intotech.Common.Bll.Interfaces.ComplexResponses;
using System.Linq.Expressions;

namespace Intotech.Common.Bll.Interfaces
{
    public interface IStandardControllerManager<TILogic, TModel, TModelDto> : IManager
        where TModel : ModelBase
        where TILogic : ILogicBase<TModel>
        where TModelDto : DtoModelBase
    {
        ReturnedResponse<TModelDto> GetSingle(int id);
    }
}
