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
            modelDtoGenToolStripMenuItem1 = new ToolStripMenuItem();
            dtoGenToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            logicGenToolStripMenuItem1 = new ToolStripMenuItem();
            iLogicGenToolStripMenuItem1 = new ToolStripMenuItem();
            dtoLogicGenToolStripMenuItem = new ToolStripMenuItem();
            iDtoLogicGenToolStripMenuItem = new ToolStripMenuItem();
            derivanceManipulatorToolStripMenuItem = new ToolStripMenuItem();
            iLogicHandlersToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { dtoGenToolStripMenuItem, toolStripMenuItem1, dtoLogicGenToolStripMenuItem, iDtoLogicGenToolStripMenuItem, derivanceManipulatorToolStripMenuItem, iLogicHandlersToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1020, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menu";
            // 
            // dtoGenToolStripMenuItem
            // 
            dtoGenToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { modelDtoGenToolStripMenuItem1, dtoGenToolStripMenuItem1 });
            dtoGenToolStripMenuItem.Name = "dtoGenToolStripMenuItem";
            dtoGenToolStripMenuItem.Size = new Size(59, 20);
            dtoGenToolStripMenuItem.Text = "DtoGen";
            dtoGenToolStripMenuItem.Click += dtoGenToolStripMenuItem_Click;
            // 
            // modelDtoGenToolStripMenuItem1
            // 
            modelDtoGenToolStripMenuItem1.Name = "modelDtoGenToolStripMenuItem1";
            modelDtoGenToolStripMenuItem1.Size = new Size(180, 22);
            modelDtoGenToolStripMenuItem1.Text = "ModelDtoGen";
            modelDtoGenToolStripMenuItem1.Click += modelDtoGenToolStripMenuItem1_Click;
            // 
            // dtoGenToolStripMenuItem1
            // 
            dtoGenToolStripMenuItem1.Name = "dtoGenToolStripMenuItem1";
            dtoGenToolStripMenuItem1.Size = new Size(180, 22);
            dtoGenToolStripMenuItem1.Text = "DtoGen";
            dtoGenToolStripMenuItem1.Click += dtoGenToolStripMenuItem1_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { logicGenToolStripMenuItem1, iLogicGenToolStripMenuItem1 });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(78, 20);
            toolStripMenuItem1.Text = "I & LogicGen";
            // 
            // logicGenToolStripMenuItem1
            // 
            logicGenToolStripMenuItem1.Name = "logicGenToolStripMenuItem1";
            logicGenToolStripMenuItem1.Size = new Size(127, 22);
            logicGenToolStripMenuItem1.Text = "LogicGen";
            logicGenToolStripMenuItem1.Click += logicGenToolStripMenuItem1_Click;
            // 
            // iLogicGenToolStripMenuItem1
            // 
            iLogicGenToolStripMenuItem1.Name = "iLogicGenToolStripMenuItem1";
            iLogicGenToolStripMenuItem1.Size = new Size(127, 22);
            iLogicGenToolStripMenuItem1.Text = "ILogicGen";
            iLogicGenToolStripMenuItem1.Click += iLogicGenToolStripMenuItem1_Click;
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
        private ToolStripMenuItem dtoLogicGenToolStripMenuItem;
        private ToolStripMenuItem derivanceManipulatorToolStripMenuItem;
        private ToolStripMenuItem iDtoLogicGenToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem iLogicHandlersToolStripMenuItem;
        private ToolStripMenuItem logicGenToolStripMenuItem1;
        private ToolStripMenuItem iLogicGenToolStripMenuItem1;
        private ToolStripMenuItem modelDtoGenToolStripMenuItem1;
        private ToolStripMenuItem dtoGenToolStripMenuItem1;
    }
}