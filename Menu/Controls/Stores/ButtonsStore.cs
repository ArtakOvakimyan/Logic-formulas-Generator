using System.Windows.Forms;
using Formulas_Generator.Math;
using Formulas_Generator.Menu.Controls.Builders;
using static Formulas_Generator.Menu.Controls.Stores.TextBoxStore;
using static Formulas_Generator.Menu.Functions;
using static Formulas_Generator.SysSupplies.Constants;

namespace Formulas_Generator.Menu.Controls.Stores
{
    public static class ButtonsStore
    {
        private static ButtonCreator creator = new ButtonCreator();

        internal static Button directoryButton = creator.createControl(
            "Выбрать директорию",
            "Choose directory",
            (_, _) =>
            {
                if (MainForm.folderBrowserDialog1.ShowDialog(MainForm.ActiveForm) == DialogResult.OK)
                {
                    box1.Text = MainForm.folderBrowserDialog1.SelectedPath + sep + fileName;
                }
            });
        internal static Button exitButton = creator.createControl(
            "Обработать",
            "Handle",
            (_, _) =>
            {
                var generator = new Generator(
                    int.Parse(NumericStore.formulaLen.Text),
                    int.Parse(NumericStore.formulaNum.Text),
                    int.Parse(NumericStore.varNum.Text)
                    );

                writeLines(box1.Text, generator);
            });
    }
}