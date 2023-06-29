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
    public class DtoLogicGenerationPanel : Panel
    {
        Button ChooseModelsDllPath = new();
        Button ChooseModelsDtosDllPath = new();
        Button ChooseLogicDllPath = new();
        Button ChooseDtosDllPath = new();

        Button GenButton = new();

        Label OutputDirectoryLabel = new();
        Label UsingsLabel = new();
        Label NamespaceLabel = new();

        Label BannerLabel = new();

        TextBox OutputDirectory = new();
        TextBox Usings = new();
        TextBox Namespace = new();

        string[] paths = new string[4];

        protected Font LabelsFont = new Font("Arial Narrow", 12F,FontStyle.Regular, GraphicsUnit.Point);

        public DtoLogicGenerationPanel()
        {
            CreateLayout();
        }
       
        protected virtual void CreateLayout()
        {
            OutputDirectoryLabel.Text = "Output Directory";
            OutputDirectoryLabel.Location = new Point(792, 27);

            UsingsLabel.Text = "Usings";
            UsingsLabel.Location = new Point(132, 299);

            NamespaceLabel.Text = "Namespace";
            NamespaceLabel.Location = new Point(798, 297);

            BannerLabel.Text = "Dto Logic Generation";
            BannerLabel.Location = new Point(410, 66);

            CreateButtons();

            CreateEvents();

            CreateTextboxes();

            Controls.Add(OutputDirectoryLabel);
            Controls.Add(UsingsLabel);
            Controls.Add(NamespaceLabel);
            Controls.Add(BannerLabel);
            Controls.Add(ChooseModelsDllPath);
            Controls.Add(ChooseModelsDtosDllPath);
            Controls.Add(ChooseLogicDllPath);
            Controls.Add(ChooseDtosDllPath);
            Controls.Add(GenButton);
            Controls.Add(OutputDirectory);
            Controls.Add(Usings);
            Controls.Add(Namespace);
        }
        protected virtual void CreateButtons()
        {
            GenButton.Location = new Point(370, 418);
            GenButton.Size = new Size(238, 55);
            GenButton.Text = "Generate";

            ChooseModelsDllPath.Location = new Point(40, 56);
            ChooseModelsDllPath.Size = new Size(164, 33);
            ChooseModelsDllPath.Text = "Choose Models Dll";

            ChooseModelsDtosDllPath.Location = new Point(39, 99);
            ChooseModelsDtosDllPath.Size = new Size(164, 33);
            ChooseModelsDtosDllPath.Text = "Choose ModelDto Dll";

            ChooseLogicDllPath.Location = new Point(41, 145);
            ChooseLogicDllPath.Size = new Size(164, 33);
            ChooseLogicDllPath.Text = "Choose Logic Dll ";

            ChooseDtosDllPath.Location = new Point(42, 191);
            ChooseDtosDllPath.Size = new Size(164, 33);
            ChooseDtosDllPath.Text = "Choose Dtos Dll";

        }
        protected virtual void CreateTextboxes()
        {
            OutputDirectory.Multiline = true;
            OutputDirectory.Location = new Point(682, 63);
            OutputDirectory.Size = new Size(300, 150);

            Usings.Multiline = true;
            Usings.Location = new Point(24, 333);
            Usings.Size = new Size(300, 150);

            Namespace.Multiline = true;
            Namespace.Location = new Point(685, 333);
            Namespace.Size = new Size(300, 150);
        }
        protected virtual void CreateEvents()
        {
            ChooseModelsDllPath.Click += new EventHandler(ChooseModelsDllPath_Click);
            ChooseModelsDtosDllPath.Click += new EventHandler(ChooseModelsDtosDllPath_Click);
            ChooseLogicDllPath.Click += new EventHandler(ChooseLogicDllPath_Click);
            ChooseDtosDllPath.Click += new EventHandler(ChooseDtosDllPath_Click);
            GenButton.Click += new EventHandler(GenButton_Click);
        }
        

        private void ChooseModelsDllPath_Click(object sender, EventArgs e)
        {
            DLLBrowser dllBrowser = new DLLBrowser();
            paths[0] = dllBrowser.SelectDLL();
        }
        private void ChooseModelsDtosDllPath_Click(object sender, EventArgs e)
        {
            DLLBrowser dllBrowser = new DLLBrowser();
            paths[1] = dllBrowser.SelectDLL();
        }
        private void ChooseLogicDllPath_Click(object sender, EventArgs e)
        {
            DLLBrowser dllBrowser = new DLLBrowser();
            paths[2] = dllBrowser.SelectDLL();
        }
        private void ChooseDtosDllPath_Click(object sender, EventArgs e)
        {
            DLLBrowser dllBrowser = new DLLBrowser();
            paths[3] = dllBrowser.SelectDLL();
        }
        private void GenButton_Click(object sender, EventArgs e)
        {
            if (OutputDirectory.Text != null || Usings.Text != null || Namespace.Text != null)
            {
                var outputDirectory = OutputDirectory.Text;
                var usings = Usings.Text;
                var nameSpace = Namespace.Text;

                GeneratorRealization realizator = new();

                List<string> dllPaths = new ();
               dllPaths = paths.ToList();

                var reloadMethod = realizator.DtoLogicRender(dllPaths, outputDirectory, usings, nameSpace);

                if (reloadMethod == true)
                {
                    GenButton_Click(sender, e);
                    MessageBox.Show("ModelDtos files are updated");
                }


            }
            else
            {
                MessageBox.Show("Not all fields are filled");
            }
        }


    }
}
