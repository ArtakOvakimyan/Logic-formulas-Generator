using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Formulas_Generator.Math;
using Formulas_Generator.SysSupplies;
using static Formulas_Generator.SysSupplies.Constants;

namespace Formulas_Generator.Menu
{
    public static class Functions
    {
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

        public static string formatString(this string s)
        {
            StringBuilder sb = new StringBuilder();
            var j = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == 'x')
                {
                    sb.AppendFormat("x{0}", j % 3);
                    j ++;
                }
                else
                {
                    sb.Append(s[i]);
                }
            }
            return sb.ToString();
        }
    }
}