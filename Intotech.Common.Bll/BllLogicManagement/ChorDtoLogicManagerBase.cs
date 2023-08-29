using Intotech.Common.Bll.Interfaces.BllLogicManagement;

namespace Intotech.Common.Bll.BllLogicManagement
{
    /// <summary>
    /// Klasa odpowiada za wyabstrahowanie zarządzania handlerami, pole TDtoLogicHandler przyjmuje dowolny generyczny handler.
    /// W metodzie getbyid handler zwraca atomowe dto po id.
    /// </summary>
    /// <typeparam name="TDtoLogicHandler">Generic handler constrained to IDtoLogicHandler<TDtoLogic, TDto>.</typeparam>
    /// <typeparam name="TDtoLogic"></typeparam>
    /// <typeparam name="TDto"></typeparam>
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
