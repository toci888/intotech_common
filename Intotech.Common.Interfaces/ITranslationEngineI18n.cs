using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Interfaces
{
    public interface ITranslationEngineI18n
    {
        string Translate(string langCode, string tag);
    }
}
