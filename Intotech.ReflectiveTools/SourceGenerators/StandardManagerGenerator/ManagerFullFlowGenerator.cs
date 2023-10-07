using Intotech.Common.Bll.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.ReflectiveTools.SourceGenerators.StandardManagerGenerator
{
    public class ManagerFullFlowGenerator
    {
        ManagerRenderer managerRenderer = new();

        public virtual void GenerateFullStack(List<ModelBase> models, ManagerFullFlowEntity data)
        {
            foreach (var model in models)
            {
                if (model.GetType().Name.Contains("Context"))
                {
                    continue;
                }
                else
                {
                    managerRenderer.GenerateInterfaceBodyAndSave(model.GetType(), data.PathIManager, data.IManagerUsings, data.IManagerNamespace);
                    managerRenderer.GenerateClassBodyAndSave(model.GetType(), data.PathManager, data.ManagerUsings, data.ManagerNamespace);
                }
                
            }
        }
    }
}
