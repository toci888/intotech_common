using Intotech.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common
{
    public abstract class TranslationEngineI18n : ITranslationEngineI18n
    {
        protected Dictionary<string, Dictionary<string, string>> ApplicationTranslationData;
                                                   //country code,     tag, translation
                                                   // pl,             _error, "Błąd"
        protected TranslationEngineI18n()
        {
           
        }

        public virtual string Translate(string langCode, string tag)
        {
            if (langCode == null)
            {
                langCode = "pl-PL";
            }

            return ApplicationTranslationData.ContainsKey(langCode) && ApplicationTranslationData[langCode].ContainsKey(tag) ? ApplicationTranslationData[langCode][tag] : tag;
        }
    }
}
