using DataModel;
using Microsoft.EntityFrameworkCore;

namespace EfCoreOwnwedEntity
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Program.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Company> Companies { get; set; }
    }
}
