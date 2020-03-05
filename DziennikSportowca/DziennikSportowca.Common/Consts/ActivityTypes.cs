using DziennikSportowca.Common.Attributes;

namespace DziennikSportowca.Common.Consts
{
    public enum ActivityTypes
    {
        [DictionaryItem(ResourcesMapping.Dictionaries.Cardio)]
        Cardio = 10001,

        [DictionaryItem(ResourcesMapping.Dictionaries.Strength)]
        Strength = 10002,
        
        [DictionaryItem(ResourcesMapping.Dictionaries.Stretching)]
        Stretching = 10003
    }
}