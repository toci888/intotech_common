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
            this._dtoGen_Panel = new System.Windows.Forms.Panel();
            this._dto_Banner_Label = new System.Windows.Forms.Label();
            this._dto_Name_Spaces_Label = new System.Windows.Forms.Label();
            this._dto_Usings_Label = new System.Windows.Forms.Label();
            this._dto_Output_Path_Label = new System.Windows.Forms.Label();
            this._dto_Dll_Path_Label = new System.Windows.Forms.Label();
            this._dtoGen_Button = new System.Windows.Forms.Button();
            this._dtoNameSpaces = new System.Windows.Forms.TextBox();
            this._dtoUsings = new System.Windows.Forms.TextBox();
            this._dtoOutputDirectory = new System.Windows.Forms.TextBox();
            this._dtoPathAssembly = new System.Windows.Forms.TextBox();
            this._modelDto_GenPanel = new System.Windows.Forms.Panel();
            this._modelDto_Banner_Label = new System.Windows.Forms.Label();
            this._modelDto_GenButton = new System.Windows.Forms.Button();
            this._modelDto_Name_Spaces_Label = new System.Windows.Forms.Label();
            this._modelDto_Usings_Label = new System.Windows.Forms.Label();
            this._modelDto_Output_Directory_Label = new System.Windows.Forms.Label();
            this._modelDto_Dll_Path_Label = new System.Windows.Forms.Label();
            this._modelDtoNameSpaces = new System.Windows.Forms.TextBox();
            this._modelDtoOutputDirectory = new System.Windows.Forms.TextBox();
            this._modelDtoUsings = new System.Windows.Forms.TextBox();
            this._modelDtoPathAssembly = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this._dtoGen_Panel.SuspendLayout();
            this._modelDto_GenPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dtoGenToolStripMenuItem,
            this.logicGenToolStripMenuItem,
            this.iLogicGenToolStripMenuItem,
            this.modelDtoGenToolStripMenuItem,
            this.dtoLogicGenToolStripMenuItem});
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
            // _dtoGen_Panel
            // 
            this._dtoGen_Panel.Controls.Add(this._dto_Banner_Label);
            this._dtoGen_Panel.Controls.Add(this._dto_Name_Spaces_Label);
            this._dtoGen_Panel.Controls.Add(this._dto_Usings_Label);
            this._dtoGen_Panel.Controls.Add(this._dto_Output_Path_Label);
            this._dtoGen_Panel.Controls.Add(this._dto_Dll_Path_Label);
            this._dtoGen_Panel.Controls.Add(this._dtoGen_Button);
            this._dtoGen_Panel.Controls.Add(this._dtoNameSpaces);
            this._dtoGen_Panel.Controls.Add(this._dtoUsings);
            this._dtoGen_Panel.Controls.Add(this._dtoOutputDirectory);
            this._dtoGen_Panel.Controls.Add(this._dtoPathAssembly);
            this._dtoGen_Panel.Location = new System.Drawing.Point(2, 24);
            this._dtoGen_Panel.Name = "_dtoGen_Panel";
            this._dtoGen_Panel.Size = new System.Drawing.Size(0, 0);
            this._dtoGen_Panel.TabIndex = 1;
            // 
            // _dto_Banner_Label
            // 
            this._dto_Banner_Label.AutoSize = true;
            this._dto_Banner_Label.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._dto_Banner_Label.Location = new System.Drawing.Point(412, 56);
            this._dto_Banner_Label.Name = "_dto_Banner_Label";
            this._dto_Banner_Label.Size = new System.Drawing.Size(126, 20);
            this._dto_Banner_Label.TabIndex = 10;
            this._dto_Banner_Label.Text = "Dto Generation";
            // 
            // _dto_Name_Spaces_Label
            // 
            this._dto_Name_Spaces_Label.AutoSize = true;
            this._dto_Name_Spaces_Label.Location = new System.Drawing.Point(798, 303);
            this._dto_Name_Spaces_Label.Name = "_dto_Name_Spaces_Label";
            this._dto_Name_Spaces_Label.Size = new System.Drawing.Size(78, 15);
            this._dto_Name_Spaces_Label.TabIndex = 8;
            this._dto_Name_Spaces_Label.Text = "Name Spaces";
            // 
            // _dto_Usings_Label
            // 
            this._dto_Usings_Label.AutoSize = true;
            this._dto_Usings_Label.Location = new System.Drawing.Point(132, 305);
            this._dto_Usings_Label.Name = "_dto_Usings_Label";
            this._dto_Usings_Label.Size = new System.Drawing.Size(42, 15);
            this._dto_Usings_Label.TabIndex = 7;
            this._dto_Usings_Label.Text = "Usings";
            // 
            // _dto_Output_Path_Label
            // 
            this._dto_Output_Path_Label.AutoSize = true;
            this._dto_Output_Path_Label.Location = new System.Drawing.Point(792, 33);
            this._dto_Output_Path_Label.Name = "_dto_Output_Path_Label";
            this._dto_Output_Path_Label.Size = new System.Drawing.Size(72, 15);
            this._dto_Output_Path_Label.TabIndex = 6;
            this._dto_Output_Path_Label.Text = "Output Path";
            // 
            // _dto_Dll_Path_Label
            // 
            this._dto_Dll_Path_Label.AutoSize = true;
            this._dto_Dll_Path_Label.Location = new System.Drawing.Point(127, 39);
            this._dto_Dll_Path_Label.Name = "_dto_Dll_Path_Label";
            this._dto_Dll_Path_Label.Size = new System.Drawing.Size(48, 15);
            this._dto_Dll_Path_Label.TabIndex = 5;
            this._dto_Dll_Path_Label.Text = "Dll Path";
            // 
            // _dtoGen_Button
            // 
            this._dtoGen_Button.Location = new System.Drawing.Point(370, 424);
            this._dtoGen_Button.Name = "_dtoGen_Button";
            this._dtoGen_Button.Size = new System.Drawing.Size(238, 55);
            this._dtoGen_Button.TabIndex = 4;
            this._dtoGen_Button.Text = "Generate";
            this._dtoGen_Button.UseVisualStyleBackColor = true;
            this._dtoGen_Button.Click += new System.EventHandler(this.DtoGenButton_Click);
            // 
            // _dtoNameSpaces
            // 
            this._dtoNameSpaces.Location = new System.Drawing.Point(685, 337);
            this._dtoNameSpaces.Multiline = true;
            this._dtoNameSpaces.Name = "_dtoNameSpaces";
            this._dtoNameSpaces.Size = new System.Drawing.Size(313, 156);
            this._dtoNameSpaces.TabIndex = 3;
            this._dtoNameSpaces.Text = "namespace Intotech.Wheelo.Bll.Models.Dtos;";
            // 
            // _dtoUsings
            // 
            this._dtoUsings.Location = new System.Drawing.Point(24, 339);
            this._dtoUsings.Multiline = true;
            this._dtoUsings.Name = "_dtoUsings";
            this._dtoUsings.Size = new System.Drawing.Size(300, 150);
            this._dtoUsings.TabIndex = 2;
            this._dtoUsings.Text = "using Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;";
            // 
            // _dtoOutputDirectory
            // 
            this._dtoOutputDirectory.Location = new System.Drawing.Point(682, 69);
            this._dtoOutputDirectory.Multiline = true;
            this._dtoOutputDirectory.Name = "_dtoOutputDirectory";
            this._dtoOutputDirectory.Size = new System.Drawing.Size(300, 181);
            this._dtoOutputDirectory.TabIndex = 1;
            this._dtoOutputDirectory.Text = "C:\\Users\\stasx\\Documents\\GitHub\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interface" +
    "s\\Intotech.Wheelo.Bll.Models\\Dtos\\";
            // 
            // _dtoPathAssembly
            // 
            this._dtoPathAssembly.Location = new System.Drawing.Point(20, 68);
            this._dtoPathAssembly.Multiline = true;
            this._dtoPathAssembly.Name = "_dtoPathAssembly";
            this._dtoPathAssembly.Size = new System.Drawing.Size(310, 170);
            this._dtoPathAssembly.TabIndex = 0;
            this._dtoPathAssembly.Text = "C:\\Users\\stasx\\Documents\\GitHub\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interface" +
    "s\\Toci.Driver.Database.Persistence\\bin\\Debug\\net7.0\\Toci.Driver.Database.Persist" +
    "ence.dll";
            // 
            // _modelDto_GenPanel
            // 
            this._modelDto_GenPanel.Controls.Add(this._modelDto_Banner_Label);
            this._modelDto_GenPanel.Controls.Add(this._modelDto_GenButton);
            this._modelDto_GenPanel.Controls.Add(this._modelDto_Name_Spaces_Label);
            this._modelDto_GenPanel.Controls.Add(this._modelDto_Usings_Label);
            this._modelDto_GenPanel.Controls.Add(this._modelDto_Output_Directory_Label);
            this._modelDto_GenPanel.Controls.Add(this._modelDto_Dll_Path_Label);
            this._modelDto_GenPanel.Controls.Add(this._modelDtoNameSpaces);
            this._modelDto_GenPanel.Controls.Add(this._modelDtoOutputDirectory);
            this._modelDto_GenPanel.Controls.Add(this._modelDtoUsings);
            this._modelDto_GenPanel.Controls.Add(this._modelDtoPathAssembly);
            this._modelDto_GenPanel.Location = new System.Drawing.Point(3, 25);
            this._modelDto_GenPanel.Name = "_modelDto_GenPanel";
            this._modelDto_GenPanel.Size = new System.Drawing.Size(0, 0);
            this._modelDto_GenPanel.TabIndex = 9;
            // 
            // _modelDto_Banner_Label
            // 
            this._modelDto_Banner_Label.AutoSize = true;
            this._modelDto_Banner_Label.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._modelDto_Banner_Label.Location = new System.Drawing.Point(404, 73);
            this._modelDto_Banner_Label.Name = "_modelDto_Banner_Label";
            this._modelDto_Banner_Label.Size = new System.Drawing.Size(169, 20);
            this._modelDto_Banner_Label.TabIndex = 9;
            this._modelDto_Banner_Label.Text = "ModelDto Generation";
            // 
            // _modelDto_GenButton
            // 
            this._modelDto_GenButton.Location = new System.Drawing.Point(410, 398);
            this._modelDto_GenButton.Name = "_modelDto_GenButton";
            this._modelDto_GenButton.Size = new System.Drawing.Size(175, 39);
            this._modelDto_GenButton.TabIndex = 8;
            this._modelDto_GenButton.Text = "Generate";
            this._modelDto_GenButton.UseVisualStyleBackColor = true;
            this._modelDto_GenButton.Click += new System.EventHandler(this._modelDto_GenButton_Click);
            // 
            // _modelDto_Name_Spaces_Label
            // 
            this._modelDto_Name_Spaces_Label.AutoSize = true;
            this._modelDto_Name_Spaces_Label.Location = new System.Drawing.Point(809, 299);
            this._modelDto_Name_Spaces_Label.Name = "_modelDto_Name_Spaces_Label";
            this._modelDto_Name_Spaces_Label.Size = new System.Drawing.Size(78, 15);
            this._modelDto_Name_Spaces_Label.TabIndex = 7;
            this._modelDto_Name_Spaces_Label.Text = "Name Spaces";
            // 
            // _modelDto_Usings_Label
            // 
            this._modelDto_Usings_Label.AutoSize = true;
            this._modelDto_Usings_Label.Location = new System.Drawing.Point(129, 300);
            this._modelDto_Usings_Label.Name = "_modelDto_Usings_Label";
            this._modelDto_Usings_Label.Size = new System.Drawing.Size(42, 15);
            this._modelDto_Usings_Label.TabIndex = 6;
            this._modelDto_Usings_Label.Text = "Usings";
            // 
            // _modelDto_Output_Directory_Label
            // 
            this._modelDto_Output_Directory_Label.AutoSize = true;
            this._modelDto_Output_Directory_Label.Location = new System.Drawing.Point(791, 86);
            this._modelDto_Output_Directory_Label.Name = "_modelDto_Output_Directory_Label";
            this._modelDto_Output_Directory_Label.Size = new System.Drawing.Size(96, 15);
            this._modelDto_Output_Directory_Label.TabIndex = 5;
            this._modelDto_Output_Directory_Label.Text = "Output Directory";
            // 
            // _modelDto_Dll_Path_Label
            // 
            this._modelDto_Dll_Path_Label.AutoSize = true;
            this._modelDto_Dll_Path_Label.Location = new System.Drawing.Point(117, 91);
            this._modelDto_Dll_Path_Label.Name = "_modelDto_Dll_Path_Label";
            this._modelDto_Dll_Path_Label.Size = new System.Drawing.Size(48, 15);
            this._modelDto_Dll_Path_Label.TabIndex = 4;
            this._modelDto_Dll_Path_Label.Text = "Dll Path";
            // 
            // _modelDtoNameSpaces
            // 
            this._modelDtoNameSpaces.Location = new System.Drawing.Point(710, 325);
            this._modelDtoNameSpaces.Multiline = true;
            this._modelDtoNameSpaces.Name = "_modelDtoNameSpaces";
            this._modelDtoNameSpaces.Size = new System.Drawing.Size(275, 132);
            this._modelDtoNameSpaces.TabIndex = 3;
            this._modelDtoNameSpaces.Text = "namespace Intotech.Wheelo.Bll.Models.ModelDtos.Intotech.Wheelo.Dtos;";
            // 
            // _modelDtoOutputDirectory
            // 
            this._modelDtoOutputDirectory.Location = new System.Drawing.Point(706, 128);
            this._modelDtoOutputDirectory.Multiline = true;
            this._modelDtoOutputDirectory.Name = "_modelDtoOutputDirectory";
            this._modelDtoOutputDirectory.Size = new System.Drawing.Size(274, 146);
            this._modelDtoOutputDirectory.TabIndex = 2;
            this._modelDtoOutputDirectory.Text = "C:\\Users\\stasx\\Documents\\GitHub\\intotech_wheelo\\Toci.Driver.Bll.Porsche.Interface" +
    "s\\Intotech.Wheelo.Bll.Models\\ModelDtos\\Intotech.Wheelo.Dtos\\";
            // 
            // _modelDtoUsings
            // 
            this._modelDtoUsings.Location = new System.Drawing.Point(40, 335);
            this._modelDtoUsings.Multiline = true;
            this._modelDtoUsings.Name = "_modelDtoUsings";
            this._modelDtoUsings.Size = new System.Drawing.Size(232, 152);
            this._modelDtoUsings.TabIndex = 1;
            this._modelDtoUsings.Text = "using Intotech.Common.Bll.ChorDtoBll.Dto;\r\nusing Toci.Driver.Database.Persistence" +
    ".Models;";
            // 
            // _modelDtoPathAssembly
            // 
            this._modelDtoPathAssembly.Location = new System.Drawing.Point(46, 125);
            this._modelDtoPathAssembly.Multiline = true;
            this._modelDtoPathAssembly.Name = "_modelDtoPathAssembly";
            this._modelDtoPathAssembly.Size = new System.Drawing.Size(237, 131);
            this._modelDtoPathAssembly.TabIndex = 0;
            this._modelDtoPathAssembly.Text = "C:\\\\Users\\\\stasx\\\\Documents\\\\GitHub\\\\intotech_wheelo\\\\Toci.Driver.Bll.Porsche.Int" +
    "erfaces\\\\Toci.Driver.Database.Persistence\\\\bin\\\\Debug\\\\net7.0\\\\Toci.Driver.Datab" +
    "ase.Persistence.dll";
            // 
            // GhostRiderGenEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1020, 533);
            this.Controls.Add(this._dtoGen_Panel);
            this.Controls.Add(this._modelDto_GenPanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GhostRiderGenEx";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this._dtoGen_Panel.ResumeLayout(false);
            this._dtoGen_Panel.PerformLayout();
            this._modelDto_GenPanel.ResumeLayout(false);
            this._modelDto_GenPanel.PerformLayout();
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
        private Panel _dtoGen_Panel;
        private TextBox _dtoPathAssembly;
        private TextBox _dtoOutputDirectory;
        private TextBox _dtoUsings;
        private TextBox _dtoNameSpaces;
        private Button _dtoGen_Button;
        private Label _dto_Name_Spaces_Label;
        private Label _dto_Usings_Label;
        private Label _dto_Output_Path_Label;
        private Label _dto_Dll_Path_Label;
        private Panel _modelDto_GenPanel;
        private TextBox textBox1;
        private Button _modelDto_GenButton;
        private Label _modelDto_Name_Spaces_Label;
        private Label _modelDto_Usings_Label;
        private Label _modelDto_Output_Directory_Label;
        private Label _modelDto_Dll_Path_Label;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label _dto_Banner_Label;
        private Label _modelDto_Banner_Label;
        private TextBox _modelDtoPathAssembly;
        private TextBox _modelDtoOutputDirectory;
        private TextBox _modelDtoUsings;
        private TextBox _modelDtoNameSpaces;
    }
}