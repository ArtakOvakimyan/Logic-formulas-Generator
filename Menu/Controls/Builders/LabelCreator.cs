using System.Drawing;
using System.Windows.Forms;
using Formulas_Generator.SysSupplies;

namespace Formulas_Generator.Menu.Controls.Builders
{
    public class LabelCreator
    {
        public Label createControl(string ruName, string enName)
        {
            var lb = new CustomLabel()
            {
                special_en = enName,
                special_ru = ruName,
                Text = ruName,
                Dock = DockStyle.Fill,
                Anchor = AnchorStyles.Left,
                AutoSize = true,
                Font = new Font("Arial", 13)
            };
            LanguageManager.subscribe(lb);
            
            return lb;
        }

        private class CustomLabel: Label, Observer
        {
            public string special_ru;
            public string special_en;

            public void update()
            {
                Text = LanguageManager.getString(special_ru, special_en);
            }
        }
    }
}