using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        List<string> paths = new List<string>();

        protected Font LabelsFont = new Font("Arial Narrow", 12F,FontStyle.Regular, GraphicsUnit.Point);

        public DtoLogicGenerationPanel()
        {
            CreateLayout();
        }
        //string modelsDllPath = "\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Toci.Driver.Database.Persistence\\bin\\Debug\\net7.0\\Toci.Driver.Database.Persistence.dll";
        //string modelsDtosDllPath = "\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Intotech.Wheelo.Bll.Models\\bin\\Debug\\net7.0\\Intotech.Wheelo.Bll.Models.dll";
        //string logicDllPath = "\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Intotech.Wheelo.Bll.Persistence\\bin\\Debug\\net7.0\\Intotech.Wheelo.Bll.Persistence.dll";
        //string dtosDllPath = "\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Intotech.Wheelo.Bll.Models\\bin\\Debug\\net7.0\\Intotech.Wheelo.Bll.Models.dll";

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

            CreateEvents();

            Controls.Add(OutputDirectoryLabel);
            Controls.Add(UsingsLabel);
            Controls.Add(NamespaceLabel);
            Controls.Add(BannerLabel);
            Controls.Add(ChooseModelsDllPath);
            Controls.Add(ChooseModelsDtosDllPath);
            Controls.Add(ChooseLogicDllPath);
            Controls.Add(ChooseDtosDllPath);
            Controls.Add(GenButton);
        }

        protected virtual void CreateEvents()
        {
            ChooseModelsDllPath.Click += new EventHandler(ChooseModelsDllPath_Click);
            ChooseModelsDtosDllPath.Click += new EventHandler(ChooseModelsDtosDllPath_Click);
            ChooseLogicDllPath.Click += new EventHandler(ChooseLogicDllPath_Click);
            ChooseDtosDllPath.Click += new EventHandler(ChooseDtosDllPath_Click);
            GenButton.Click += new EventHandler(GenButton_Click);
        }
        protected virtual void HandleClick(object? sender, EventArgs eventArgs)
        {
            //if (PathAssembly.Text != null || OutputDirectory.Text != null || Usings.Text != null || NameSpaces.Text != null)
            //{
            //    var mainFolder = PathAssembly.Text;
            //    var outputDirectory = OutputDirectory.Text;
            //    var usings = Usings.Text;
            //    var nameSpace = NameSpaces.Text;

            //    GeneratorRealization realizator = new();

            //    var reloadMethod = realizator.DtoLogicRender(mainFolder, outputDirectory, usings, nameSpace);

            //    if (reloadMethod == true)
            //    {
            //        HandleClick(sender, eventArgs);
            //        MessageBox.Show("ModelDtos files are updated");
            //    }


            //}
            //else
            //{
            //    MessageBox.Show("Not all fields are filled");
            //}
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

        }


    }
}
