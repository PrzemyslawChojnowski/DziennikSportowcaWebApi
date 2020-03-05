using DziennikSportowca.Common.Consts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace DziennikSportowca.Common.Helpers
{
    public static class ResourcesHelpers
    {
        public static string GetString<T>(string name, Cultures culture)
        {
            Type resourcesType = typeof(T);
            var manager = new ResourceManager(resourcesType);

            return manager.GetString(name, new System.Globalization.CultureInfo(culture.ToString()));
        }
    }
}
