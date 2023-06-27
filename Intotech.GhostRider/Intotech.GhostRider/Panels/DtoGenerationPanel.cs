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
            BannerLabel.Text = "Dto Generation";
            NameSpaceLabel.Text = "Namespace";
            UsingsLabel.Text = "Usings";
            OutputPathLabel.Text = "Output Path";
            DllPathLabel.Text = "Dll Path";

            NameSpaces.Text = "namespace Intotech.Wheelo.Bll.Models.Dtos;";
            Usings.Text = "using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;";
            OutputDirectory.Text = "C:\\Users\\stasx\\Documents\\GitHub\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Intotech.Wheelo.Bll.Models\\Dtos\\";
            PathAssembly.Text = "C:\\Users\\stasx\\Documents\\GitHub\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interfaces\\Toci.Driver.Database.Persistence\\bin\\Debug\\net7.0\\Toci.Driver.Database.Persistence.dll";
        }

        protected override void HandleClick(object? sender, EventArgs eventArgs)
        {
            if (PathAssembly.Text != null || OutputDirectory.Text != null || Usings.Text != null || NameSpaces.Text != null) 
            {
                string mainFolder = PathAssembly.Text;         
                string outputDirectory = OutputDirectory.Text; 
                string usings = Usings.Text;                   
                string nameSpace = NameSpaces.Text;            

                bool reloadMethod = Realizator.DtoRender(mainFolder, outputDirectory, usings, nameSpace); 

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
