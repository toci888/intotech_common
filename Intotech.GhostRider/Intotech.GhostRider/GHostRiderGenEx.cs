﻿using Intotech.GhostRider;
using System.IO;
using Intotech.ReflectiveTools.SourceGenerators.ModelsToDtoGenerator;
using Intotech.GhostRider.Panels;

namespace Intotech.GhostRider
{
    public partial class GhostRiderGenEx : Form
    {
        protected Panel generatorOptionPanel;


        public GhostRiderGenEx()
        {
            InitializeComponent();

        }
        public string MainFolderPath = null;
        private void dtoGenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void logicGenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void iLogicGenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modelDtoGenToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void dtoLogicGenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void _modelDto_GenButton_Click(object sender, EventArgs e)
        {
            if (generatorOptionPanel != null)
            {
                generatorOptionPanel.Hide();
            }

            generatorOptionPanel = new ModelDtoGenerationPanel();

            generatorOptionPanel.Size = new Size(1019, 510);
            Controls.Add(generatorOptionPanel);

            generatorOptionPanel.Show();
        }

        private void derivanceManipulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (generatorOptionPanel != null)
            {
                generatorOptionPanel.Hide();
            }

            generatorOptionPanel = new ModelDerivanceManipulatorPanel();

            generatorOptionPanel.Size = new Size(1019, 510);
            Controls.Add(generatorOptionPanel);

            generatorOptionPanel.Show();
        }

        private void iDtoLogicGenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void iLogicHandlersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logicGenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (generatorOptionPanel != null)
            {
                generatorOptionPanel.Hide();
            }

            generatorOptionPanel = new LogicGenerationPanel();

            generatorOptionPanel.Size = new Size(1019, 510);
            Controls.Add(generatorOptionPanel);

            generatorOptionPanel.Show();
        }

        private void iLogicGenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (generatorOptionPanel != null)
            {
                generatorOptionPanel.Hide();
            }

            generatorOptionPanel = new ILogicGenerationPanel();

            generatorOptionPanel.Size = new Size(1019, 510);
            Controls.Add(generatorOptionPanel);

            generatorOptionPanel.Show();
        }

        private void modelDtoGenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (generatorOptionPanel != null)
            {
                generatorOptionPanel.Hide();
            }

            generatorOptionPanel = new ModelDtoGenerationPanel();

            generatorOptionPanel.Size = new Size(1019, 510);
            Controls.Add(generatorOptionPanel);

            generatorOptionPanel.Show();
        }

        private void dtoGenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (generatorOptionPanel != null)
            {
                generatorOptionPanel.Hide();
            }

            generatorOptionPanel = new DtoGenerationPanel();

            generatorOptionPanel.Size = new Size(1019, 510);
            Controls.Add(generatorOptionPanel);

            generatorOptionPanel.Show();
        }

        private void dtoLogicGenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (generatorOptionPanel != null)
            {
                generatorOptionPanel.Hide();
            }

            generatorOptionPanel = new DtoLogicGenerationPanel();

            generatorOptionPanel.Size = new Size(1019, 510);
            Controls.Add(generatorOptionPanel);

            generatorOptionPanel.Show();
        }

        private void iDtoLogicGenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (generatorOptionPanel != null)
            {
                generatorOptionPanel.Hide();
            }

            generatorOptionPanel = new IDtoLogicGenerationPanel();

            generatorOptionPanel.Size = new Size(1019, 510);
            Controls.Add(generatorOptionPanel);

            generatorOptionPanel.Show();
        }

        private void iLogicHandlersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (generatorOptionPanel != null)
            {
                generatorOptionPanel.Hide();
            }

            generatorOptionPanel = new IDtoLogicHandlerPanel();

            generatorOptionPanel.Size = new Size(1019, 510);
            Controls.Add(generatorOptionPanel);

            generatorOptionPanel.Show();
        }

        private void logicHandlersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (generatorOptionPanel != null)
            {
                generatorOptionPanel.Hide();
            }

            generatorOptionPanel = new DtoLogicHandlerPanel();

            generatorOptionPanel.Size = new Size(1019, 510);
            Controls.Add(generatorOptionPanel);

            generatorOptionPanel.Show();
        }
    }


}
