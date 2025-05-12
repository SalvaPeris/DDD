using DDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Person>().OwnsOne(p => p.Name, conf =>
            {
                conf.Property(n => n.Value).HasColumnName("Name");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
