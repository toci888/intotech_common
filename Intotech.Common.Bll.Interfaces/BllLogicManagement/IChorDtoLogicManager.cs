using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Bll.Interfaces.BllLogicManagement
{
    public interface IChorDtoLogicManager<TDtoLogic, TDto>
    {
        void AddHandler(IDtoLogicHandler<TDtoLogic, TDto>  handler);

        TDto GetById(int id, List<string> handlers, TDto dto);
    }
}
