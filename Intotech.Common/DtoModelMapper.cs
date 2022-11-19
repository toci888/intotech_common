using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common
{
    public static class DtoModelMapper
    {
        public static TDto Map<TDto, TModel>(TModel model) where TDto : new()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
                cfg.CreateMap<TModel, TDto>());

            Mapper mapper = new Mapper(config);

            return mapper.Map<TDto>(model);
        }
    }
}
