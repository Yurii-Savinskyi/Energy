using Microsoft.EntityFrameworkCore;
using Energy.DataAccess.EntityModels;

namespace Energy.DataAccess.ContextClasses
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Electricity> Electricities { get; set; }

        
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Electricity>(e =>
            {
                e.Property(e => e.Id).ValueGeneratedNever();
            });

            base.OnModelCreating(modelBuilder);

        }
    }
}