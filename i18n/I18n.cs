using i18n.Interfaces;
using i18n.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i18n
{
    public class I18n
    {

        private static i18nConfig config;

        public I18n(i18nConfig config)
        {
            I18n.config = config;
            ChangeLanguage(I18n.config.InitLanguage);
        }



        static async public void ChangeLanguage(string language) 
        {
            var value = await config.Loader.LoadTranslate(language);
            I18nLocaleStorage.Update(language, value);
        }
    }
}
