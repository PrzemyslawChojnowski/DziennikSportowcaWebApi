using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DziennikSportowca.Infrastructure.EntityFramework.Data.Models
{
    [Table(nameof(tExercise), Schema = SchemaNames.SchExercise)]
    public class tExercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ActivityTypeId { get; set; }

        [ForeignKey(nameof(ActivityTypeId))]
        public tDictionaryItem ActivityType { get; set; }
    }
}