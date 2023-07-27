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

        protected TranslationEngineI18n(Dictionary<string, Dictionary<string, string>> applicationTranslationData)
        {
            ApplicationTranslationData = applicationTranslationData;
        }

        public virtual string Translate(string langCode, string tag)
        {
            return ApplicationTranslationData.ContainsKey(langCode) && ApplicationTranslationData[langCode].ContainsKey(tag) ? ApplicationTranslationData[langCode][tag] : tag;
        }
    }
}
