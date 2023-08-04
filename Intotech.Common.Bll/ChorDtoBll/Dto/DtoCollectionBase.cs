using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Bll.ChorDtoBll.Dto
{
    public class DtoCollectionBase<TModel, TModelDto, TCollectionModel, TCollectionModelDto> : DtoBase<TModel, TModelDto>
        where TModel : ModelBase, new()
        where TModelDto : DtoModelBase, new() //DtoCollectionBase<TModel, TModelDto, TCollectionModel, TCollectionModelDto>
        where TCollectionModel : IList<TModel>, new()
        where TCollectionModelDto : IList<TModelDto>, new()
    {
        public virtual TCollectionModelDto MapModelCollectionToDtoCollection(TCollectionModel model)
        {
            TCollectionModelDto result = new TCollectionModelDto();

            foreach (TModel item in model) 
            {
                result.Add(DtoModelMapper.Map<TModelDto, TModel>(item));
            }

            return result;
        }

        public virtual TCollectionModel MapDtoCollectionToModelCollection(TCollectionModelDto collectionModelDto)
        {
            TCollectionModel result = new TCollectionModel();

            foreach (TModelDto item in collectionModelDto)
            {
                result.Add(DtoModelMapper.Map<TModel, TModelDto>(item));
            }

            return result;
        }

        public virtual TCollectionModelDto MapDtoToDto(TCollectionModelDto collectionModelDto)
        {
            TCollectionModelDto result = new TCollectionModelDto();

            foreach (TModelDto item in collectionModelDto)
            {
                result.Add(DtoModelMapper.Map<TModelDto, TModelDto>(item));
            }

            return result;
        }
    }
}
