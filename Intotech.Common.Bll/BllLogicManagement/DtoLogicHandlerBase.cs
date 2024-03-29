﻿using Intotech.Common.Bll.ChorDtoBll;
using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Bll.Interfaces.BllLogicManagement;

namespace Intotech.Common.Bll.BllLogicManagement
{
    public abstract class DtoLogicHandlerBase<TDtoLogic, TDto, TModelDto, TModel, TLogic, TCollectionModel, TCollectionModelDto> : 
        Dictionary<string, TDtoLogic>, IDtoLogicHandler<TDtoLogic, TDto>

        where TLogic : ILogicBase<TModel>
        where TModelDto : DtoModelBase, new()
        where TModel : ModelBase, new()
        where TCollectionModel : IList<TModel>, new()
        where TCollectionModelDto : IList<TModelDto>, new()
        where TDtoLogic : DtoLogicBase<TModelDto, TModel, TLogic, TDto, TCollectionModel, TCollectionModelDto>
        where TDto : new()
    {
        protected DtoLogicHandlerBase<TDtoLogic, TDto, TModelDto, TModel, TLogic, TCollectionModel, TCollectionModelDto> Children;
        protected TDtoLogic DtoLogic;
        //protected string Self;

        protected DtoLogicHandlerBase(
                       TDtoLogic dtoLogic,
          //             string self,
                       DtoLogicHandlerBase<TDtoLogic, TDto, TModelDto, TModel, TLogic, TCollectionModel, TCollectionModelDto> children = null
                   )
        {
            DtoLogic = dtoLogic;
            //Self = self;
            Children = children;
        }

        public virtual TDto GetById(int id, List<string> handlers, TDto dto)
        {
            DtoLogic.SetSelectFilter((m) => m.Id == id);

            dto = DtoLogic.GetEntity(dto);

            //dto = this[Self].GetEntity(dto);

            foreach (string handler in handlers)
            {
                if (Children.ContainsKey(handler))
                {
                    dto = Children[handler].GetEntity(dto);
                }
            }

            return dto;
        }

        public virtual TDto Set(TDto dto, List<string> handlers)
        {
            throw new NotImplementedException();
        }
    }
}
