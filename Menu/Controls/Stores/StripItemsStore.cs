using System.Windows.Forms;
using Formulas_Generator.Menu.Controls.Builders;
using Formulas_Generator.SysSupplies;
using static Formulas_Generator.Menu.Controls.Stores.ActionsStore;

namespace Formulas_Generator.Menu.Controls.Stores
{
    public static class StripItemsStore
    {
        private static StripItemCreator creator = new StripItemCreator();

        internal static ToolStripMenuItem helpItem = creator.createControl(
            "Справка", 
            "Info", 
            null);
        
        internal static ToolStripMenuItem infoItem = creator.createControl(
            "О программе", 
            "About app",
            infoPopOut);
        internal static ToolStripMenuItem exitItem = creator.createControl(
            "Выход", 
            "Exit", 
            closeApp);
        
        internal static ToolStripMenuItem optionsItem = creator.createControl(
            "Опции",
            "Options",
            null);

        internal static ToolStripMenuItem languageItem = creator.createControl(
            "Смена языка",
            "Change language",
            (s, e) => LanguageManager.switchLang());
    }
}