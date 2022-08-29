using System.Windows.Forms;

namespace Formulas_Generator.Menu
{
    public class PanelPresenter
    {
        private PanelBuilder panelBuilder;

        public PanelPresenter(PanelBuilder panelBuilder)
        {
            this.panelBuilder = panelBuilder;
        }

        public TableLayoutPanel getPanel()
        {
            constructPanel();
            return panelBuilder.getPanel();
        }

        private void constructPanel() {
            panelBuilder.createPanel();
            panelBuilder.setScheme();
            panelBuilder.setAnchor();
            panelBuilder.setDock();
            panelBuilder.setColor();
            panelBuilder.setButtons();
        }
    }
}