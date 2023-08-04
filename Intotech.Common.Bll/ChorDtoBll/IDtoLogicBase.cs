using Intotech.Common.Bll.ChorDtoBll.Dto;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Bll.Interfaces.ChorDtoBll;
using System.Linq.Expressions;

namespace Intotech.Common.Bll.ChorDtoBll
{
    public interface IDtoLogicBase<TModelDto, TModel, TDto, TCollectionModel, TCollectionModelDto> : IAbsDtoLogic<TModel, ILogicBase<TModel>, TDto, TCollectionModelDto>
        where TModelDto : DtoModelBase, new()
        where TModel : ModelBase, new()
        where TCollectionModel : IList<TModel>, new()
        where TCollectionModelDto : IList<TModelDto>, new()
    {
        TCollectionModelDto GetCollection();
        TDto GetEntity(TDto masterEntity, TCollectionModelDto outputField = default);
        bool SetCollection(TCollectionModelDto entityCollection);
        TDto SetEntity(TDto dtoToSet);
        void SetSelectFilter(Expression<Func<TModel, bool>> selectFilter);
    }
}