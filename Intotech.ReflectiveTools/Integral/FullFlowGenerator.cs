using Intotech.Common.Bll.Interfaces;
using Intotech.ReflectiveTools.SourceGenerators.LogicGenerator;
using Intotech.ReflectiveTools.SourceGenerators.Models2DtosGenerator;
using Intotech.ReflectiveTools.SourceGenerators.ModelsToDtoGenerator;

namespace Intotech.ReflectiveTools.Integral
{
    public class FullFlowGenerator
    {
        protected LogicRenderer LogicBaseRenderer = new LogicRenderer();
        protected ClassRenderer ModelDtoRenderer = new ClassRenderer();
        protected DtoRenderer DtoRenderer = new DtoRenderer();

        public virtual void GenerateFullStack(List<ModelBase> models, FullFlowEntity data)
        {
            foreach (ModelBase model in models)
            {
                //GenerateLogicBases(model, data);
                GenerateDtoAndModelDto(model, data);
            }
        }

        protected virtual void GenerateLogicBases(ModelBase model, FullFlowEntity data)
        {
            LogicBaseRenderer.RenderLogicClassInterface(model.GetType(), data.PathILogicBase, data.ILogicBaseUsings, data.ILogicBaseNamespace, true);
            LogicBaseRenderer.RenderLogicClassInterface(model.GetType(), data.PathLogicBase, data.LogicBaseUsings, data.LogicBaseNamespace, false);
        }

        protected virtual void GenerateDtoAndModelDto(ModelBase model, FullFlowEntity data)
        {
            ModelDtoRenderer.RenderModelDtoClass(model.GetType(), data.PathModelDto, data.ModelDtoUsings, data.ModelDtoNamespace);
            DtoRenderer.RenderDtoClass(model.GetType(), data.PathDto, data.DtoUsings, data.DtoNamespace);
        }
    }
}
