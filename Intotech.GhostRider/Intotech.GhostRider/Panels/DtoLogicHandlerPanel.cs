using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.GhostRider.Panels
{
    public class DtoLogicHandlerPanel : IDtoLogicHandlerPanel
    {
        public DtoLogicHandlerPanel()
        {
            BannerLabel.Text = "Logic Handler Generator";
        }

        protected override void HandleClick(object? sender, EventArgs eventArgs)
        {
            if (OutputDirectory.Text != null || Usings.Text != null || NameSpace.Text != null || modelPath != null)
            {
                string outputDirectory = OutputDirectory.Text;
                string usings = Usings.Text;
                string nameSpace = NameSpace.Text;

                List<string> dontDelFiles = new List<string>(dontDeleteFiles.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

                bool reloadMethod = Realizator.ILogicHandlerRender(modelPath, outputDirectory, usings, nameSpace, dontDelFiles, false);

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
