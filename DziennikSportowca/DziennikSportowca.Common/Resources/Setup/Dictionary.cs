using System;
using System.Collections.Generic;
using System.Text;

namespace DziennikSportowca.Common.Resources.Setup
{
    public class Dictionary
    {
        /// <summary>
        /// Dictionary unique ID
        /// </summary>
        public int DictionaryId { get; set; }

        /// <summary>
        /// Dictionary name
        /// </summary>
        public string DictionaryName { get; set; }

        /// <summary>
        /// Defined names connected with specific culture
        /// </summary>
        public List<DictionaryName> Names { get; set; }
    }
}
