using System;
using System.Drawing;
using System.Windows.Forms;

namespace Formulas_Generator.Menu.Controls.Builders
{
    public class NumericCreator
    {
        public NumericUpDown createControl(string enName, EventHandler action)
        {
            var numericUpDown = new NumericUpDown()
            {
                Name = enName,
                Anchor = AnchorStyles.Right,
                Value = 1,
                Maximum = 100,
                Minimum = 1,
                
                Font = new Font("Bodoni MT", 12),
            };
            return numericUpDown;
        }
    }
}