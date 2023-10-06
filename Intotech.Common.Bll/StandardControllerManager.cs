using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Bll.Interfaces.ComplexResponses;
using Intotech.Common.Interfaces;

namespace Intotech.Common.Bll
{
    public abstract class StandardControllerManager<TILogic, TModel, TModelDto, TRequestDto> : ServiceBaseEx, IStandardControllerManager<TILogic, TModel, TModelDto, TRequestDto>
        where TModel : ModelBase, new()
        where TILogic : ILogicBase<TModel>
        where TModelDto : DtoModelBase, new()
        where TRequestDto : MsvcRequestDtoBase<TModelDto>, new()
    {
        protected TILogic Logic;
        protected string HeaderLanguage;

        protected StandardControllerManager(ITranslationEngineI18n translationEngine, TILogic logic) : base(translationEngine)
        {
            Logic = logic;
        }

        public void AcceptLanguageHeader(string header)
        {
            HeaderLanguage = header;
        }

        public virtual ReturnedResponse<int> Delete(TRequestDto request)
        {
            return new ReturnedResponse<int>(Logic.Delete(DtoModelMapper.Map<TModel, TModelDto>(request.RequestBody)), I18nTranslation.Translate(HeaderLanguage, "_success"), true, 1);
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
                return new ReturnedResponse<TModelDto>(DtoModelMapper.Map<TModelDto, TModel>(result), I18nTranslation.Translate(HeaderLanguage, "_success"), true, 1);
            }

            return new ReturnedResponse<TModelDto>(null, I18nTranslation.Translate(HeaderLanguage, "_noData"), false, 2); // TODO err code
        }

        public virtual ReturnedResponse<TModelDto> Set(TRequestDto request)
        {
            TModel result = Logic.Insert(DtoModelMapper.Map<TModel, TModelDto>(request.RequestBody));

            return new ReturnedResponse<TModelDto>(DtoModelMapper.Map<TModelDto, TModel>(result), I18nTranslation.Translate(HeaderLanguage, "_success"), true, 1);
        }

        public virtual ReturnedResponse<TModelDto> Update(TRequestDto request)
        {
            TModel updResult = Logic.Update(DtoModelMapper.Map<TModel, TModelDto>(request.RequestBody));

            return new ReturnedResponse<TModelDto>(DtoModelMapper.Map<TModelDto, TModel>(updResult), I18nTranslation.Translate(HeaderLanguage, "_success"), true, 1);
        }
    }
}
