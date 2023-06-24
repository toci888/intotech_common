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
            _logic_GenPanel.Size = new System.Drawing.Size(1019, 510);
            _ilogic_GenPanel.Size = new System.Drawing.Size(1019, 510);

        }
        
        private void dtoGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dtoGen_Panel.Show();

            _modelDto_GenPanel.Hide();
            _logic_GenPanel.Hide();
            _ilogic_GenPanel.Hide();
        }
        private void logicGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _logic_GenPanel.Show();

            _dtoGen_Panel.Hide();
            _modelDto_GenPanel.Hide();
            _ilogic_GenPanel.Hide();
        }

        private void iLogicGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ilogic_GenPanel.Show();

            _dtoGen_Panel.Hide();
            _modelDto_GenPanel.Hide();
            _logic_GenPanel.Hide();
        }

        private void modelDtoGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _modelDto_GenPanel.Show();

            _dtoGen_Panel.Hide();
            _logic_GenPanel.Hide();
            _ilogic_GenPanel.Hide();

        }

        private void dtoLogicGenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dtoGen_Panel.Hide();
            _modelDto_GenPanel.Hide();
            _logic_GenPanel.Hide();
            _ilogic_GenPanel.Hide();
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
                    MessageBox.Show("Dtos files are updated");
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
                    MessageBox.Show("ModelDtos files are updated");
                }

                
            }
            else
            {
                MessageBox.Show("Not all fields are filled");
            }
        }

        private void _logic_GenButton_Click(object sender, EventArgs e)
        {
            if (_logicPathAssembly.Text != null || _logicOutputDirectory.Text != null || _logicUsings.Text != null || _logicNameSpaces.Text != null) //
            {
                var mainFolder = _logicPathAssembly.Text;         //
                var outputDirectory = _logicOutputDirectory.Text; //
                var usings = _logicUsings.Text;                   //
                var nameSpace = _logicNameSpaces.Text;            //

                GeneratorRealization realizator = new();

                var reloadMethod = realizator.LogicRender(mainFolder, outputDirectory, usings, nameSpace); ///

                if (reloadMethod == true)
                {
                    _logic_GenButton_Click(sender, e); //
                    MessageBox.Show("Dtos files are updated");
                }


            }
            else
            {
                MessageBox.Show("Not all fields are filled");
            }
        }

        private void _ilogic_GenButton_Click(object sender, EventArgs e)
        {

            if (_ilogicPathAssembly.Text != null || _ilogicOutputDirectory.Text != null || _ilogicUsings.Text != null || _ilogicNameSpace.Text != null) //
            {
                var mainFolder = _ilogicPathAssembly.Text;         //
                var outputDirectory = _ilogicOutputDirectory.Text; //
                var usings = _ilogicUsings.Text;                   //
                var nameSpace = _ilogicNameSpace.Text;            //

                GeneratorRealization realizator = new();

                var reloadMethod = realizator.ILogicRender(mainFolder, outputDirectory, usings, nameSpace); ///

                if (reloadMethod == true)
                {
                    _ilogic_GenButton_Click(sender, e); //
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