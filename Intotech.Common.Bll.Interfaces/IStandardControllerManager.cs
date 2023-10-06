using Intotech.Common.Bll.Interfaces.ComplexResponses;
using System.Linq.Expressions;

namespace Intotech.Common.Bll.Interfaces
{
    public interface IStandardControllerManager<TILogic, TModel, TModelDto, TRequestDto> : IManager
        where TModel : ModelBase
        where TILogic : ILogicBase<TModel>
        where TModelDto : DtoModelBase
        where TRequestDto : MsvcRequestDtoBase<TModelDto>
    {
        ReturnedResponse<TModelDto> GetSingle(TRequestDto request);

        ReturnedResponse<TModelDto> Set(TRequestDto request);

        ReturnedResponse<TModelDto> Update(TRequestDto request);

        ReturnedResponse<int> Delete(TRequestDto request);

        TRequestDto GetRequestForGet(int id, string language);
    }
}
