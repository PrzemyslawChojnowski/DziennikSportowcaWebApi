using System.ComponentModel.DataAnnotations.Schema;

namespace DziennikSportowca.EntityFramework.Data.Models
{
    [Table(nameof(tUser), Schema = SchemaNames.SchSecurity)]
    public class tUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}