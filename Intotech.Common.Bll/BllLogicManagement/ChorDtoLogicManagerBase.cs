using Intotech.Common.Bll.Interfaces.BllLogicManagement;

namespace Intotech.Common.Bll.BllLogicManagement
{
    public abstract class ChorDtoLogicManagerBase<TDtoLogicHandler, TDtoLogic, TDto> : IChorDtoLogicManager<TDtoLogicHandler, TDto>
        where TDtoLogicHandler : IDtoLogicHandler<TDtoLogic, TDto>
    {
        protected TDtoLogicHandler DtoLogicHandler;

        protected ChorDtoLogicManagerBase(TDtoLogicHandler dtoLogicHandler)
        {
            DtoLogicHandler = dtoLogicHandler;
        }

        public virtual void AddHandler(IDtoLogicHandler<TDtoLogicHandler, TDto> handler)
        {
            
        }

        public virtual TDto GetById(int id, List<string> handlers, TDto dto)
        {
            return DtoLogicHandler.GetById(id, handlers, dto);
        }
    }
}
