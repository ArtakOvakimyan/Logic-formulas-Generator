using System;
using System.Windows.Forms;
using Formulas_Generator.SysSupplies;

namespace Formulas_Generator.Menu.Controls.Stores
{
    public static class ActionsStore
    {
        internal static EventHandler infoPopOut = (_, _) => 
            MessageBox.Show(LanguageManager.getString(Constants.info, Constants.enInfo), 
                LanguageManager.getString("Информация", "Info"), 
                MessageBoxButtons.OK,
                MessageBoxIcon.Question);
        
        internal static EventHandler closeApp = (_, _) => 
            Application.Exit();
        
        internal static EventHandler switchLang = (_, _) =>
            LanguageManager.switchLang();

        internal static EventHandler chooseOperations = (_, _) =>
        {
            var newForm = new CheckForm();
            newForm.ShowDialog();
        };
    }
}