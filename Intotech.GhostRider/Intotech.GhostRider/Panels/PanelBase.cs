using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.GhostRider.Panels
{
    public abstract class PanelBase : Panel
    {
        protected GeneratorRealization Realizator = new();

        protected Label Logic_Usings_Label = new Label();
        protected Label Name_Space_Label = new Label();
        protected Label Dto_Usings_Label = new Label();
        protected Label Dto_Output_Path_Label = new Label();
        protected Label Dto_Dll_Path_Label = new Label();

        protected Button DtoGen_Button = new Button();

        protected TextBox DtoNameSpaces = new TextBox();
        protected TextBox DtoUsings = new TextBox();
        protected TextBox DtoOutputDirectory = new TextBox();
        protected TextBox DtoPathAssembly = new TextBox();

        protected Font LabelsFont = new Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

        protected PanelBase()
        {
            CreateLayout();
        }

        protected virtual void CreateLayout()
        {
            CreateLabels();
            CreateTextboxes();         

            DtoGen_Button.Location = new Point(370, 424);
            DtoGen_Button.Name = "Gen_Button";
            DtoGen_Button.Size = new Size(238, 55);
            DtoGen_Button.Text = "Generate";
            DtoGen_Button.UseVisualStyleBackColor = true;
            DtoGen_Button.Click += new EventHandler(HandleClick);

            Controls.Add(Logic_Usings_Label);
            Controls.Add(Name_Space_Label);
            Controls.Add(Dto_Usings_Label);
            Controls.Add(Dto_Output_Path_Label);
            Controls.Add(Dto_Dll_Path_Label);
            Controls.Add(DtoGen_Button);
            Controls.Add(DtoNameSpaces);
            Controls.Add(DtoUsings);
            Controls.Add(DtoOutputDirectory);
            Controls.Add(DtoPathAssembly);

            Location = new Point(2, 24);
        }

        protected virtual void CreateTextboxes()
        {
            DtoNameSpaces.Location = new Point(685, 337);
            DtoNameSpaces.Multiline = true;
            DtoNameSpaces.Size = new Size(313, 156);

            DtoUsings.Location = new Point(24, 339);
            DtoUsings.Multiline = true;
            DtoUsings.Size = new Size(300, 150);

            DtoOutputDirectory.Location = new Point(682, 69);
            DtoOutputDirectory.Multiline = true;
            DtoOutputDirectory.Size = new Size(300, 181);

            DtoPathAssembly.Location = new Point(20, 68);
            DtoPathAssembly.Multiline = true;
            DtoPathAssembly.Size = new Size(310, 170);
        }

        protected virtual void CreateLabels()
        {
            Logic_Usings_Label.AutoSize = true;
            Logic_Usings_Label.Font = LabelsFont;
            Logic_Usings_Label.Location = new Point(412, 56);
            //Logic_Usings_Label.Name = "_dto_Banner_Label";
            Logic_Usings_Label.Size = new Size(98, 20);

            Name_Space_Label.AutoSize = true;
            Name_Space_Label.Location = new Point(798, 303);
            Name_Space_Label.Font = LabelsFont;
            //Name_Space_Label.Name = "_dto_Name_Space_Label";
            Name_Space_Label.Size = new Size(73, 15);

            Dto_Usings_Label.AutoSize = true;
            Dto_Usings_Label.Location = new Point(132, 305);
            Dto_Usings_Label.Font = LabelsFont;
            //Dto_Usings_Label.Name = "_dto_Usings_Label";
            Dto_Usings_Label.Size = new Size(42, 15);

            Dto_Output_Path_Label.AutoSize = true;
            Dto_Output_Path_Label.Location = new Point(792, 33);
            Dto_Output_Path_Label.Font = LabelsFont;
            //Dto_Output_Path_Label.Name = "_dto_Output_Path_Label";
            Dto_Output_Path_Label.Size = new Size(72, 15);

            Dto_Dll_Path_Label.AutoSize = true;
            Dto_Dll_Path_Label.Location = new Point(127, 39);
            Dto_Dll_Path_Label.Font = LabelsFont;
            Dto_Dll_Path_Label.Size = new Size(48, 15);
        }

        protected abstract void HandleClick(object? sender, EventArgs eventArgs);
    }
}
