using System.Windows.Forms;
using static Formulas_Generator.Menu.Controls.Stores.StripItemsStore;

namespace Formulas_Generator.Menu.Controls.Builders
{
    public class MenuStripBuilder
    {
        private MenuStrip strip = new MenuStrip()
        {
            Dock = DockStyle.Top
        };
        

        public MenuStripBuilder()
        {
            constructStrip();
        }

        private void constructStrip()
        {
            helpItem.DropDownItems.Add(infoItem);
            optionsItem.DropDownItems.Add(languageItem);
            optionsItem.DropDownItems.Add(exitItem);
            
            strip.Items.Add(optionsItem);
            strip.Items.Add(operationsItem);
            strip.Items.Add(helpItem);

        }
        public MenuStrip getStrip()
        {
            return strip;
        }
    }
}