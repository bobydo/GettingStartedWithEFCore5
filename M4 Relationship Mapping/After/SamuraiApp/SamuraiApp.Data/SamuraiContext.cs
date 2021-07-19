using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //https://docs.microsoft.com/en-us/ef/ef6/querying/related-data?redirectedfrom=MSDN
            //https://www.entityframeworktutorial.net/lazyloading-in-entity-framework.aspx
            //https://marketplace.visualstudio.com/items?itemName=ErikEJ.EFCorePowerTools
            optionsBuilder.UseSqlServer(
                "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=SamuraiAppData");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
               modelBuilder.Entity<Samurai>()
                .HasMany(s => s.Battles)
                .WithMany(b => b.Samurais)
                .UsingEntity<BattleSamurai>
                 (bs => bs.HasOne<Battle>().WithMany(),
                  bs => bs.HasOne<Samurai>().WithMany())
                .Property(bs => bs.DateJoined)
                .HasDefaultValueSql("getdate()");

            //composite key
            //modelBuilder.Entity<CourseAssignment>()
            //    .HasKey(c => new { c.CourseID, c.InstructorID });

        }
    }
}
