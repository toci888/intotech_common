using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Bll.ChorDtoBll.Dto.Extensions
{
    public static class DtoBaseExtensions
    {
        public static TModelDto MapModelToDto<TModelDto, TModel>(this TModelDto modelDto, TModel model) 
            where TModel : ModelBase, new() 
            where TModelDto : DtoModelBase, new()
        {
            return DtoModelMapper.Map<TModelDto, TModel>(model);
        }

        public static TModel MapDtoToModel<TModel, TModelDto>(this TModelDto modelDto)
            where TModel : ModelBase, new()
            where TModelDto : DtoModelBase, new()
        {
            return DtoModelMapper.Map<TModel, TModelDto>(modelDto);
        }

        public static TModelDto MapDtoToDto<TModelDto>(this TModelDto modelDto)
            where TModelDto : DtoModelBase, new()
        {
            return DtoModelMapper.Map<TModelDto, TModelDto>(modelDto);
        }
    }
}
