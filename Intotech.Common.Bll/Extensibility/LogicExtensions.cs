using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Bll.Extensibility
{
    public static class LogicExtensions
    {
        public static IEnumerable<TModelDto> MapModelToModelDto<TModel, TModelDto>(this IEnumerable<TModel> modelCollection) where TModel : ModelBase where TModelDto : new()
        {
            return modelCollection.Select(m => DtoModelMapper.Map<TModelDto, TModel>(m));
        }


    }
}
