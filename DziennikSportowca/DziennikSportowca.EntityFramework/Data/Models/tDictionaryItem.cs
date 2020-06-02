using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DziennikSportowca.Infrastructure.EntityFramework.Data.Models
{
    [Table(nameof(tDictionary), Schema = SchemaNames.SchDictionaries)]
    public class tDictionaryItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int DictionaryId { get; set; }
        [ForeignKey(nameof(DictionaryId))]
        public virtual tDictionary Dictionary { get; set; }

        public virtual IList<tDictionaryItemName> Names { get; set; }
    }
}