using System.Drawing;
using System.Windows.Forms;
using Formulas_Generator.SysSupplies;

namespace Formulas_Generator.Menu.Controls.Builders
{
    public class CheckBoxCreator
    {
        public CheckBox createControl(string ruName, string enName)
        {
            var checkBox = new CustomCheckBox()
            {
                Name = enName,
                special_en = enName,
                special_ru = ruName,
                Text = LanguageManager.getString(ruName, enName),
                Font = new Font("Arial", 11),
                Checked = true
            };
            LanguageManager.subscribe(checkBox);

            return checkBox;
        }
        
        private class CustomCheckBox: CheckBox, Observer
        {
            public string special_ru;
            public string special_en;

            public void update()
            {
                this.Text = LanguageManager.getString(special_ru, special_en);
            }
        }
    }
}