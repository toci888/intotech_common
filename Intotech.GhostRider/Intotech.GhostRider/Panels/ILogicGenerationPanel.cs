namespace Intotech.GhostRider.Panels
{
    public class ILogicGenerationPanel : PanelBase
    {
        protected string modelPath = null;

        protected TextBox dontDeleteFiles = new();
        protected Label dontDeleteFilesLabel = new();
        protected Label additionalMessageLabel = new();
        public ILogicGenerationPanel()
        {
            BannerLabel.Text = "ILogic Generation";
            NameSpaceLabel.Text = "Namespace";
            UsingsLabel.Text = "Usings";
            OutputPathLabel.Text = "Output Path";
            isModelSelect.Text = "Model not selected";

            CreateDontDeleteFilesBox();
        }

        protected override void ChooseModelsDllPathClick(object? sender, EventArgs eventArgs)
        {
            DLLBrowser dllBrowser = new DLLBrowser();
            modelPath = dllBrowser.SelectDLL();
            if (modelPath != null)
            {
                isModelSelect.Text = "Model selected";
                isModelSelect.BackColor = Color.Green;
            }
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
            if (OutputDirectory.Text != null || Usings.Text != null || NameSpace.Text != null || modelPath != null)
            {
                string outputDirectory = OutputDirectory.Text;
                string usings = Usings.Text;
                string nameSpace = NameSpace.Text;

                List<string> dontDelFiles = new List<string>(dontDeleteFiles.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

                bool reloadMethod = Realizator.ILogicRender(modelPath, outputDirectory, usings, nameSpace, dontDelFiles);

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
