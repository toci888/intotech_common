using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Bll.Interfaces
{
    public class MsvcRequestDtoBase<TModelDto> : DtoEntityBase
        where TModelDto : DtoModelBase
    {
        public virtual TModelDto RequestBody { get; set; }
    }
}
