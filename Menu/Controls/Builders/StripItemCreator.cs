using System;
using System.Windows.Forms;
using Formulas_Generator.SysSupplies;

namespace Formulas_Generator.Menu.Controls.Builders
{
    public class StripItemCreator
    {
        public ToolStripMenuItem createControl(string ruName, string enName, EventHandler action)
        {
            var c = new CustomStripItem()
            {
                Text = ruName,
                special_en = enName,
                special_ru = ruName,
            };
            LanguageManager.subscribe(c);

            c.Click += action;

            return c;
        }
        
        private class CustomStripItem: ToolStripMenuItem, Observer
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