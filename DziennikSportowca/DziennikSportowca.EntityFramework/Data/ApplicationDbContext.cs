using DziennikSportowca.EntityFramework.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DziennikSportowca.EntityFramework.Data
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<tUser> tUsers { get; set; }
    }
}