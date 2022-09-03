using System.Windows.Forms;
using Formulas_Generator.Menu.Controls.Builders;
using static Formulas_Generator.SysSupplies.Constants;

namespace Formulas_Generator.Menu.Controls.Stores
{
    public static class TextBoxStore
    {
        private static TextBoxCreator creator = new TextBoxCreator();
        internal static TextBox box1 = creator.createControl(pathToWrite, null);
    }
}