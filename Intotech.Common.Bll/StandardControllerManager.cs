﻿using Intotech.Common.Bll.Interfaces;
using Intotech.Common.Bll.Interfaces.ComplexResponses;
using Intotech.Common.Interfaces;

namespace Intotech.Common.Bll
{
    public abstract class StandardControllerManager<TILogic, TModel, TModelDto> : IStandardControllerManager<TILogic, TModel, TModelDto>
        where TModel : ModelBase, new()
        where TILogic : ILogicBase<TModel>
        where TModelDto : DtoModelBase, new()
    {
        protected TILogic Logic;
        protected TranslationEngineI18n translationEngineI18N;

        public virtual ReturnedResponse<TModelDto> GetSingle(int id)
        { 
            TModel result = Logic.Select(m => m.Id == id).FirstOrDefault();

            if (result != null)
            {
                return new ReturnedResponse<TModelDto>(DtoModelMapper.Map<TModelDto, TModel>(result), translationEngineI18N.Translate(TranslationEngineConsts.LangPl, "_success"), true, 1);
            }

            return new ReturnedResponse<TModelDto>(null, translationEngineI18N.Translate(TranslationEngineConsts.LangPl, "_noData"), false, 2); // TODO err code
        }

        public virtual ReturnedResponse<TModelDto> Set(TModelDto modelDto)
        {
            TModel result = Logic.Insert(DtoModelMapper.Map<TModel, TModelDto>(modelDto));

            return new ReturnedResponse<TModelDto>(DtoModelMapper.Map<TModelDto, TModel>(result), translationEngineI18N.Translate(TranslationEngineConsts.LangPl, "_success"), true, 1);
        }
    }
}
