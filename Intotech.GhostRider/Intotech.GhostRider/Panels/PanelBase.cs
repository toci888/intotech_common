using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.GhostRider.Panels
{
    public abstract class PanelBase : Panel
    {
        protected string modelPath = null;

        protected GeneratorRealization Realizator = new();

        protected Label BannerLabel = new Label();
        protected Label NameSpaceLabel = new Label();
        protected Label UsingsLabel = new Label();
        protected Label OutputPathLabel = new Label();
        protected Label isModelSelect = new Label();

        protected Button ChooseModelsDllPath = new Button();
        protected Button Gen_Button = new Button();

        protected TextBox NameSpace = new TextBox();
        protected TextBox Usings = new TextBox();
        protected TextBox OutputDirectory = new TextBox();
        

        protected Font LabelsFont = new Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

        protected PanelBase()
        {
            CreateLayout();
        }

        protected virtual void CreateLayout()
        {
            CreateLabels();
            CreateTextboxes();
            CreateButtons();

            Controls.Add(BannerLabel);
            Controls.Add(NameSpaceLabel);
            Controls.Add(UsingsLabel);
            Controls.Add(OutputPathLabel);
            Controls.Add(isModelSelect);
            Controls.Add(Gen_Button);
            Controls.Add(NameSpace);
            Controls.Add(Usings);
            Controls.Add(OutputDirectory);
            Controls.Add(ChooseModelsDllPath);

            Location = new Point(2, 24);
        }

        protected virtual void CreateButtons()
        {
            Gen_Button.Location = new Point(370, 424);
            Gen_Button.Name = "Gen_Button";
            Gen_Button.Size = new Size(238, 55);
            Gen_Button.Text = "Generate";
            Gen_Button.Click += new EventHandler(HandleClick);


            ChooseModelsDllPath.Location = new Point(31, 56);
            ChooseModelsDllPath.Size = new Size(164, 33);
            ChooseModelsDllPath.Text = "Choose Models Dll";
            ChooseModelsDllPath.Click += new EventHandler(ChooseModelsDllPathClick);
        }
        protected virtual void CreateTextboxes()
        {
            NameSpace.Location = new Point(685, 337);
            NameSpace.Multiline = true;
            NameSpace.Size = new Size(313, 156);

            Usings.Location = new Point(24, 339);
            Usings.Multiline = true;
            Usings.Size = new Size(300, 150);

            OutputDirectory.Location = new Point(682, 69);
            OutputDirectory.Multiline = true;
            OutputDirectory.Size = new Size(300, 181);
        }
        protected virtual void CreateLabels()
        {
            BannerLabel.AutoSize = true;
            BannerLabel.Font = LabelsFont;
            BannerLabel.Location = new Point(412, 56);
            BannerLabel.Size = new Size(98, 20);

            NameSpaceLabel.AutoSize = true;
            NameSpaceLabel.Location = new Point(798, 303);
            NameSpaceLabel.Font = LabelsFont;
            NameSpaceLabel.Size = new Size(73, 15);

            UsingsLabel.AutoSize = true;
            UsingsLabel.Location = new Point(132, 305);
            UsingsLabel.Font = LabelsFont;
            UsingsLabel.Size = new Size(42, 15);

            OutputPathLabel.AutoSize = true;
            OutputPathLabel.Location = new Point(792, 33);
            OutputPathLabel.Font = LabelsFont;
            OutputPathLabel.Size = new Size(72, 15);

            isModelSelect.AutoSize = true;
            isModelSelect.Location = new Point(200, 63);
            isModelSelect.BackColor = Color.Red;
            isModelSelect.Font = LabelsFont;
            isModelSelect.Size = new Size(48, 15);
        }

        protected abstract void ChooseModelsDllPathClick(object? sender, EventArgs eventArgs);

        protected abstract void HandleClick(object? sender, EventArgs eventArgs);
    }
}
