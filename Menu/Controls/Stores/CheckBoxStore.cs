using System.Windows.Forms;
using Formulas_Generator.Menu.Controls.Builders;

namespace Formulas_Generator.Menu.Controls.Stores
{
    public class CheckBoxStore
    {
        private static CheckBoxCreator creator = new CheckBoxCreator();
        internal static CheckBox not = creator.createControl("Отрицание", "Not");
        internal static CheckBox and = creator.createControl("Конъюнкция", "And");
        internal static CheckBox or = creator.createControl("Дизъюнкция", "Or");
        internal static CheckBox implies = creator.createControl("Импликация", "Implies");
        internal static CheckBox equivalent = creator.createControl("Эквиваленция", "Equivalent");
    }
}