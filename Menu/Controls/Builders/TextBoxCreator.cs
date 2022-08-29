using System;
using System.Drawing;
using System.Windows.Forms;

namespace Formulas_Generator.Menu.Controls.Builders
{
    public class TextBoxCreator
    {
        public TextBox createControl(string path, EventHandler action)
        {
            var txtB = new TextBox()
            {
                Text = path,
                Anchor = AnchorStyles.Right,
                Dock = DockStyle.None,
                Width = 500,
                Font = new Font("Bodoni MT", 12),
                ReadOnly = true
            };
            
            return txtB;
        }
    }
}
