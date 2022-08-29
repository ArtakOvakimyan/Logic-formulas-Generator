using System;
using System.IO;
using System.Windows.Forms;
using Formulas_Generator.Math;
using Formulas_Generator.SysSupplies;
using static Formulas_Generator.SysSupplies.Constants;

namespace Formulas_Generator.Menu
{
    public static class Functions
    {
        public static void chooseFolder(Control box)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog();

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                box.Text = folderBrowserDialog1.SelectedPath + sep + fileName;
            }
        }

        public static async void writeLines(object path, Generator gen)
        {
            var lines = await gen.getLines();
            using (var fileStream = new FileStream((string)path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var fileWriter = new StreamWriter(fileStream))
                {
                    fileWriter.WriteLine(texBegin);
                    fileWriter.WriteLine(@"\noindent");
                    foreach (var line in lines)
                    {
                        fileWriter.WriteLine("$" + line + @"$\\");
                    }
                    fileWriter.WriteLine(texEnd);
                }
            }
        }
    }
}