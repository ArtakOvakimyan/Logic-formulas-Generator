using System;
using System.Windows.Forms;
using Formulas_Generator.SysSupplies;

namespace Formulas_Generator.Menu.Controls.Stores
{
    public static class ActionsStore
    {
        internal static EventHandler infoPopOut = (s, e) => 
            MessageBox.Show(LanguageManager.getString(Constants.info, Constants.enInfo), 
                LanguageManager.getString("Информация", "Info"), 
                MessageBoxButtons.OK,
                MessageBoxIcon.Question);
        
        internal static EventHandler closeApp = (s, e) => 
            Application.Exit();
        
        internal static EventHandler switchLang = (s, e) =>
            LanguageManager.switchLang();
    }
}