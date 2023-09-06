using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.GhostRider.Panels
{
    internal class ModelDerivanceManipulatorPanel : PanelBase
    {
        string selectedFolderPath = null;
        public ModelDerivanceManipulatorPanel()
        {
            BannerLabel.Text = "Model Derivance Manipulator Generator";
            BannerLabel.Location = new Point(350, 56);
            OutputPathLabel.Text = "Write model Base";
            ChooseModelsDllPath.Text = "Choose destination folder";
            isModelSelect.Text = "Folder not selected";

            Usings.Visible = false;
            NameSpace.Visible = false ;
        }
        protected override void ChooseModelsDllPathClick(object? sender, EventArgs eventArgs)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = "C:\\";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
               selectedFolderPath = folderBrowserDialog.SelectedPath;
                if (selectedFolderPath != null)
                {
                    isModelSelect.Text = "Folder selected";
                    isModelSelect.BackColor = Color.Green;
                }
            }
        }

        protected override void HandleClick(object? sender, EventArgs eventArgs)
        {
            if (OutputDirectory.Text != null || selectedFolderPath != null) 
            {     
                bool reloadMethod = Realizator.MDManRender(selectedFolderPath, OutputDirectory.Text); 

                if (reloadMethod == true)
                {
                    //HandleClick(sender, eventArgs);
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
