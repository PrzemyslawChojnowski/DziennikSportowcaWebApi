using DziennikSportowca.Common.Consts.Infrastructure;
using System;

namespace DziennikSportowca.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DictionaryItemAttribute : Attribute
    {
        public Cultures Culture { get; set; }
        public string DictionaryItemName { get; set; }
        public ResourcesMapping.Dictionaries Mapping { get; set; }

        public DictionaryItemAttribute(Cultures culture, string dictionaryItemName)
        {
            Culture = culture;
            DictionaryItemName = dictionaryItemName;
        }

        public DictionaryItemAttribute(ResourcesMapping.Dictionaries dictionaryItem)
        {
            Mapping = dictionaryItem;
            DictionaryItemName = Resources.Dictionaries.ResourceManager.GetString(dictionaryItem.ToString());
        }
    }
}