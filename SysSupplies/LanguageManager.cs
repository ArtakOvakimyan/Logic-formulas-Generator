using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Formulas_Generator.SysSupplies
{
    public static class LanguageManager
    {
        private static List<Observer> list = new List<Observer>();

        private enum Language {ru, en}

        private static Language lang;

        static LanguageManager()
        {
            lang = System.Threading.Thread.CurrentThread.CurrentUICulture.Name.StartsWith("ru") ? 
                Language.ru : Language.en;
        }

        private static void setLangRU()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru");
            lang = Language.ru;
        }

        private static void setLangEN()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            lang = Language.en;
        }

        public static void switchLang()
        {
            if (getCurrentLang == Language.ru)
                setLangEN();
            else
                setLangRU();
            notifyAll();
        }

        public static string getString(string ruStr, string enStr)
        {
            return lang switch
            {
                Language.ru => ruStr,
                Language.en => enStr,
                _ => ruStr
            };
        }

        private static Language getCurrentLang => lang;

        private static void notifyAll()
        {
            foreach (var control in list)
            {
                control.update();
            }
        }

        public static void subscribe(Observer control)
        {
            list.Add(control);
        }
    }
}