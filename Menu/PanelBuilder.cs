using System.Windows.Forms;

namespace Formulas_Generator.Menu
{
    public abstract class PanelBuilder
    {
        protected TableLayoutPanel panel;

        public TableLayoutPanel getPanel() { return panel; }
        public void createPanel() { panel = new TableLayoutPanel();}
        public abstract void setScheme();
        public abstract void setButtons();
        public abstract void setDock();
        public abstract void setAnchor();
        public abstract void setColor();
    }
}