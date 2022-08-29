using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Formulas_Generator.SysSupplies
{
    public static class Constants
    {
        public static readonly char sep = Path.DirectorySeparatorChar;
        private static readonly string docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public const string fileName = "result.tex";
        public const string texBegin = "\\documentclass{article}\n\\begin{document}";
        public const string texEnd = "\\end{document}";
        public static readonly string pathToWrite = $"{docsPath}{sep}{fileName}";
        public const string info = 
            "Эта программа поможет" + "\n" + "получить всевозможные формулы " + "\n" +
            "логики высказываний в зависимости" + "\n" + "от заданных параметров";
        public const string enInfo = 
            "This programm will provide you access" + "\n" + "to all possible formulas depending" +
            "\n" + "on the given values";
        
        public static readonly Size FormSize = new Size(1280, 720);
        public static readonly string LogoImagePath = $"Assets{sep}latex.png";
        public static readonly string FormImagePath = $"Assets{sep}bg.jpg";
    }
}