using i18n.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i18n.Models
{
    public class i18nConfig
    {
        public string InitLanguage { get; set; }
        public ITranslateLoader Loader { get; set; }
    }
}
