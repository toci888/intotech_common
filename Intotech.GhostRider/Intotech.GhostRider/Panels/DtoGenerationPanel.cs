using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.GhostRider.Panels
{
    public class DtoGenerationPanel : PanelBase
    {
        public DtoGenerationPanel()
        {
            Logic_Usings_Label.Text = "Dto Generation";
            Name_Space_Label.Text = "Namespace";
            Dto_Usings_Label.Text = "Usings";
            Dto_Output_Path_Label.Text = "Output Path";
            Dto_Dll_Path_Label.Text = "Dll Path";

            DtoNameSpaces.Text = "namespace Intotech.Wheelo.Bll.Models.Dtos;";
            DtoUsings.Text = "using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;";
            DtoOutputDirectory.Text = "C:\\Users\\stasx\\Documents\\GitHub\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Intotech.Wheelo.Bll.Models\\Dtos\\";
            DtoPathAssembly.Text = "C:\\Users\\stasx\\Documents\\GitHub\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Toci.Driver.Database.Persistence\\bin\\Debug\\net7.0\\Toci.Driver.Database.Persistence.dll";
        }

        protected override void HandleClick(object? sender, EventArgs eventArgs)
        {
            if (DtoPathAssembly.Text != null || DtoOutputDirectory.Text != null || DtoUsings.Text != null || DtoNameSpaces.Text != null) 
            {
                string mainFolder = DtoPathAssembly.Text;         //
                string outputDirectory = DtoOutputDirectory.Text; //
                string usings = DtoUsings.Text;                   //
                string nameSpace = DtoNameSpaces.Text;            //

                bool reloadMethod = Realizator.DtoRender(mainFolder, outputDirectory, usings, nameSpace); ///

                if (reloadMethod == true)
                {
                    HandleClick(sender, eventArgs); //
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
