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

            //builder.Entity<tDictionary>()
            //    .HasMany(d => d.DictionaryItems)
            //    .WithOne(i => i.Dictionary);
            builder.Entity<tDictionary>().ToTable("tDictionaries");
            builder.Entity<tDictionaryItem>().ToTable("tDictionaryItems");
        }

        public DbSet<tDictionary> tDictionaries { get; set; }
        public DbSet<tDictionaryName> tDictionaryNames { get; set; }
        public DbSet<tDictionaryItem> tDictionaryItems { get; set; }
        public DbSet<tDictionaryItemName> tDictionaryItemNames { get; set; }

        public DbSet<tUser> tUsers { get; set; }
        
        public DbSet<tExercise> tExercises { get; set; }
    }
}