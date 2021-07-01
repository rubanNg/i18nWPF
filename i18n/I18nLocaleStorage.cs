using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i18n
{
    public class I18nLocaleStorage
    {
        static private string storageLanguage = null;

        public static event EventHandler Languagechange = delegate { };

        static public Dictionary<string, Dictionary<string, string>> Value { get; private set; } = new Dictionary<string, Dictionary<string, string>>();

        static public void Update(string language, Dictionary<string, string> value) 
        {
            storageLanguage = language;
            if (Value.ContainsKey(language)) Value[language] = value;
            else Value.Add(language, value);
            Languagechange.Invoke(null, EventArgs.Empty);
        }


        static public string GetKeyValue(string key) 
        {
            if (storageLanguage == null || !Value.ContainsKey(storageLanguage)) return string.Empty;
            if (Value.ContainsKey(storageLanguage) && Value[storageLanguage].ContainsKey(key)) return Value[storageLanguage][key];
            return string.Empty;
        }
    }
}
