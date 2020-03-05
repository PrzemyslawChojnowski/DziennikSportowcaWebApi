using DziennikSportowca.Common.Consts.Infrastructure;
using System;

namespace DziennikSportowca.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DictionaryAttribute : Attribute
    {
        public Cultures Culture { get; set; }
        public string DictionaryName { get; set; }
        public ResourcesMapping.Dictionaries Mapping { get; set; }

        public DictionaryAttribute(Cultures culture, string dictionaryName)
        {
            Culture = culture;
            DictionaryName = dictionaryName;
        }

        public DictionaryAttribute(ResourcesMapping.Dictionaries dictionary)
        {
            Mapping = dictionary;
            DictionaryName = Resources.Dictionaries.ResourceManager.GetString(dictionary.ToString());
        }
    }
}