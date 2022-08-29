using System;
using System.Drawing;
using System.Windows.Forms;
using Formulas_Generator.Menu;
using Formulas_Generator.Menu.Controls.Builders;
using static Formulas_Generator.SysSupplies.Constants;

namespace Formulas_Generator
{
    public sealed class MainForm : Form
    {
        private PanelPresenter panelPresenter;
        private MenuStripBuilder stripBuilder;
        public static FolderBrowserDialog folderBrowserDialog1;
        
        public MainForm()
        {
            initializeComponent();
        }

        private void initializeComponent()
        {
            BackgroundImage = Image.FromFile(FormImagePath);
            Size = FormSize;
            FormBorderStyle = FormBorderStyle.Fixed3D;

            MinimumSize = FormSize;
            MaximumSize = MinimumSize;

            folderBrowserDialog1 = new FolderBrowserDialog();
            stripBuilder = new MenuStripBuilder();
            panelPresenter = new PanelPresenter(new MyPanelBuilder());
            Controls.Add(stripBuilder.getStrip());
            Controls.Add(panelPresenter.getPanel());
            Paint += (sender, args) => args.Graphics.DrawImage(Image.FromFile(LogoImagePath), 270, 150);
        }
    }
}