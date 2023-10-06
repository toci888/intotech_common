using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Bll.Interfaces.ComplexResponses;

namespace Intotech.Common.Bll
{
    public abstract class StandardControllerManager<TILogic, TModel, TModelDto, TRequestDto> : IStandardControllerManager<TILogic, TModel, TModelDto, TRequestDto>
        where TModel : ModelBase, new()
        where TILogic : ILogicBase<TModel>
        where TModelDto : DtoModelBase, new()
        where TRequestDto : MsvcRequestDtoBase<TModelDto>, new()
    {
        protected TILogic Logic;
        protected TranslationEngineI18n translationEngineI18N;
        protected string HeaderLanguage;

        public void AcceptLanguageHeader(string header)
        {
            HeaderLanguage = header;
        }

        public virtual ReturnedResponse<int> Delete(TRequestDto request)
        {
            return new ReturnedResponse<int>(Logic.Delete(DtoModelMapper.Map<TModel, TModelDto>(request.RequestBody)), translationEngineI18N.Translate(HeaderLanguage, "_success"), true, 1);
        }

        public virtual TRequestDto GetRequestForGet(int id)
        {
            return new TRequestDto() { RequestBody = new TModelDto() { Id = id } };
        }

        public virtual ReturnedResponse<TModelDto> GetSingle(TRequestDto request)
        { 
            TModel result = Logic.Select(m => m.Id == request.RequestBody.Id).FirstOrDefault();

            if (result != null)
            {
                return new ReturnedResponse<TModelDto>(DtoModelMapper.Map<TModelDto, TModel>(result), translationEngineI18N.Translate(HeaderLanguage, "_success"), true, 1);
            }

            return new ReturnedResponse<TModelDto>(null, translationEngineI18N.Translate(HeaderLanguage, "_noData"), false, 2); // TODO err code
        }

        public virtual ReturnedResponse<TModelDto> Set(TRequestDto request)
        {
            TModel result = Logic.Insert(DtoModelMapper.Map<TModel, TModelDto>(request.RequestBody));

            return new ReturnedResponse<TModelDto>(DtoModelMapper.Map<TModelDto, TModel>(result), translationEngineI18N.Translate(HeaderLanguage, "_success"), true, 1);
        }

        public virtual ReturnedResponse<TModelDto> Update(TRequestDto request)
        {
            TModel updResult = Logic.Update(DtoModelMapper.Map<TModel, TModelDto>(request.RequestBody));

            return new ReturnedResponse<TModelDto>(DtoModelMapper.Map<TModelDto, TModel>(updResult), translationEngineI18N.Translate(HeaderLanguage, "_success"), true, 1);
        }
    }
}
