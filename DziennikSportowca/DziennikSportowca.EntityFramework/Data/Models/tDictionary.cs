﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DziennikSportowca.Infrastructure.EntityFramework.Data.Models
{
    [Table(nameof(tDictionary), Schema = SchemaNames.SchDictionaries)]
    public class tDictionary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<tDictionaryItemName> Names { get; set; }
        public virtual IList<tDictionaryItem> DictionaryItems { get; set; }
    }
}