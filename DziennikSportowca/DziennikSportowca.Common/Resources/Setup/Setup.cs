using DziennikSportowca.Common.Attributes;
using DziennikSportowca.Common.Consts.Infrastructure;
using DziennikSportowca.Common.Extensions;
using DziennikSportowca.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DziennikSportowca.Common.Resources.Setup
{
    public static class Setup
    {
        public static List<Dictionary> GetDictionaries()
        {
            List<Dictionary> dictionaries = EnumExtensions.GetValues<Consts.Dictionaries>()
                .Select(x => new Dictionary()
                {
                    DictionaryId = (int)x,
                    Names = GetDictionaryNames(x)
                }).ToList();

            return dictionaries;
        }

        private static List<DictionaryName> GetDictionaryNames(Enum enumName)
        {
            var cultures = EnumExtensions.GetValues<Cultures>();
            var attributes = enumName.GetAttributes<DictionaryAttribute>();
            var names = new List<DictionaryName>();

            foreach (Cultures culture in cultures)
            {
                foreach (var attribute in attributes)
                {
                    names.Add(new DictionaryName(ResourcesHelpers.GetString<Dictionaries>(attribute.Mapping.ToString(), culture), culture.ToString()));
                }
            }

            return names;
        }
    }
}
