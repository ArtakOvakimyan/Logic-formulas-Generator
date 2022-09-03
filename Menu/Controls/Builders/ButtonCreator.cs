using System;
using System.Drawing;
using System.Windows.Forms;
using Formulas_Generator.SysSupplies;

namespace Formulas_Generator.Menu.Controls.Builders
{
    public class ButtonCreator
    {
        public Button createControl(string ruName, string enName, EventHandler action)
        {
            var button = new CustomButton()
            {
                Text = ruName,
                special_en = enName,
                special_ru = ruName,
                Anchor = AnchorStyles.Right,
                Dock = DockStyle.None,
                MinimumSize = new Size(90, 30),
                Size = new Size(200,50),
                Font = new Font("Arial", 11),
                ForeColor = Color.Black,
                BackColor = Color.Bisque,
                FlatStyle = FlatStyle.Standard
            };
            LanguageManager.subscribe(button);
            button.GotFocus += (_, _) => button.BackColor = Color.PeachPuff;
            button.MouseEnter += (_, _) => button.BackColor = Color.PeachPuff;

            button.LostFocus += (_, _) => button.BackColor = Color.Bisque;
            button.MouseLeave += (_, _) => button.BackColor = Color.Bisque;

            button.Click += action;

            return button;
        }

        private class CustomButton: Button, Observer
        {
            public string special_ru;
            public string special_en;

            public void update()
            {
                Text = LanguageManager.getString(special_ru, special_en);
            }
        }
    }
}