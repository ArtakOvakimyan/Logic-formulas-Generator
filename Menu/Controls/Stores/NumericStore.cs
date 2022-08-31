using System.Windows.Forms;
using Formulas_Generator.Menu.Controls.Builders;

namespace Formulas_Generator.Menu.Controls.Stores
{
    public static class NumericStore
    {
        private static NumericCreator creator = new NumericCreator();
        
        internal static Control varNum = creator.createControl(
            "Variables number",
            null);
        internal static Control formulaNum = creator.createControl(
            "Formula number",
            null);
        internal static Control formulaLen = creator.createControl(
            "Formula length",
            null);
    }
}