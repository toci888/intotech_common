using Intotech.GhostRider;
using System.IO;
using Intotech.ReflectiveTools.SourceGenerators.ModelsToDtoGenerator;

namespace Intotech.GhostRider
{
    public partial class GhostRiderGenEx : Form
    {
        public GhostRiderGenEx()
        {
            InitializeComponent();
            _dtoGen_Panel.Size = new System.Drawing.Size(1019, 510);
            _modelDto_GenPanel.Size = new System.Drawing.Size(1019, 510);
        }

        private void dtoGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dtoGen_Panel.Show();

            _modelDto_GenPanel.Hide();
        }
        private void logicGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dtoGen_Panel.Hide();
            _modelDto_GenPanel.Hide();
        }

        private void iLogicGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dtoGen_Panel.Hide();
            _modelDto_GenPanel.Hide();
        }

        private void modelDtoGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _modelDto_GenPanel.Show();

            _dtoGen_Panel.Hide();
            
        }

        private void dtoLogicGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dtoGen_Panel.Hide();
            _modelDto_GenPanel.Hide();
        }

        private void DtoGenButton_Click(object sender, EventArgs e)
        {
            if (_dtoPathAssembly.Text != null || _dtoOutputDirectory.Text != null || _dtoUsings.Text != null || _dtoNameSpaces.Text != null) //
            {
                var mainFolder = _dtoPathAssembly.Text;         //
                var outputDirectory = _dtoOutputDirectory.Text; //
                var usings = _dtoUsings.Text;                   //
                var nameSpace = _dtoNameSpaces.Text;            //

                GeneratorRealization realizator = new();

               var reloadMethod = realizator.DtoRender(mainFolder, outputDirectory, usings, nameSpace); ///

                if (reloadMethod == true)
                {
                    DtoGenButton_Click(sender, e); //
                    MessageBox.Show("Dtos files are created");
                }
                 
                
            }
            else
            {
                MessageBox.Show("Not all fields are filled");
            }
        }

        private void _modelDto_GenButton_Click(object sender, EventArgs e)
        {
            if (_modelDtoPathAssembly.Text != null || _modelDtoOutputDirectory.Text != null || _modelDtoUsings.Text != null || _modelDtoNameSpaces.Text != null)
            {
                var mainFolder = _modelDtoPathAssembly.Text;
                var outputDirectory = _modelDtoOutputDirectory.Text;
                var usings = _modelDtoUsings.Text;
                var nameSpace = _modelDtoNameSpaces.Text;

                GeneratorRealization realizator = new();

                var reloadMethod = realizator.ModelDtoRender(mainFolder, outputDirectory, usings, nameSpace);

                if (reloadMethod == true)
                {
                    _modelDto_GenButton_Click(sender, e);
                    MessageBox.Show("ModelDtos files are created");
                }

                
            }
            else
            {
                MessageBox.Show("Not all fields are filled");
            }
        }
    }
}