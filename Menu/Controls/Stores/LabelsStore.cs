using System.Windows.Forms;
using Formulas_Generator.Menu.Controls.Builders;

namespace Formulas_Generator.Menu.Controls.Stores
{
    public static class LabelsStore
    {
        private static LabelCreator creator = new LabelCreator();

        internal static Control varLabel = creator.createControl(
            "Количество доступных литералов:", 
            "Variables avilable number:");
        internal static Control formulaLabel = creator.createControl(
            "Количество формул:", 
            "Formulas number:");
        internal static Control lenLabel = creator.createControl(
            "Длина каждой формулы:", 
            "Formula length:");
    }
}