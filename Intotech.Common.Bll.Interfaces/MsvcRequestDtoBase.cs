namespace Intotech.Common.Bll.Interfaces
{
    public class MsvcRequestDtoBase<TModelDto> : DtoEntityBase
        where TModelDto : DtoModelBase
    {
        public virtual TModelDto RequestBody { get; set; }
    }
}
