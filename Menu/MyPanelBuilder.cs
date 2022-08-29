using System.Drawing;
using System.Windows.Forms;
using static Formulas_Generator.Menu.Controls.Stores.NumericStore;
using static Formulas_Generator.Menu.Controls.Stores.ButtonsStore;
using static Formulas_Generator.Menu.Controls.Stores.TextBoxStore;
using static Formulas_Generator.Menu.Controls.Stores.LabelsStore;

namespace Formulas_Generator.Menu
{
    public class MyPanelBuilder: PanelBuilder
    {
        public override void setScheme()
        {
            panel.RowStyles.Clear();
            
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            for (var i = 0; i < 4; i++)
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 20));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 10));

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            
            panel.Controls.Add(new Panel() { BackColor = Color.Transparent }, 4, 0);
            panel.Controls.Add(new Panel() {BackColor = Color.Transparent}, 1, 5);
        }

        public override void setButtons()
        {
            panel.Controls.Add(varNum, 3, 1);
            panel.Controls.Add(formulaNum, 3, 2);
            panel.Controls.Add(formulaLen, 3, 3);
            panel.Controls.Add(exitButton, 3, 4);
            panel.Controls.Add(directoryButton, 2, 4);
            panel.Controls.Add(box1, 1, 4);
            panel.Controls.Add(varLabel, 2, 1);
            panel.Controls.Add(formulaLabel, 2, 2);
            panel.Controls.Add(lenLabel, 2, 3);
        }

        public override void setDock() { panel.Dock = DockStyle.Fill; }

        public override void setAnchor() { panel.Anchor = AnchorStyles.Top; }

        public override void setColor() { panel.BackColor = Color.Transparent; }
    }
}