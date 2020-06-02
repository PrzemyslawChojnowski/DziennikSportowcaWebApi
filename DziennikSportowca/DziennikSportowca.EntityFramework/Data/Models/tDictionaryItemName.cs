using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DziennikSportowca.Infrastructure.EntityFramework.Data.Models
{
    [Table(nameof(tDictionaryItemName), Schema = SchemaNames.SchDictionaries)]
    public class tDictionaryItemName
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Culture { get; set; }

        public int DictionaryItemId { get; set; }
        [ForeignKey(nameof(DictionaryItemId))]
        public tDictionaryItem DictionaryItem { get; set; }
    }
}