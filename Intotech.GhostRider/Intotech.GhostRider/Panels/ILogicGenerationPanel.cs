using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.GhostRider.Panels
{
    internal class ILogicGenerationPanel : PanelBase
    {
        protected TextBox dontDeleteFiles = new();
        protected Label dontDeleteFilesLabel = new();
        protected Label additionalMessageLabel = new();
        public ILogicGenerationPanel()
        {
            BannerLabel.Text = "ILogic Generation";
            NameSpaceLabel.Text = "Namespace";
            UsingsLabel.Text = "Usings";
            OutputPathLabel.Text = "Output Path";
            DllPathLabel.Text = "Dll Path";

            NameSpaces.Text = "";
            Usings.Text = "";
            OutputDirectory.Text = "";
            PathAssembly.Text = "";

            CreateDontDeleteFilesBox();
        }

        protected void CreateDontDeleteFilesBox()
        {
            dontDeleteFiles.AutoSize = true;
            dontDeleteFiles.Location = new Point(377, 202);
            dontDeleteFiles.Font = LabelsFont;
            dontDeleteFiles.Multiline = true;
            dontDeleteFiles.Size = new Size(256, 110);

            dontDeleteFilesLabel.Text = "Dont Delete Files";
            dontDeleteFilesLabel.AutoSize = true;
            dontDeleteFilesLabel.Location = new Point(452, 172);
            dontDeleteFiles.Font = LabelsFont;
            dontDeleteFilesLabel.Size = new Size(95, 15);

            additionalMessageLabel.Text = "Enter the file names separated by a space.";
            additionalMessageLabel.AutoSize = true;
            additionalMessageLabel.Location = new Point(394, 320);
            additionalMessageLabel.Font = LabelsFont;
            additionalMessageLabel.Size = new Size(226, 15);

            Controls.Add(dontDeleteFiles);
            Controls.Add(dontDeleteFilesLabel);
            Controls.Add(additionalMessageLabel);
        }
        protected override void HandleClick(object? sender, EventArgs eventArgs)
        {
            if (PathAssembly.Text != null || OutputDirectory.Text != null || Usings.Text != null || NameSpaces.Text != null || dontDeleteFiles.Text !=null)
            {
                List<string> dontDelFiles = new List<string>(dontDeleteFiles.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

                string mainFolder = PathAssembly.Text;
                string outputDirectory = OutputDirectory.Text;
                string usings = Usings.Text;
                string nameSpace = NameSpaces.Text;

                bool reloadMethod = Realizator.ILogicRender(mainFolder, outputDirectory, usings, nameSpace, dontDelFiles); 

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
