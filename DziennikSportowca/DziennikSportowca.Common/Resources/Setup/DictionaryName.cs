using System;
using System.Collections.Generic;
using System.Text;

namespace DziennikSportowca.Common.Resources.Setup
{
    public class DictionaryName
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DictionaryName()
        {

        }

        /// <summary>
        /// Parametrized constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="culture"></param>
        public DictionaryName(string name, string culture)
        {
            Name = name;
            Culture = culture;
        }

        /// <summary>
        /// Dictionary name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Culture
        /// </summary>
        public string Culture { get; set; }
    }
}
