using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Formulas_Generator.Math;
using Formulas_Generator.SysSupplies;
using static Formulas_Generator.Menu.Controls.Stores.CheckBoxStore;

namespace Formulas_Generator.Menu.Controls.Stores
{
    public class CheckForm: Form
    {
        private List<CheckBox> options = new List<CheckBox>() {not, and, or, implies, equivalent};
        private GroupBox group1 = new GroupBox()
        {
            Font = new Font("Arial", 11)
        };
        
        public CheckForm()
        {
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(200, 220);
            Text = LanguageManager.getString("Операции", "Operations");

            group1.Parent = this;
            group1.Text = LanguageManager.getString("Выберите операции", "Choose operations");
            group1.Bounds = new Rectangle(10, 10, 180, 200);

            foreach (var option in options.Select((value, index) => new {index, value}))
            {
                option.value.Parent = group1;
                option.value.Size = new Size(140, 20);
                option.value.Location = new Point(20, 30 + 30 * option.index);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (options.All(op => op.Checked == false))
            {
                MessageBox.Show(
                    LanguageManager.getString("Выберите хотя бы одну связку", "Choose at least one operation"),
                    LanguageManager.getString("Предупреждение!", "Warning!"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else
            {
                Generator.setOperations(
                    options
                    .Where(op => op.Checked == false)
                    .Select(x => x.Name));
            }
        }
    }
}