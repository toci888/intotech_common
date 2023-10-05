using System.Reflection;

namespace Intotech.ReflectiveTools
{
    public abstract class RenderersBase
    {
        public virtual void Run(Type sourceClass, string outputPath, string usings, string nmSpace, RendererCustomData rendererCustomData = null) 
        {
            
        }

        protected abstract void GenerateAndSaveClassBody(Type sourceClass, string outputPath, string usings, string nmSpace, RendererCustomData rendererCustomData = null);
    }
}
