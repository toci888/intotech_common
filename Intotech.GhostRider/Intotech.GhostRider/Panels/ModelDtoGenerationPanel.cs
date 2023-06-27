using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.GhostRider.Panels
{
    internal class ModelDtoGenerationPanel : PanelBase
    {
        public ModelDtoGenerationPanel()
        {
            BannerLabel.Text = "ModelDto Generation";
            NameSpaceLabel.Text = "Namespace";
            UsingsLabel.Text = "Usings";
            OutputPathLabel.Text = "Output Path";
            DllPathLabel.Text = "Dll Path";

            NameSpaces.Text = "";
            Usings.Text = "";
            OutputDirectory.Text = "";
            PathAssembly.Text = "";
        }

        protected override void HandleClick(object? sender, EventArgs eventArgs)
        {
            if (PathAssembly.Text != null || OutputDirectory.Text != null || Usings.Text != null || NameSpaces.Text != null)
            {
                string mainFolder = PathAssembly.Text;
                string outputDirectory = OutputDirectory.Text;
                string usings = Usings.Text;
                string nameSpace = NameSpaces.Text;

                bool reloadMethod = Realizator.ModelDtoRender(mainFolder, outputDirectory, usings, nameSpace);

                if (reloadMethod == true)
                {
                    HandleClick(sender, eventArgs);
                    MessageBox.Show("Dtos files are updated");
                }
            }
            else
            {
                MessageBox.Show("Not all fields are filled");
            }
        }
    }
}
