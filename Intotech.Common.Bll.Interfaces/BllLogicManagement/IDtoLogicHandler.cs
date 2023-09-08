using Intotech.Common.Bll.Interfaces.ChorDtoBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Bll.Interfaces.BllLogicManagement
{
    public interface IDtoLogicHandler<TDtoLogic, TDto> //: IDictionary<string, TDtoLogic>  //where TDtoLogic : IAbsDtoLogic<TDto> where TDto : class
    {
        TDto GetById(int id, List<string> handlers, TDto dto);

        TDto Set(TDto dto, List<string> handlers);
    }
}
