using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SamuraiApp.Domain;
using System;
using System.Diagnostics;

namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=localhost;Initial Catalog=SamuraiAppData;Integrated Security=True",
                options=>options.MaxBatchSize(100))//call merge join; default is 2100
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },
                       LogLevel.Information)
                //.LogTo(log => Debug.WriteLine(log));
                .EnableSensitiveDataLogging();// could check parameters
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

        }
    }
}
