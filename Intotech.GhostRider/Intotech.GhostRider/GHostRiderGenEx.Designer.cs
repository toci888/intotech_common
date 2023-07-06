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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dtoGenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logicGenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iLogicGenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modelDtoGenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtoLogicGenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.derivanceManipulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iDtoLogicGenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dtoGenToolStripMenuItem,
            this.logicGenToolStripMenuItem,
            this.iLogicGenToolStripMenuItem,
            this.modelDtoGenToolStripMenuItem,
            this.dtoLogicGenToolStripMenuItem,
            this.iDtoLogicGenToolStripMenuItem,
            this.derivanceManipulatorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1020, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menu";
            // 
            // dtoGenToolStripMenuItem
            // 
            this.dtoGenToolStripMenuItem.Name = "dtoGenToolStripMenuItem";
            this.dtoGenToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.dtoGenToolStripMenuItem.Text = "DtoGen";
            this.dtoGenToolStripMenuItem.Click += new System.EventHandler(this.dtoGenToolStripMenuItem_Click);
            // 
            // logicGenToolStripMenuItem
            // 
            this.logicGenToolStripMenuItem.Name = "logicGenToolStripMenuItem";
            this.logicGenToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.logicGenToolStripMenuItem.Text = "LogicGen";
            this.logicGenToolStripMenuItem.Click += new System.EventHandler(this.logicGenToolStripMenuItem_Click);
            // 
            // iLogicGenToolStripMenuItem
            // 
            this.iLogicGenToolStripMenuItem.Name = "iLogicGenToolStripMenuItem";
            this.iLogicGenToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.iLogicGenToolStripMenuItem.Text = "ILogicGen";
            this.iLogicGenToolStripMenuItem.Click += new System.EventHandler(this.iLogicGenToolStripMenuItem_Click);
            // 
            // modelDtoGenToolStripMenuItem
            // 
            this.modelDtoGenToolStripMenuItem.Name = "modelDtoGenToolStripMenuItem";
            this.modelDtoGenToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.modelDtoGenToolStripMenuItem.Text = "ModelDtoGen";
            this.modelDtoGenToolStripMenuItem.Click += new System.EventHandler(this.modelDtoGenToolStripMenuItem_Click);
            // 
            // dtoLogicGenToolStripMenuItem
            // 
            this.dtoLogicGenToolStripMenuItem.Name = "dtoLogicGenToolStripMenuItem";
            this.dtoLogicGenToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.dtoLogicGenToolStripMenuItem.Text = "DtoLogicGen";
            this.dtoLogicGenToolStripMenuItem.Click += new System.EventHandler(this.dtoLogicGenToolStripMenuItem_Click);
            // 
            // derivanceManipulatorToolStripMenuItem
            // 
            this.derivanceManipulatorToolStripMenuItem.Name = "derivanceManipulatorToolStripMenuItem";
            this.derivanceManipulatorToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.derivanceManipulatorToolStripMenuItem.Text = "DerivanceManipulator";
            this.derivanceManipulatorToolStripMenuItem.Click += new System.EventHandler(this.derivanceManipulatorToolStripMenuItem_Click);
            // 
            // iDtoLogicGenToolStripMenuItem
            // 
            this.iDtoLogicGenToolStripMenuItem.Name = "iDtoLogicGenToolStripMenuItem";
            this.iDtoLogicGenToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.iDtoLogicGenToolStripMenuItem.Text = "IDtoLogicGen";
            this.iDtoLogicGenToolStripMenuItem.Click += new System.EventHandler(this.iDtoLogicGenToolStripMenuItem_Click);
            // 
            // GhostRiderGenEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1020, 533);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GhostRiderGenEx";
            this.Text = "Class Generator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}