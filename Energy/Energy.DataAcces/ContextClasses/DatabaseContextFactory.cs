using Energy.DataAccess.ContextClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Energy.DataAccess.ContextClasses
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder
                .UseSqlServer("Server=INTELL; Database=Energy; Trusted_Connection=False; User Id=sa; Password=123456; TrustServerCertificate=True;");

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}