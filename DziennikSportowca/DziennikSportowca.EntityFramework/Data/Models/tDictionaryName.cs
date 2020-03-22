using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DziennikSportowca.EntityFramework.Data.Models
{
    [Table(nameof(tDictionaryName), Schema = SchemaNames.SchDictionaries)]
    public class tDictionaryName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Culture { get; set; }

        public int DictionaryId { get; set; }
        [ForeignKey(nameof(DictionaryId))]
        public tDictionary Dictionary { get; set; }
    }
}
