using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Intotech.GhostRider.Panels
{
    public class DtoLogicGenerationPanel : PanelBase
    {
       
        string modelPath = null;
        public DtoLogicGenerationPanel()
        {
            BannerLabel.Text = "DtoLogic Generation";
            NameSpaceLabel.Text = "Namespace";
            UsingsLabel.Text = "Usings";
            OutputPathLabel.Text = "Output Path";
            isModelSelect.Text = "Model not selected";
        }
       protected override void ChooseModelsDllPathClick(object sender, EventArgs e)
        {
            DLLBrowser dllBrowser = new DLLBrowser();
            modelPath = dllBrowser.SelectDLL();
            if (modelPath != null)
            {
                isModelSelect.Text = "Model selected";
            }
        }
        protected override void HandleClick(object sender, EventArgs e)
        {

            if (OutputDirectory.Text != null || Usings.Text != null || NameSpace.Text != null || modelPath != null)
            {
                string outputDirectory = OutputDirectory.Text;
                string usings = Usings.Text;
                string nameSpace = NameSpace.Text;

                bool reloadMethod = Realizator.DtoLogicRender(modelPath, outputDirectory, usings, nameSpace);

                if (reloadMethod == true)
                {
                    HandleClick(sender, e);
                    MessageBox.Show("Files are updated");
                }
            }
            else
            {
                MessageBox.Show("Not all fields are filled");
            }
        }


    }
}
