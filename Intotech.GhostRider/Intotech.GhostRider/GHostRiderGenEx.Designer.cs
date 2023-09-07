namespace Intotech.GhostRider
{
    partial class GhostRiderGenEx
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            dtoGenToolStripMenuItem = new ToolStripMenuItem();
            logicGenToolStripMenuItem = new ToolStripMenuItem();
            iLogicGenToolStripMenuItem = new ToolStripMenuItem();
            modelDtoGenToolStripMenuItem = new ToolStripMenuItem();
            dtoLogicGenToolStripMenuItem = new ToolStripMenuItem();
            iDtoLogicGenToolStripMenuItem = new ToolStripMenuItem();
            derivanceManipulatorToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            iLogicHandlersToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { dtoGenToolStripMenuItem, logicGenToolStripMenuItem, toolStripMenuItem1, iLogicGenToolStripMenuItem, modelDtoGenToolStripMenuItem, dtoLogicGenToolStripMenuItem, iDtoLogicGenToolStripMenuItem, derivanceManipulatorToolStripMenuItem, iLogicHandlersToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1020, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menu";
            // 
            // dtoGenToolStripMenuItem
            // 
            dtoGenToolStripMenuItem.Name = "dtoGenToolStripMenuItem";
            dtoGenToolStripMenuItem.Size = new Size(59, 20);
            dtoGenToolStripMenuItem.Text = "DtoGen";
            dtoGenToolStripMenuItem.Click += dtoGenToolStripMenuItem_Click;
            // 
            // logicGenToolStripMenuItem
            // 
            logicGenToolStripMenuItem.Name = "logicGenToolStripMenuItem";
            logicGenToolStripMenuItem.Size = new Size(69, 20);
            logicGenToolStripMenuItem.Text = "LogicGen";
            logicGenToolStripMenuItem.Click += logicGenToolStripMenuItem_Click;
            // 
            // iLogicGenToolStripMenuItem
            // 
            iLogicGenToolStripMenuItem.Name = "iLogicGenToolStripMenuItem";
            iLogicGenToolStripMenuItem.Size = new Size(72, 20);
            iLogicGenToolStripMenuItem.Text = "ILogicGen";
            iLogicGenToolStripMenuItem.Click += iLogicGenToolStripMenuItem_Click;
            // 
            // modelDtoGenToolStripMenuItem
            // 
            modelDtoGenToolStripMenuItem.Name = "modelDtoGenToolStripMenuItem";
            modelDtoGenToolStripMenuItem.Size = new Size(93, 20);
            modelDtoGenToolStripMenuItem.Text = "ModelDtoGen";
            modelDtoGenToolStripMenuItem.Click += modelDtoGenToolStripMenuItem_Click;
            // 
            // dtoLogicGenToolStripMenuItem
            // 
            dtoLogicGenToolStripMenuItem.Name = "dtoLogicGenToolStripMenuItem";
            dtoLogicGenToolStripMenuItem.Size = new Size(88, 20);
            dtoLogicGenToolStripMenuItem.Text = "DtoLogicGen";
            dtoLogicGenToolStripMenuItem.Click += dtoLogicGenToolStripMenuItem_Click;
            // 
            // iDtoLogicGenToolStripMenuItem
            // 
            iDtoLogicGenToolStripMenuItem.Name = "iDtoLogicGenToolStripMenuItem";
            iDtoLogicGenToolStripMenuItem.Size = new Size(91, 20);
            iDtoLogicGenToolStripMenuItem.Text = "IDtoLogicGen";
            iDtoLogicGenToolStripMenuItem.Click += iDtoLogicGenToolStripMenuItem_Click;
            // 
            // derivanceManipulatorToolStripMenuItem
            // 
            derivanceManipulatorToolStripMenuItem.Name = "derivanceManipulatorToolStripMenuItem";
            derivanceManipulatorToolStripMenuItem.Size = new Size(136, 20);
            derivanceManipulatorToolStripMenuItem.Text = "DerivanceManipulator";
            derivanceManipulatorToolStripMenuItem.Click += derivanceManipulatorToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(72, 20);
            toolStripMenuItem1.Text = "ILogicGen";
            // 
            // iLogicHandlersToolStripMenuItem
            // 
            iLogicHandlersToolStripMenuItem.Name = "iLogicHandlersToolStripMenuItem";
            iLogicHandlersToolStripMenuItem.Size = new Size(98, 20);
            iLogicHandlersToolStripMenuItem.Text = "ILogicHandlers";
            iLogicHandlersToolStripMenuItem.Click += iLogicHandlersToolStripMenuItem_Click;
            // 
            // GhostRiderGenEx
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1020, 533);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Name = "GhostRiderGenEx";
            Text = "Class Generator";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem dtoGenToolStripMenuItem;
        private ToolStripMenuItem logicGenToolStripMenuItem;
        private ToolStripMenuItem iLogicGenToolStripMenuItem;
        private ToolStripMenuItem modelDtoGenToolStripMenuItem;
        private ToolStripMenuItem dtoLogicGenToolStripMenuItem;
        private ToolStripMenuItem derivanceManipulatorToolStripMenuItem;
        private ToolStripMenuItem iDtoLogicGenToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem iLogicHandlersToolStripMenuItem;
    }
}