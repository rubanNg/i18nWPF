using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace i18n.Interfaces
{
    public interface ITranslateLoader
    {
        Task<Dictionary<string, string>> LoadTranslate(string languge);
    }
}
