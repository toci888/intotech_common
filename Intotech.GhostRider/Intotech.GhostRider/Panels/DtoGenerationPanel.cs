using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.GhostRider.Panels
{
    public class DtoGenerationPanel : PanelBase
    {
        protected string modelPath = null;
        public DtoGenerationPanel()
        {
            BannerLabel.Text = "Dto Generation";
            NameSpaceLabel.Text = "Namespace";
            UsingsLabel.Text = "Usings";
            OutputPathLabel.Text = "Output Path";
            isModelSelect.Text = "Model not selected";
        }

        protected override void ChooseModelsDllPathClick(object? sender, EventArgs eventArgs)
        {
            DLLBrowser dllBrowser = new();
            modelPath = dllBrowser.SelectDLL();
            if (modelPath != null)
            {
                isModelSelect.Text = "Model selected";
                isModelSelect.BackColor = Color.Green;
            }
        }
        protected override void HandleClick(object? sender, EventArgs eventArgs)
        {
            if (OutputDirectory.Text != null || Usings.Text != null || NameSpace.Text != null || modelPath != null) 
            {     
                string outputDirectory = OutputDirectory.Text; 
                string usings = Usings.Text;                   
                string nameSpace = NameSpace.Text;            

                bool reloadMethod = Realizator.DtoRender(modelPath, outputDirectory, usings, nameSpace); 

                if (reloadMethod == true)
                {
                    HandleClick(sender, eventArgs); 
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
